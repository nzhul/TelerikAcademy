'use strict';

musicApp.directive('searchArtists', function () {
    return {
        restrict: 'EA',
        templateUrl: './templates/directives/search-artist.html',
        replace: true
    }
});