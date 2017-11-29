(function(){
    'use strict';
    angular.module('MySearchApp', []);

    angular.module('MySearchApp')
    .controller('HomeController', function ($scope, $http) {
        $http.get('/Home/GetAccounts').then(function (success) {
            $scope.accounts = success.data;
        }, function (error) {
            alert("Operation Failed");
        })
    })
})();