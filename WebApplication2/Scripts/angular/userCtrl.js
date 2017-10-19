(function () {
    var _self, _userSvc;
    var userCtrl = function (userSvc) {
        _userSvc = userSvc;
        _self = this;

        _self.init = init;
        _self.getUsers = getUsers;
        _self.editUser = editUser;
        _self.addUser = addUser;
        _self.deleteUser = deleteUser;
    }

    userCtrl.$inject = ['userSvc'];

    angular.module('user.app')
        .controller('userCtrl', userCtrl);

    function init(id, name, address) {
        _self.user = {
            id: id,
            name: name,
            address: address
        };
    }

    function editUser(form) {
        if (!form.$invalid) {
            var model = {
                Id: _self.user.id,
                Name: _self.user.name,
                Address: _self.user.address
            };
            _userSvc.editUser(model)
                .then(function (response) {
                    _self.message = response.data;
                })
                .catch(function(response){
                    _self.message = "";
                    angular.forEach(response.data, function (value, key) {
                        _self.message += value + "<br />";
                    });
                });
        }
    }

    function addUser(form) {
        if (!form.$invalid) {
            var model = {
                Name: _self.user.name,
                Address: _self.user.address
            };
            _userSvc.addUser(model)
                .then(function (response) {
                    _self.message = response.data;
                })
                .catch(function (response) {
                    _self.message = "";
                    angular.forEach(response.data, function (value, key) {
                        _self.message += value + "<br />";
                    });
                });
        }
    }

    function getUsers() {
        _userSvc.getUsers()
            .then(function (response) {
                _self.users = response.data;
            })
            .catch(function (response) {
                _self.users = [];
            });
    }

    function deleteUser(user){
        _userSvc.deleteUser(user.Id)
            .then(function (response) {
                var index = _self.users.indexOf(user);
                _self.users.splice(index, 1);
            })
            .catch(function (response) {
            });
    }
}());