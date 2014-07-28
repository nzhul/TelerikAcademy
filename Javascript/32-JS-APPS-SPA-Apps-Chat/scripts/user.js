define([], function () {
    var User = (function () {

        function User() {
            this.username = localStorage.getItem('username');
        }

        User.prototype = {
            login: function (username) {
                localStorage.setItem('username', username);
                this.username = username;
            },
            logout: function () {
                localStorage.removeItem('username');
                this.username = '';
            },
            isLoggedIn: function () {
                if(this.username != null){
                    return true;
                }
            }
        };

        return User
    }());
    return User
});