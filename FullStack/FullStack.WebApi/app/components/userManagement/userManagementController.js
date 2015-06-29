app.controller('userManagementController', function($scope, $http) {
    $http.get('/api/Users')
        .success(function(data, headers, status, config) {
            for (var i = 0; i < data.length; i++)
                data[i].editEnabled = false;
            $scope.users = data;
        })
        .error(function(data, headers, status, config) {
            $scope.users = [];
            alert("Error retrieving users");
        });

    $scope.addUser = function () {
        var user = {
            userName: $scope.userToAdd
        };
        $http.post('/api/Users', user)
            .success(function(data) {
                $scope.users.push(data);
            })
            .error(function() {
                alert("Error adding user");
            });
    }

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
        $http.put('/api/users/' + user.userId, user)
            .success(function(data) {
                for (var i = 0; i < $scope.users.length; i++)
                    if ($scope.users[i].userId == user.userId) {
                        $scope.users[i].userName = data.userName;
                        $scope.users[i].editEnabled = false;
                    }
            })
            .error(function(data, headers, status, config) {
                alert(headers);
            });
    }
});