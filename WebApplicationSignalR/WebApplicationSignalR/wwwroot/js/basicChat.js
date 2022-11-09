var connectionBasicChat = new signalR.HubConnectionBuilder().withUrl("/hubs/basicChat").build();
var sendMessage = document.getElementById("sendMessage");
sendMessage.disabled = true;

sendMessage.addEventListener("click", function (event) {
    event.preventDefault();
    var message = document.getElementById("chatMessage").value;
    var sender = document.getElementById("senderEmail").value;
    var receiver = document.getElementById("receiverEmail").value;

    if (receiver.length > 0) {
        connectionBasicChat.invoke("SendPrivateMessage", sender, receiver, message).catch(function (err) {
            return console.error(err.toString());
        });
    }
    else
     connectionBasicChat.send("SendMessageToAll", sender,message );

});

connectionBasicChat.on("MessageReceived", (user, message) => {
    console.log("Recibi mensaje");
    var messageList = document.getElementById("messagesList");
    var li = document.createElement("li");
    li.textContent = `${user} says ${message}`;
    messagesList.appendChild(li);
});

function onSuccess() {
    sendMessage.disabled = false;
    console.log("Connection successful");
}

function onFailure() {
    console.log("Error on connection");
}
connectionBasicChat.start().then(onSuccess, onFailure);