define(['jquery'], function () {
    var requestModule = (function () {

        function getJSON(url, success, error, header) {
            $.ajax({
                url: url,
                type: 'GET',
                contentType: 'application/json',
                headers: header || '',
                timeout: 5000,
                success: success,
                error: error
            })
        }

        function postJSON(url, data, success, error, header) {
            $.ajax({
                url: url,
                type: 'POST',
                contentType: 'application/json',
                timeout: 5000,
                headers: header || '',
                data: JSON.stringify(data),
                success: success,
                error: error
            })
        }

        function putJSON(url, header, success, error) {
            $.ajax({
                url: url,
                type: 'PUT',
                contentType: 'application/json',
                timeout: 5000,
                headers: header,
                success: success,
                error: error
            })
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            putJSON: putJSON
        }
    }());
    return requestModule;
});