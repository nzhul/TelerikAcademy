define(['jquery','q'], function () {
    var module = (function () {

        getHttpRequest = (function () {
            var xmlHttpFactories;
            xmlHttpFactories = [

                function () {
                    return new XMLHttpRequest();
                },
                function () {
                    return new ActiveXObject("Msxml3.XMLHTTP");
                },
                function () {
                    return new ActiveXObject("Msxml2.XMLHTTP.6.0");
                },
                function () {
                    return new ActiveXObject("Msxml2.XMLHTTP.3.0");
                },
                function () {
                    return new ActiveXObject("Msxml2.XMLHTTP");
                },
                function () {
                    return new ActiveXObject("Microsoft.XMLHTTP");
                }
            ];
            return function () {
                var xmlFactory, _i, _len;
                for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                    xmlFactory = xmlHttpFactories[_i];
                    try {
                        return xmlFactory();
                    } catch (_error) {

                    }
                }
                return null;
            };
        })();

        makeRequest = function (options) {
                var deferrer = Q.defer();

                var httpRequest = getHttpRequest();
                options = options || {};
                var requestUrl = options.url;
                var type = options.type || 'GET';
                var contentType = options.contentType || '';
                var accept = options.accept || '';
                var data = options.data || null;
                
                httpRequest.onreadystatechange = function () {
                    if (httpRequest.readyState === 4) {
                        switch(Math.floor(httpRequest.status / 100)){
                            case 2:
                                deferrer.resolve(httpRequest.responseText);
                                break;
                            default:
                                deferrer.reject(httpRequest.responseText);
                                break;
                        }
                    }
                }
            };
        return {
            getJSON: getJSON,
            postJSON: postJSON
        };
    }());
    return module;
});