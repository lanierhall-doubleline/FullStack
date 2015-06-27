app.controller('userRoleManagementController', function ($scope, $http, $routeParams) {

    var userId = $routeParams.userId;

    $http.get('/api/users/' + userId)
        .success(function (data, headers, status, config) {
            $scope.allRoles = data.roles;
            $scope.user = data.user;
            $scope.unauthorizedRoles = [];

            for (var i = 0; i < $scope.allRoles.length; i++) {
                var roleFound = false;
                for (var j = 0; j < $scope.user.userRoles.length; j++)
                    if ($scope.allRoles[i].roleId == $scope.user.userRoles[j].roleId) {
                        $scope.user.userRoles[j].role = $scope.allRoles[i];
                        roleFound = true;
                    }
                if(!roleFound)
                    $scope.unauthorizedRoles.push($scope.allRoles[i]);
            }
        })
        .error(function (data, headers, status, config) {
            $scope.user = {
                userRoles: [],
            };
            $scope.unauthorizedRoles = [];
            $scope.allRoles = [];
            alert("Error retrieving user and roles");
        });

    $scope.addRole = function(roleId) {
        $http.post('/api/users/' + userId + '/roles/' + roleId)
            .success(function(data) {
                $scope.user.userRoles.push(data);
                for (var i = 0; i < $scope.unauthorizedRoles.length; i++)
                    if ($scope.unauthorizedRoles[i].roleId == roleId)
                        $scope.unauthorizedRoles.splice(i, 1);
            })
            .error(function(data, headers, status, config) {
                alert("Error adding userRole");
            });
    }

    $scope.removeRole = function (roleId) {
        $http.delete('/api/users/' + userId + "/roles/" + roleId)
            .success(function () {
                for (var i = 0; i < $scope.user.userRoles.length; i++)
                    if ($scope.user.userRoles[i].roleId == roleId) {
                        $scope.unauthorizedRoles.push($scope.user.userRoles[i].role);
                        $scope.user.userRoles.splice(i, 1);
                    }
            })
            .error(function (data, headers, status, config) {
                alert(headers);
            });
    }
});