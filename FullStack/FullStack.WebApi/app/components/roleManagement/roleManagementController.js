app.controller('roleManagementController', function($scope, $http) {
    $http.get('/api/roles')
        .success(function(data, headers, status, config) {
            for (var i = 0; i < data.length; i++)
                data[i].editEnabled = false;
            $scope.roles = data;
        })
        .error(function(data, headers, status, config) {
            $scope.roles = [];
            alert("Error retrieving roles");
        });

    $scope.addRole = function () {
        var role = {
            roleName: $scope.roleToAdd
        };
        $http.post('/api/roles', role)
            .success(function(data) {
                $scope.roles.push(data);
            })
            .error(function() {
                alert("Error adding role");
            });
    }

    $scope.deleteRole = function(roleId) {
        $http.delete('/api/roles/' + roleId)
            .success(function() {
                for (var i = 0; i < $scope.roles.length; i++)
                    if ($scope.roles[i].roleId == roleId)
                        $scope.roles[i].splice(i, 1);
            })
            .error(function(data, headers, status, config) {
                alert(headers);
            });
    }

    $scope.updateRole = function(role) {
        $http.put('/api/roles/' + role.roleId, role)
            .success(function(data) {
                for (var i = 0; i < $scope.roles.length; i++)
                    if ($scope.roles[i].roleId == role.roleId) {
                        $scope.roles[i].roleName = data.roleName;
                        $scope.roles[i].editEnabled = false;
                    }
            })
            .error(function(data, headers, status, config) {
                alert(headers);
            });
    }
});