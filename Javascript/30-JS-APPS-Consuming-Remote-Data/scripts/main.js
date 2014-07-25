(function () {
    require.config({
        paths: {
            'jquery' : '../bower_components/jquery/dist/jquery.min',
            'requestModule': 'requestmodule',
            'q' : '../bower_components/q/q'
        }
    });

    require(['requestModule'], function (requestModule) {

    })
}());