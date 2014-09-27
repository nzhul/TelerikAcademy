'use strict';
musicApp.controller('ArtistDetailsController',
    function ArtistDetailsController ($scope, $routeParams, artistData) {


        $scope.artist = artistData.getArtist($routeParams.id);

        $scope.blueTextClass = "blue-text";
        $scope.grayBackgroundClass = "gray-background";

        $scope.hideInformation = true;
        $scope.showInfoText = "Show";
        $scope.showMoreInfo = showMoreInfo;

        $scope.hideBandMembers = true;
        $scope.showBandMembersText = "Show";
        $scope.showBandMembers = showBandMembers;

        $scope.hideRecords = true;
        $scope.showRecordsText = "Show";
        $scope.showRecords = showRecords;

        $scope.upVoteRating = upVoteRating;
        $scope.downVoteRating = downVoteRating;

        $scope.sort = "rating";

        function showRecords () {
            if($scope.hideRecords == true){
                $scope.hideRecords = false;
                $scope.showRecordsText = "Hide";
            } else {
                $scope.showRecordsTextText = "Show";
                $scope.hideRecords = true;
            }
        }

        function showBandMembers () {
            if($scope.hideBandMembers == true){
                $scope.hideBandMembers = false;
                $scope.showBandMembersText = "Hide";
            } else {
                $scope.showBandMembersText = "Show";
                $scope.hideBandMembers = true;
            }
        }


        function showMoreInfo () {
            if($scope.hideInformation == true){
                $scope.hideInformation = false;
                $scope.showInfoText = "Hide";
            } else {
                $scope.showInfoText = "Show";
                $scope.hideInformation = true;
            }
        }

        function upVoteRating(album){
            album.rating++;
        }

        function downVoteRating (album) {
            if(album.rating > 0)
            {
                album.rating--;
            }
        }
});