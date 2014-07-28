define(['userPersister', 'gamePersister'], function (UserPersister, GamePersister) {
    var MainPersister = (function () {

        function MainPersister(rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
            this.game = new GamePersister(this.rootUrl);
        }

        MainPersister.prototype = {
            isUserLoggedIn: function () {
                var isLoggedIn = this.user.nickname !== null && this.user.sessionKey !== null;
                return isLoggedIn; // This returns true if nickname and sessionKey are defined!
            }
        };

        return MainPersister
    }());
    return MainPersister
});