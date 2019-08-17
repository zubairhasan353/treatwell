/// <reference path="../angular.min.js" />
var app = angular.module('myapp', []);
app.service("catService", function ($http) {
   
    this.getCategories = function () {
        return $http.get("/api/CustomerProfile?UserId=23909c0a-6dbf-4cf6-950e-787bb932acce");
    }

});
app.controller('app2Controller', function ($scope, catService) {
    $scope.customer = '';
    getUsers();
    function getUsers() {
        promiseGet = catService.getCategories();
        promiseGet.then(function (p1) {
            $scope.customer = p1.data;
        });
        
    }
});


   