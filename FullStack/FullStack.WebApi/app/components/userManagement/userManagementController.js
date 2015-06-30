app.controller('userManagementController', function ($scope, $http, userManagementService) {

    userManagementService.GetUsers().then(function (data) {
        $scope.users = data.data;
    });

    $scope.addUser = function () {
        userManagementService.addUser($scope.userToAdd)
            .then(function (data) {
                if(data != null)
                    $scope.users.push(data.data);
            });
    }

    //for some reason i get a 404 with the service deleteUser method
    $scope.deleteUser = function (userId) {
        $http.delete('/api/users/' + userId)
            .success(function () {
                for (var i = 0; i < $scope.users.length; i++)
                    if ($scope.users[i].userId == userId)
                        $scope.users.splice(i, 1);
            })
            .error(function (data, headers, status, config) {
                alert(headers);
            });
    }
    
    $scope.updateUser = function(user) {
        userManagementService.updateUser(user)
            .then(function(data) {
                for (var i = 0; i < $scope.users.length; i++)
                    if ($scope.users[i].userId == user.userId) {
                        $scope.users[i].userName = data.data.userName;
                        $scope.users[i].editEnabled = false;
                    }
            });
    }
});