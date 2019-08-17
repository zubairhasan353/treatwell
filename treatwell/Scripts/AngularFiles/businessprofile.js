/// <reference path="../angular.min.js" />
var app = angular.module('myapp', []);
app.service("catService", function ($http) {
   
    this.getCategories = function (id) {
        return $http.get("/api/SaloonProfile?VenueId="+id);
    }

});
var app = angular.module('myapp', []);
app.service("catService", function ($http) {
   
    this.getCategories = function (id) {
        return $http.get("/api/SaloonProfile?VenueId="+id);
    }

});
app.controller('app2Controller', function ($scope, catService) {
    $scope.venue = '';
    getUsers();
    function getUsers() {
        promiseGet = catService.getCategories(21);
        promiseGet.then(function (p1) {
            $scope.venue = p1.data;
        });

    }
});


   