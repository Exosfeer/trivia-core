// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubstandard")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.on("ReceiveMessage", (object) => {
    console.log("Message received");
    console.log(object);
    var objectSender = '-backend';
    if ('senderConnectionId' in object && object.senderConnectionId !== undefined) {
        objectSender = object.senderConnectionId;
    }
    if ('identity' in object && object.identity.isAuthenticated && object.identity.name === undefined) {
        objectSender = object.identity.name;
    }
    var objectMessage = object.message;
    var chatSyntax = "anonymous[" + objectSender + "]" + ": " + objectMessage;
    $('#signalr-message-panel').prepend($('<div />').text(chatSyntax));
});

$('#btn-broadcast').click(function () {
    var message = $('#broadcast').val();
    connection.invoke("BroadcastMessage", message).catch(err => console.error(err.toString()));
});

$('#btn-self-message').click(function () {
    var message = $('#self-message').val();
    connection.invoke("SendToCaller", message).catch(err => console.error(err.toString()));
});

$('#btn-others-message').click(function () {
    var message = $('#others-message').val();
    connection.invoke("SendToOthers", message).catch(err => console.error(err.toString()));
});

$('#btn-group-message').click(function () {
    var message = $('#group-message').val();
    var group = $('#group-for-message').val();
    connection.invoke("SendToGroup", group, message).catch(err => console.error(err.toString()));
});

$('#btn-group-add').click(function () {
    var group = $('#group-to-add').val();
    connection.invoke("AddUserToGroup", group).catch(err => console.error(err.toString()));
});

$('#btn-group-remove').click(function () {
    var group = $('#group-to-remove').val();
    connection.invoke("RemoveUserFromGroup", group).catch(err => console.error(err.toString()));
});

async function start() {
    try {
        await connection.start();
        console.log('connected');
    } catch (err) {
        console.log(err);
        setTimeout(() => start(), 5000);
    }
};

connection.onclose(async () => {
    await start();
});

start();