var connectionBasicChat = new signalR.HubConnectionBuilder().withUrl("/hubs/basicChat").build();
var sendMessage = document.getElementById("sendMessage");
sendMessage.disabled = true;

sendMessage.addEventListener("click", function (event) {
    event.preventDefault();
    var message = document.getElementById("chatMessage").value;
    var sender = document.getElementById("receiverEmail").value;
    connectionNotification.send("SendMessage", message, sender).then(() => document.getElementById("notificationInput").value = "");

});

connectionNotification.on("MessageReceived", (message, user) => {

});

function onSuccess() {
    sendMessage.disabled = false;
    console.log("Connection successful");
}

function onFailure() {
    console.log("Error on connection");
}
connectionNotification.start().then(onSuccess, onFailure);