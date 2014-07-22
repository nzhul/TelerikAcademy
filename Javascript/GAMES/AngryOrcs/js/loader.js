define([], function () {
    var instance;
    var Loader = (function () {
        function Loader() {
            this.loaded = true;
            this.loadedCount = 0; // Assets that have been loaded so far
            this.totalCount = 0; // Total number of assets that need to be loaded
            this.soundFileExtension;
            this.loadingScreen = document.getElementById('loadingScreen');
            this.loadingMessage = document.getElementById('loadingMessage');
        }

        Loader.prototype = {
            init: function () {
                // Check for sound support
                var mp3Support, oggSupport;
                var audio = document.createElement('audio');
                if(audio.canPlayType){
                    // Currently canPlayTime() returns: "", "maybe" or "probably"
                    mp3Support = "" != audio.canPlayType('audio/mpeg');
                    oggSupport = "" != audio.canPlayType('audio/ogg; codecs="vorbis"');
                } else{
                    // The audio tag is not supported
                    mp3Support = false;
                    oggSupport = false;
                }

                // Check for ogg, then mp3, adn finally set soundfileExtension to undefined
                this.soundFileExtension = oggSupport?".ogg":mp3Support?".mp3":undefined;
            },
            loadImage: function (url) {
                this.totalCount++;
                this.loaded = false;
                this.loadingScreen.style.display = 'block';
                var image = new Image();
                image.src = url;
                image.onload = this.itemLoaded;
                return image;
            },
            //soundFileExtension: ".ogg",
            loadSound: function (url) {
                this.totalCount++;
                this.loaded = false;
                this.loadingScreen.style.display = 'block';
                var audio = new Audio();
                audio.src = url + this.soundFileExtension;
                // TODO: probably i will need to use CALL on this event listener
                audio.addEventListener('canplaythrough', this.itemLoaded, false);
                return audio;
            },
            itemLoaded: function () {
                this.loadedCount++;
                this.loadingMessage.innerHTML = 'Loaded ' + this.loadedCount + ' of ' + this.totalCount;
                if(this.loadedCount === this.totalCount){
                    // Loader has loaded completely ...
                    this.loaded = true;
                    // Hide the loading screen
                    this.loadingScreen.style.display = 'none';
                    // and call the loader.onload method if it exists
                    if(this.onload){
                        this.onload();
                        this.onload = undefined;
                    }
                }
            }
        };


        return {
            getInstance: function () {
                if ( !instance ) {
                    instance = new Loader();
                }
                return instance;
            }
        };
    }());
    
    return Loader
});