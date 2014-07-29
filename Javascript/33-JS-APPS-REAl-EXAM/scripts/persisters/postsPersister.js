define(['requestModule'], function (requestModule) {
    var PostsPersister = (function () {

        function PostsPersister(rootUrl) {
            this.rootUrl = rootUrl;
            this.username = localStorage.getItem('username');
            this.sessionKey = localStorage.getItem('sessionKey');
        }

        PostsPersister.prototype = {
            getAllPosts: function (success, error) {
                var url = this.rootUrl + 'post';
                requestModule.getJSON(url, success, error);
            },
            submitNewPost: function (postData, success, error ) {
                var url = this.rootUrl + 'post';
                var header = { 'X-SessionKey': this.sessionKey };
                requestModule.postJSON(url, postData, success, error, header);
            },
            filterByUser: function (user, success, error) {
                var url = this.rootUrl + 'post' + '?user=' + user;
                requestModule.getJSON(url, success, error);
            },
            filterByPattern: function (pattern, success, error) {
                var url = this.rootUrl + 'post' + '?pattern=' + pattern;
                requestModule.getJSON(url, success, error);
            },
            filterByUserAndPattern: function (user, pattern, success, error) {
                var url = this.rootUrl + 'post' + '?pattern='+pattern+'&user=' + user;
                requestModule.getJSON(url, success, error);
            }
        };

        return PostsPersister
    }());
    return PostsPersister
});