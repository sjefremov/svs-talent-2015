(function () {
    var app = angular.module("AngularDemo");
    app.controller("weatherController", ["$scope", "$http", weatherController]);
    function weatherController($scope, $http) {
        $scope.user = {
            "FirstName": "Bill",
            "LastName": "Gates",
            "Division": "Micorosoft",
            "ImageUrl": "https://www.lexo.ch/blog/wp-content/uploads/2015/01/Bill-Gates-1024x747.jpg"
        };

       

        var onSuccessCity = function(response) {
            //$scope.cityWeather = response.data;
            $scope.cities = response.data.list;
            $scope.showCitites = true;
        };

        var onError = function(reason) {
            $scope.error = reason;
            $scope.showCitites = false;
        }
       
        //$scope.citySearch = "Paris";
        //$scope.search = function(city) {
        //    var url = "http://api.openweathermap.org/data/2.5/weather?q=" + city;
        //    $http.get(url).then(onSuccessCity, onError);
        //}
        $scope.search = function (city) {
            var url = "http://api.openweathermap.org/data/2.5/box/city?bbox=12,32,15,37,10&cluster=yes";
            $http.get(url).then(onSuccessCity, onError);
        }
        $scope.search();
        $scope.sort = function(columnName) {
            console.log(columnName);
            if ($scope.sortColumn === columnName) {
                $scope.sortColumn = "-" + columnName;
            } else {
                $scope.sortColumn = columnName;
            }
        }
        
    }
}());