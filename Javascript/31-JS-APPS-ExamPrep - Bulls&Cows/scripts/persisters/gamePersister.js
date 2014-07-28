define(['requestModule'], function (requestModule) {
    var GamePersister = (function () {

        function GamePersister(rootUrl) {
            this.rootUrl = rootUrl + 'game/';
            this.sessionKey = localStorage.getItem('sessionKey');
        }

        GamePersister.prototype = {
            create: function () {

            },
            join: function (game, success, error) {
                var url = this.rootUrl + 'join/' + this.sessionKey;
                requestModule.postJSON(url, game, success, error);
            },
            start: function () {

            },
            myActive: function (success, error) {
                var url = this.rootUrl + 'my-active/' + this.sessionKey;
                requestModule.getJSON(url, success, error);
            },
            open: function (success, error) {
                this.sessionKey = localStorage.getItem('sessionKey');
                var url = this.rootUrl + 'open/' + this.sessionKey;

                requestModule.getJSON(url, success, error);
            },
            state: function () {

            }
        };

        return GamePersister
    }());
    return GamePersister
});