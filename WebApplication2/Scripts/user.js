$(document.body).ready(function () {
    getUsers();
    $('#edit').on('click', function () {
        editUser();
    });
    $('#add').on('click', function () {
        addUser();
    });
});

function editUser() {
    var postData = JSON.stringify({
        Id: $('#userId').val(),
        Name: $('#username').val(),
        Address: $('#address').val()
    });
    $.ajax({
        url: '/user/edituser',
        data: postData,
        contentType: 'application/json',
        type: 'POST',
        success: function (result) {
            $('#editMessage').html("The user has been updated.");
            $('#editMessage').show();
            $('#errorMessage').hide();
        },
        error: function (xhr, textStatus, exceptionThrown) {
            var errorData = $.parseJSON(xhr.responseText);
            var errorMessages = [];
            //this ugly loop is because List<> is serialized to an object instead of an array
            for (var key in errorData) {
                errorMessages.push(errorData[key]);
            }
            $('#errorMessage').html(errorMessages.join("<br />"));
            $('#editMessage').hide();
            $('#errorMessage').show();
        }
    });
}

function addUser() {
    var postData = JSON.stringify({
        Name: $('#username').val(),
        Address: $('#useraddress').val()
    });
    $.ajax({
        url: '/user/adduser',
        data: postData,
        contentType: 'application/json',
        type: 'POST',
        success: function (result) {
            $('#addMessage').html("The user has been created.");
            $('#addMessage').show();
            $('#errorMessage').hide();
        },
        error: function(xhr, textStatus, exceptionThrown) {
            var errorData = $.parseJSON(xhr.responseText);
            var errorMessages = [];
            //this ugly loop is because List<> is serialized to an object instead of an array
            for (var key in errorData)
            {
                errorMessages.push(errorData[key]);
            }
            $('#errorMessage').html(errorMessages.join("<br />"));
            $('#addMessage').hide();
            $('#errorMessage').show();
        }
    });
}

function deleteUser(id) {
    var postData = JSON.stringify({
        id: id
    });
    $.ajax({
        url: '/user/deleteuser',
        data: postData,
        contentType: 'application/json',
        type: 'POST',
        success: function (result) {
            $('#userTable tr#user_' + id).remove();
        },
        error: function (xhr, textStatus, exceptionThrown) {
            
        }
    });
}

function getUsers() {
    $.ajax({
        url: '/user/getusers',
        contentType: 'application/json',
        type: 'POST',
        success: function (result) {
            for (var i = 0; i < result.length; i++) {
                $('#userTable').append('<tr id="user_' + result[i].Id + '">' +
                    '<td>' + result[i].Id + '</td>' +
                    '<td>' + result[i].Name + '</td>' +
                    '<td>' + result[i].Address + '</td>' +
                    '<td><a href="/user/edit/' + result[i].Id + '">Edit</a></td>' +
                    '<td><a onClick="deleteUser(' + result[i].Id + ')">Delete</a></td>' +
                '</tr>');
            }
        },
        error: function (result) {
        }
    });
}