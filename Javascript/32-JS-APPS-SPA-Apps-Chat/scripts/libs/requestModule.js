define(['jquery'], function () {
    var requestModule = (function () {

        function getJSON(url, success, error) {
            $.ajax({
                url: url,
                type: 'GET',
                contentType: 'application/json',
                timeout: 10000,
                success: success,
                error: error
            })
        }

        function postJSON(url, data, success, error) {
            $.ajax({
                url: url,
                type: 'POST',
                contentType: 'application/json',
                timeout: 5000,
                data: JSON.stringify(data),
                success: success,
                error: error
            })
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON
        }
    }());
    return requestModule;
});