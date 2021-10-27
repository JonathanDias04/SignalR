var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();
var chartBlock = '\u25A3';

connection.on("ReceiveMessage", function (message) {

    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var pollResultMsg = "Log: " + msg;

    var ulPoll = document.getElementById("messagesList");
    var liPollResult = document.createElement("li");
    liPollResult.textContent = pollResultMsg;

    ulPoll.appendChild(liPollResult);

    document.getElementById(myChannelId + 'Block').innerHTML += chartBlock;
});


connection.start().catch(function (err) {
    return console.error(err.toString());
});
