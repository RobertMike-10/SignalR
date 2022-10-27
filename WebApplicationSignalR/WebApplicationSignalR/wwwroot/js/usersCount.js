
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

//recibing data from Hub
connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerHTML = value;
});

connectionUserCount.on("updateTotalUsers", (value) => {

    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerHTML = value;
});

//sending data from client
function newWindowLoaded() {
    connectionUserCount.invoke("NewWindowLoaded").then((value) => console.log("Loaded:" + value));
}

function onSuccess() {
    console.log("Connection successful");
    newWindowLoaded();
}

function onFailure() {
    console.log("Error on connection");
}

connectionUserCount.start().then(onSuccess, onFailure);