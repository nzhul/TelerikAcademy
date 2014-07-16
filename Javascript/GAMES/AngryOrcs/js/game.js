define(['jquery', 'levels'], function ($, levels) {
    var Game = (function () {
        function Game() {
            this.canvas;
            this.context;
            this.allGameLayers;
            this.levelSelectionLayer;
            this.mainMenuLayer;
            this.currentLevel;
            this.score;
        }

        Game.prototype = {
            init: function () {
                var selfGame = this;
                // Initialize objects
                var Levels = new levels(selfGame);
                Levels.addLevel({
                    foreground: 'desert-foreground',
                    background: 'clouds-background',
                    entities: []
                }).addLevel({
                    foreground: 'desert-foreground',
                    background: 'clouds-background',
                    entities: []
                }).addLevel({
                    foreground: 'desert-foreground',
                    background: 'clouds-background',
                    entities: []
                }).init();


                // Hide all game layers and display the main Menu
                this.allGameLayers = $('.gameLayer').hide();
                this.mainMenuLayer = $('#mainMenu').show();
                this.levelSelectionLayer = $('#levelSelectScreen');
                this.canvas = $('#gamecanvas')[0];
                this.context = this.canvas.getContext('2d');

                // Add Event Listeners to the buttons in the main menu
                var playBtn = document.getElementById('playBtn');
                playBtn.addEventListener('click', function () {
                    selfGame.showLevelScreen();
                });
                return this;
            },
            showLevelScreen: function () {
                this.allGameLayers.hide();
                this.levelSelectionLayer.fadeIn();
            }
        };
        return Game;
    }());
    return Game;
});