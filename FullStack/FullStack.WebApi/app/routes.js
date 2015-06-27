app.config(function($routeProvider) {
    $routeProvider
        .when('/userManagement',
        {
            controller: 'userManagementController',
            templateUrl: 'app/components/userManagement/userManagement.html'
        })
        .when('/roleManagement',
        {
            controller: 'roleManagementController',
            templateUrl: 'app/components/roleManagement/roleManagement.html'
        })
        .when('/users/:userId',
        {
            controller: 'userRoleManagementController',
            templateUrl: 'app/components/userRoleManagement/userRoleManagement.html'
        })
        .when('/',
        {
            controller: 'homeController',
            templateUrl: 'app/components/home/home.html'
        })
        .otherwise({ redirectTo: '/' });
});