'use strict';

musicApp.controller('AddArtistController',
    function AddArtistController($scope, artistData) {
        $scope.saveArtist = function (artist, addArtistForm) {
            console.log(artist);
            console.log(addArtistForm);
            if(addArtistForm.$valid){
                artistData.saveArtist(artist);
                alert(('Artist ' + artist.name + ' saved!'))
            }
        };

        $scope.cancel = function () {
            alert('cancel'); // TODO: cancel, redirect
        }
});