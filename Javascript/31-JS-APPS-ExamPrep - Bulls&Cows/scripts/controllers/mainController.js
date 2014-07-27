define(['jquery', 'mainPersister'], function ($, MainPersister) {
    var MainController = (function () {

        function MainController(rootUrl) {
            this.persister = new MainPersister(rootUrl);
        }

        MainController.prototype = {
            loadUI: function (selector) {
                if(isUserLoggedIn){
                    this.loadGameUI();
                } else {
                    this.loadLoginFormUI();
                }
            }
        };

        return MainController
    }());
    return MainController
});