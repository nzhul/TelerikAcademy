define(['requestModule', 'cryptojs'], function (requestModule) {
    var UserPersister = (function () {

        function saveUserData(userData) {
            localStorage.setItem('nickname', userData.nickname);
            localStorage.setItem('nickname', userData.authCode);
        }

        function UserPersister(rootUrl) {
            this.rootUrl = rootUrl + 'user/';
        }

        UserPersister.prototype = {
            login: function (user, success, error) {
                var url = this.rootUrl + 'login';
                var userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString() // !!!!toString!!!!
                };

                requestModule.postJSON(url,userData, function (data) {
                    saveUserData(data);
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
                
            },
            scores: function (success, error) {
                
            }
        };

        return UserPersister
    }());
    return UserPersister
});