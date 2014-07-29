define(['requestModule', 'cryptojs'], function (requestModule) {
    var UserPersister = (function () {

        function UserPersister(rootUrl) {
            this.rootUrl = rootUrl;
            this.username = localStorage.getItem('username');
            this.sessionKey = localStorage.getItem('sessionKey');
        }

        UserPersister.prototype = {
            login: function (user, success, error) {
                var url = this.rootUrl + 'auth';
                var userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString() // !!!!toString!!!!
                };

                var selfUserPersister = this;
                requestModule.postJSON(url,userData, function (data) {
                    saveUserData.call(selfUserPersister, data);
                    success(data);
                }, error);
            },
            register: function (user, success, error) {
                var url = this.rootUrl + 'user';
                var userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };

                requestModule.postJSON(url, userData, success, error);
            },
            logout: function (success, error) {
                var url = this.rootUrl + 'user';
                var selfUserPersister = this;
                var header = { 'X-SessionKey': this.sessionKey };
                requestModule.putJSON(url, header, function (data) {
                    clearUserData.call(selfUserPersister);
                    success(data);
                }, error);


            }
        };

        // Helpers
        function saveUserData(userData) {
            // You should use saveUserData.call(this, data);
            localStorage.setItem('username', userData.username);
            localStorage.setItem('sessionKey', userData.sessionKey);
            this.username = userData.username;
            this.sessionKey = userData.sessionKey;
        }

        function clearUserData(){
            // You should use clearUserData.call(this);
            localStorage.removeItem('username');
            localStorage.removeItem('sessionKey');
            this.username = '';
            this.sessionKey = '';
        }

        return UserPersister
    }());
    return UserPersister
});