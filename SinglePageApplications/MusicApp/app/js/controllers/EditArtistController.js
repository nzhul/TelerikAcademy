'use strict';

musicApp.controller('EditArtistController',
    function EditArtistController($scope) {
        $scope.saveArtist = function (artist, newArtistForm) {
            console.log(newArtistForm);
            alert(artist.name + " " + artist.created);
        };

        $scope.cancel = function () {
            alert('cancel'); // TODO: cancel, redirect
        }
});