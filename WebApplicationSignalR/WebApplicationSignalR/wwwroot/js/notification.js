var connectionNotification = new signalR.HubConnectionBuilder().withUrl("/hubs/notification").build();
var sendButton = document.getElementById("sendButton");
sendButton.disabled = true;

sendButton.addEventListener("click", function (event) {
    event.preventDefault();
    var message = document.getElementById("notificationInput").value;
    connectionNotification.send("SendMessage", message).then(() => document.getElementById("notificationInput").value = "");
   
});

connectionNotification.on("LoadNotification", (messages, counter) => {   
    var messagesList = document.getElementById("messageList");
    var counterNotifi = document.getElementById("notificationCounter");
    counterNotifi.innerHTML = "<span>(" + counter + ")</span>";
    messagesList.innerHTML = "";
    
    for (var message of messages) {       
        var li = document.createElement("li");
        li.textContent = "Notification - " + message;
        messagesList.appendChild(li);
    }
});

function onSuccess() {
    sendButton.disabled = false;
    connectionNotification.send("LoadMessages");
    console.log("Connection successful");
}

function onFailure() {
    console.log("Error on connection");
}
connectionNotification.start().then(onSuccess, onFailure);
