define(['async!https://maps.googleapis.com/maps/api/js?key=AIzaSyABndy6yDZMbQOxz1QibrPstN6MV3mTXuk', 'jquery'], function () {

    function updateUI(city) {
        var cityListRoot = document.getElementById('cityList');
        var newLiElement = document.createElement('li');
        var selfEngine = this;

        var lat = city.results[0].geometry.location.lat;
        var lng = city.results[0].geometry.location.lng;

        newLiElement.innerHTML = city.results[0].formatted_address + ' <br/>' +
            '<span class="details">Latitude: ' + lat + ' | Longitude: ' + lng + '<span>';
        newLiElement.addEventListener('click', function () {
            // TODO: Do more stuff here
            console.log('city clicked');
            var pos = new google.maps.LatLng(lat, lng);
            selfEngine.map.panTo(pos);
            var content = 'Error: The Geolocation service failed.';
            $.ajax({
                type: "GET",
                url: "http://en.wikipedia.org/w/api.php?action=parse&format=json&prop=text&section=0&page="+city.results[0].address_components[0].short_name+"&callback=?",
                contentType: "application/json; charset=utf-8",
                async: true,
                dataType: "json",
                beforeSend: function () {
                    $(newLiElement).append('<br/><img id="loader" src="img/ajax-loader.gif"/>');
                },
                success: function (data, textStatus, jqXHR) {

                    var markup = data.parse.text["*"];
                    var blurb = $('<div></div>').html(markup);

                    // remove links as they will not work
                    blurb.find('a').each(function() { $(this).replaceWith($(this).html()); });

                    // remove any references
                    blurb.find('sup').remove();

                    // remove cite error
                    blurb.find('.mw-ext-cite-error').remove();
                    content = $(blurb).find('p');

                    var options = {
                        map: selfEngine.map,
                        position: pos,
                        content: content[0]
                    };

                    var infowindow = new google.maps.InfoWindow(options);
                    selfEngine.map.setCenter(options.position);
                    $('#loader').remove();

                },
                error: function (errorMessage) {
                }
            });
            // https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=42.6977082,23.3218675&radius=500&key=AIzaSyABndy6yDZMbQOxz1QibrPstN6MV3mTXuk
        });

        cityListRoot.appendChild(newLiElement);
    }

    function initCityInput() {
        var addCityBtn = document.getElementById('addCityBtn');
        var selfEngine = this;
        addCityBtn.addEventListener('click', function () {
            var cityInputValue = document.getElementById('cityInput').value;
            selfEngine.addCity(cityInputValue);
            console.log('Btn clicked');
        });
    }
    
    var Engine = (function () {
        function Engine() {
            this.map;
            this.cities = [];
        }

        Engine.prototype = {
            init: function () {
                var mapOptions = {
                    center: new google.maps.LatLng(42.7000, 23.3333),
                    zoom: 6
                };
                this.map = new google.maps.Map(document.getElementById("mapRoot"), mapOptions);
                google.maps.event.addDomListener(window, 'load', this.init);
                initCityInput.call(this, '');
                return this;
            },
            addCity: function (city) {
                var selfEngine = this;
                $.getJSON( "https://maps.googleapis.com/maps/api/geocode/json?address="+city, function( data ) {
                    if(data.status === "OK"){
                        selfEngine.cities.push(data);
                        updateUI.call(selfEngine,data);
                        console.log(data);
                    }
                });
            }
        };

        return Engine
    }());
    return Engine
});