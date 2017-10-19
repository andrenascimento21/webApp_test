(function () {
    var userSvc = function ($http) {
        var getUsers = function () {
            return $http.get('/user/getusers');
        }
        var editUser = function (model) {
            return $http.post('/user/edituser', model);
        }
        var addUser = function (model) {
            return $http.post('/user/adduser', model);
        }
        var deleteUser = function (id) {
            return $http.post('/user/deleteuser', { id: id });
        }

        return {
            editUser: editUser,
            addUser: addUser,
            deleteUser: deleteUser,
            getUsers: getUsers
        };
    }

    userSvc.$inject = ['$http'];
    angular.module('user.app')
        .factory('userSvc', userSvc);
}());