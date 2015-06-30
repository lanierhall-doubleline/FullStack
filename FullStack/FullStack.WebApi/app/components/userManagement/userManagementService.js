app.service('userManagementService', function($http) {

    this.GetUsers = function () {
        return $http.get('/api/Users')
            .success(function(data, headers, status, config) {
                for (var i = 0; i < data.length; i++)
                    data[i].editEnabled = false;
                return data;
            })
            .error(function(data, headers, status, config) {
                alert("Error retrieving users");
                return [];
            });
    }


    this.addUser = function (user) {
        return $http.post('/api/Users', user)
            .success(function (data) {
                return data;
            })
            .error(function () {
                alert("Error adding user");
            });
    }

    this.deleteUser = function (userId) {
        return $http.delete('/api/users/' + userId)
            .success(function () {
                return true;
            })
            .error(function (data, headers, status, config) {
                alert(headers);
            });
    }

    this.updateUser = function (user) {
        return $http.put('/api/users/' + user.userId, user)
            .success(function (data) {
                return data;
            })
            .error(function (data, headers, status, config) {
                alert(headers);
            });
    }
});