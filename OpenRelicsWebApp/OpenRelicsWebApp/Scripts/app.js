var app = angular.module('OpenRelicsAngular', []);

app.controller('IndexController', function ($scope, $http) {
    var queries;

    $http({
        method: 'GET',
        url: '/api/relics/queries'
    }).then(function successCallback(response) {
            queries = response.data;
        },
        function errorCallback(response) {
            alert(response.statusText);
        });

    $scope.onSelect = function() {
        var index = queries.indexOf($scope.selected);
        switch (index) {
            case 0:
                //show ui for getByID
            case 1:
                //show ui for directDescendants
            case 2:
                //show ui for allDescendants
            case 3:
                //show ui for allFromRegion
            
            default:
        }

    };

    /*
    $scope.queries = [
        'Get by ID',
        'Get direct descendants',
        'Get all descendants',
        'Get all relics from given region '
    ];*/
});