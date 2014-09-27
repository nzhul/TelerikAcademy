'use strict';

var musicApp = angular
    .module('musicApp', ['ngResource', 'ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/add-artist', {
            templateUrl: './templates/add-artist.html'
            })
            .when('/artist-details/:id', {
                templateUrl: './templates/artist-details.html'
            })
            .when('/', {
                templateUrl: './templates/list-artists.html'
            })
            .otherwise({redirectTo: '/'})
    })
    .constant('author', 'Dobromir Ivanov');
