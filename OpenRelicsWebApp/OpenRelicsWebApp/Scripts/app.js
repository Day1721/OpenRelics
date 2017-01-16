﻿var app = angular.module('OpenRelicsAngular', []);

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

    $scope.voivodeships = [
        'dolnośląskie',
        'kujawsko-pomorskie',
        'lubelskie',
        'lubuskie',
        'łódzkie',
        'małopolskie',
        'mazowieckie',
        'opolskie',
        'podkarpackie',
        'podlaskie',
        'pomorskie',
        'śląskie',
        'świętokrzyskie',
        'warmińsko-mazurskie',
        'wielkopolskie',
        'zachodniopomorskie'
    ];

    $scope.districts = {
        'dolnośląskie': [
            'Wrocław',
            'Jelenia Góra',
            'Legnica',
            'Wałbrzych',
            'bolesławiecki',
            'dzierżoniowski',
            'głogowski',
            'górowski',
            'jaworski',
            'jeleniogórski',
            'kamiennogórski',
            'kłodzki',
            'legnicki',
            'lubański',
            'lubiński',
            'lwówecki',
            'milicki',
            'oleśnicki', 
            'oławski',
            'polkowicki',
            'strzeliński',
            'średzki',
            'świdnicki',
            'trzebnicki',
            'wałbrzyski',
            'wołowski',
            'wrocławski', 
            'ząbkowicki',
            'zgorzelecki',
            'złotoryjski'
        ],
        'kujawsko-pomorskie': [
            'Bydgoszcz',
            'Toruń',
            'Włocławek',
            'Grudziądz',
            'aleksandrowski',
            'brodnicki',
            'bydgoski',
            'chełmiński',  
            'golubsko-dobrzyński',
            'grudziądzki',
            'inowrocławski',
            'lipnowski',
            'mogileński',
            'nakielski',
            'radziejowski',
            'rypiński',
            'sępoleński', 
            'świecki',
            'toruński',
            'tucholski',
            'wąbrzeski',
            'włocławski',
            'żniński'
        ],
        'lubelskie': [],
        'lubuskie': [],
        'łódzkie': [],
        'małopolskie': [],
        'mazowieckie': [],
        'opolskie': [],
        'podkarpackie': [],
        'podlaskie': [],
        'pomorskie': [],
        'śląskie': [],
        'świętokrzyskie': [],
        'warmińsko-mazurskie': [],
        'wielkopolskie': [],
        'zachodniopomorskie': []
    }
});