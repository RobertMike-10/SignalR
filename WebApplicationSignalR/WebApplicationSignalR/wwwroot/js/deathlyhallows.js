
var connectionDeathlyHallows = new signalR.HubConnectionBuilder().withUrl("/hubs/deathlyhallows").build();
var cloakCounter = document.getElementById("cloakCounter");
var stoneCounter = document.getElementById("stoneCounter");
var wandCounter = document.getElementById("wandCounter");

//recibing data from Hub
connectionDeathlyHallows.on("updateDeathlyHallowCount", (cloak,stone, wand) => {

    cloakCounter.innerHTML = cloak;
    stoneCounter.innerHTML = stone;
    wandCounter.innerHTML = wand;
});



function onSuccess() {
    
    connectionDeathlyHallows.invoke("GetRaceStatus").then((raceCounter) => {    
        cloakCounter.innerHTML = raceCounter.cloak;
        stoneCounter.innerHTML = raceCounter.stone;
        wandCounter.innerHTML = raceCounter.wand;
    });
    console.log("Connection successful");
}

function onFailure() {
    console.log("Error on connection");
}

connectionDeathlyHallows.start().then(onSuccess, onFailure);