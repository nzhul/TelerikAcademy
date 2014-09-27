musicApp.factory('artistData', function ($resource) {
    var resource = $resource('./data/artist/:id', {id: '@id'});
    return {
        getArtist: function (id){
            return resource.get({id: id});
        },
        saveArtist: function (artist) {
            artist.id = 999;
            resource.save(artist);
        },
        getAllArtists: function () {
            return resource.query();
        }
    }
});