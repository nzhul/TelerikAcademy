(function () {
   require.config({
       paths: {
           'jquery': 'libs/jquery-2.1.1.min',
           'handlebars': 'libs/handlebars',
           'combo-box': 'combobox',
           'data': 'data'
       }
   });

    require(['main'], function (main) {
        main.run();
    })
}());