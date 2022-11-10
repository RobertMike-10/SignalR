var connectionChat = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/chat")
    .withAutomaticReconnect([0,1000,5000,10000,null])
    .build();

connectionChat.on("ReceiveUserConnected", (userId, userName, isOldConnection) => {
    console.log("Connected:" + username);
    if (!isOldConnection)
      addMessage(`${userName} is online`);
});

connectionChat.on("ReceiveUserDisconnected", (userId, userName, userHasConnection) => {
    console.log("DisConnected:" + username);
    if (!userHasConnection)
        addMessage(`${userName} is offline`);
});


function addMessage(msg) {
    if (msg == null && msg == '') {
        return;
    }
    let ui = document.getElementById('messagesList');
    let li = document.createElement("li");
    li.innerHTML = msg;
    ui.appendChild(li);
}


function onSuccess() {
        console.log("Connection successful");
}

function onFailure() {
        console.log("Error on connection");
}
connectionChat.start().then(onSuccess, onFailure);