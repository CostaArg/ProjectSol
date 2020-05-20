﻿$(function () {
    // Reference the auto-generated proxy for the hub.
    var chat = $.connection.chatHub;
    // Create a function that the hub can call back to display messages.
    chat.client.addNewMessageToPage = function (name, message) {
        if (name == "AdminName") {
            // Add the message to the page.
            $('#discussion').append('<p style="color:green; text-align:left; width:500px"><strong><i class="fas fa-user-circle"></i>'
                + ' </strong> ' + htmlEncode(message) + '</p>');
        }
        else if (name != "AdminName") {
            // Add the message to the page.
            $('#discussion').append('<p style="color:blue;text-align:right;"><strong><i class="fas fa-user-circle"></i>'
                + ' </strong> ' + htmlEncode(message) + '</p>');
        }
    };
    // Get the user name and store it to prepend to messages.
    $('#displayname').val(prompt('Enter your name:', ''));
    // Set initial focus to message input box.
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            chat.server.send($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });
});
// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}