var app = angular.module('OpenRelicsAngular', []);

app.controller('IndexController', function ($scope, $http) {
    var queries;
    
    $http({
        method: 'GET',
        url: '/api/relics/queries'
    }).then(function success(response) {
            queries = response.data;
        },
        function error(response) {
            alert(response.statusText);
        });

    $scope.onSelect = function() {
        $scope.index = queries.indexOf($scope.selected);
    };
});