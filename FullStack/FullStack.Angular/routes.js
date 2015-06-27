app.config(function ($routeProvider) {
    $routeProvider
        .when('/',
            {
                controller: 'helloWorld',
                templateUrl: 'components/helloWorld/helloWorld.html'
            })
        .otherwise({ redirectTo: '/' });
});