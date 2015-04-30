(function () {
    var app = angular.module("AngularDemo", ['ngRoute']);
    app.config(function ($routeProvider) {
        $routeProvider.when("/cities", {
            templateUrl: 'cities.html',
            controller: 'weatherController'
        }).when("/city/:cityName", {
            templateUrl: 'city.html',
            controller: 'cityController'
        }).otherwise({ redirectTo: "/" })
    });
}());