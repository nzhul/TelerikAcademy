define(['requestModule', 'cryptojs'], function (requestModule) {
    var UserPersister = (function () {

        function UserPersister(rootUrl) {
            this.rootUrl = rootUrl + 'user/';
            this.nickname = localStorage.getItem('nickname');
            this.sessionKey = localStorage.getItem('sessionKey');
        }

        UserPersister.prototype = {
            login: function (user, success, error) {
                var url = this.rootUrl + 'login';
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
                var url = this.rootUrl + 'register';
                var userData = {
                    username: user.username,
                    nickname: user.nickname,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };

                requestModule.postJSON(url, userData, success, error);
            },
            logout: function (success, error) {
                //api/user/logout/sessionKey
                var url = this.rootUrl + 'logout/' + this.sessionKey;
                var selfUserPersister = this;
                requestModule.getJSON(url, function (data) {
                    clearUserData.call(selfUserPersister);
                    success(data);
                }, function () {
                    
                })


            },
            scores: function (success, error) {
                
            }
        };

        // Helpers
        function saveUserData(userData) {
            // You should use saveUserData.call(this, data);
            localStorage.setItem('nickname', userData.nickname);
            localStorage.setItem('sessionKey', userData.sessionKey);
            this.nickname = userData.nickname;
            this.sessionKey = userData.sessionKey;
        }

        function clearUserData(){
            // You should use clearUserData.call(this);
            localStorage.removeItem('nickname');
            localStorage.removeItem('sessionKey');
            this.nickname = '';
            this.sessionKey = '';
        }

        return UserPersister
    }());
    return UserPersister
});