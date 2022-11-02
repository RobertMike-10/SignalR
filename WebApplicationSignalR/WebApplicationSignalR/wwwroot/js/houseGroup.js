
var connectionHouseGroup = new signalR.HubConnectionBuilder().withUrl("/hubs/houseGroup").build();
let btn_un_gryffindor = document.getElementById("btn_un_gryffindor");
let btn_un_slytherin = document.getElementById("btn_un_slytherin");
let btn_un_hufflepuff = document.getElementById("btn_un_slytherin");
let btn_un_ravenclaw = document.getElementById("btn_un_ravenclaw");
let btn_gryffindor = document.getElementById("btn_gryffindor");
let btn_slytherin = document.getElementById("btn_slytherin");
let btn_hufflepuff = document.getElementById("btn_hufflepuff");
let btn_ravenclaw = document.getElementById("btn_ravenclaw");

let trigger_gryffindor = document.getElementById("trigger_gryffindor");
let trigger_slytherin = document.getElementById("trigger_slytherin");
let trigger_hufflepuff = document.getElementById("trigger_hufflepuff");
let trigger_ravenclaw = document.getElementById("trigger_ravenclaw");

btn_gryffindor.addEventListener("click", function (event) {
    event.preventDefault();
    connectionHouseGroup.send("JoinHouse", "Gryffindor");
});

btn_slytherin.addEventListener("click", function (event) {
    event.preventDefault();
    connectionHouseGroup.send("JoinHouse", "Slytherin");
});

btn_hufflepuff.addEventListener("click", function (event) {
    event.preventDefault();
    connectionHouseGroup.send("JoinHouse", "Hufflepuff");
});

btn_ravenclaw.addEventListener("click", function (event) {
    event.preventDefault();
    connectionHouseGroup.send("JoinHouse", "Ravenclaw");
});

btn_un_gryffindor.addEventListener("click", function (event) {
    event.preventDefault();
    connectionHouseGroup.send("LeaveHouse", "Gryffindor");
});

btn_un_slytherin.addEventListener("click", function (event) {
    event.preventDefault();
    connectionHouseGroup.send("LeaveHouse", "Slytherin");
});

btn_un_hufflepuff.addEventListener("click", function (event) {
    event.preventDefault();
    connectionHouseGroup.send("LeaveHouse", "Hufflepuff");
});
btn_un_ravenclaw.addEventListener("click", function (event) {
    event.preventDefault();
    connectionHouseGroup.send("LeaveHouse", "Ravenclaw.");
});
function onSuccess() {

    console.log("Connection successful");
}

function onFailure() {
    console.log("Error on connection");
}

connectionHouseGroup.start().then(onSuccess, onFailure);