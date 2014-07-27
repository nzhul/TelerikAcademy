define(['userPersister'], function (UserPersister) {
    var MainPersister = (function () {

        var nickname = localStorage.getItem('nickname');
        var sessionKey = localStorage.getItem('sessionKey');

        function MainPersister(rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
        }

        MainPersister.prototype = {
            isUserLoggedIn: function () {
                return (nickname && sessionKey) == true; // This returns true if nickname and sessionKey are defined!
            }
        };

        return MainPersister
    }());
    return MainPersister
});