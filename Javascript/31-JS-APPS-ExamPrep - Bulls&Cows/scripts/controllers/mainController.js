define(['jquery', 'mainPersister'], function ($, MainPersister) {
    var MainController = (function () {

        function MainController(rootUrl) {
            this.persister = new MainPersister(rootUrl);
            console.log(this.persister);
        }

        MainController.prototype = {
            loadUI: function (selector) {
                this.loginForm = document.getElementById('loginForm');
                this.gameUI = document.getElementById('gameUI');
                this.UICollection = [this.loginForm, this.gameUI];

                if(this.persister.isUserLoggedIn()){
                    this.loadGameUI(selector);
                } else {
                    this.loadLoginFormUI(selector);
                }
                this.attachUIEventHandlers(selector);
            },
            loadLoginFormUI: function () {
                hideAllLayers(this.UICollection);
                this.loginForm.style.display = 'block';
            },
            loadGameUI: function () {
                hideAllLayers(this.UICollection);
                this.gameUI.style.display = 'block';

                var activeNickname = this.persister.user.nickname;
                var usernameUI = document.getElementById('user-nickname');
                usernameUI.innerHTML = 'Hello, ' + activeNickname;

                this.persister.game.open(function (games) {
                    var openGamesRoot = document.getElementById('open-games-container');
                    var gameList = document.createElement('ul');
                    var gameElement = document.createElement('li');
                    var fragment = document.createDocumentFragment();

                    removeChildNodes(openGamesRoot); // Fix the buf when we have multiple login/logouts
                    for (var i = 0; i < games.length; i++) {
                        var currentGame = games[i];
                        var currentGameElement = gameElement.cloneNode(true);
                        currentGameElement.setAttribute('data-game-id', currentGame.id);
                        currentGameElement.innerHTML = currentGame.title;
                        fragment.appendChild(currentGameElement);
                    }
                    gameList.appendChild(fragment);
                    openGamesRoot.appendChild(gameList);
                });

                this.persister.game.myActive(function (games) {
                    var activeGamesRoot = document.getElementById('active-games-container');
                    var gameList = document.createElement('ul');
                    var gameElement = document.createElement('li');
                    var fragment = document.createDocumentFragment();
                    removeChildNodes(activeGamesRoot); // Fix the buf when we have multiple login/logouts
                    for (var i = 0; i < games.length; i++) {
                        var currentGame = games[i];
                        var currentGameElement = gameElement.cloneNode(true);
                        currentGameElement.innerHTML = currentGame.title;
                        fragment.appendChild(currentGameElement);
                    }
                    gameList.appendChild(fragment);
                    activeGamesRoot.appendChild(gameList);

                });
            },
            attachUIEventHandlers: function (selector) {

                // We will use this JQuery syntax so we can attach all events
                // In one places, even if the element is not yet created
                // wrapper.on('click', '#btn-login', function () {

                var wrapper = $(selector);
                var self = this;
                wrapper.on('click', '#btn-login', function () {
                    var user = {
                        username: $('#tb-login-username').val(),
                        password: $('#tb-login-password').val()
                    };

                    self.persister.user.login(user, function (data) {
                        self.loadGameUI();
                    }, function (err) {
                        wrapper.html('Fuck!!');
                    });

                    return false;
                });

                wrapper.on('click', '#btn-register', function () {
                    
                });

                wrapper.on('click', '#btn-logout', function () {
                    self.persister.user.logout(function () {
                        self.loadLoginFormUI();
                    }, function () {
                        wrapper.html('Error while loging out');
                    })
                });

                wrapper.on('click', '#open-games-container li', function () {
                    $('#game-join-inputs').remove();
                    var html = '<div id="game-join-inputs">Number: <input type="text" id="tb-game-number" />' +
                        'Password: <input type="text" id="tb-game-pass" />' +
                        '<button id="btn-join-game">Join</button></div>';
                    $(this).after(html);
                });

                wrapper.on('click', '#btn-join-game', function () {
                    //debugger;
                    var game = {
                        number: $('#tb-game-number').val(),
                        gameId: $(this).parents('#game-join-inputs').prev().attr('data-game-id')
                    }
                    var password = $('#tb-game-pass').val();
                    if(password){
                        game.password = password;
                    }

                    self.persister.game.join(game, function () {
                        console.log('success joining the game');
                    }, function () {
                        console.log('error joining the game')
                    });
                });
            }
        };

        // Helpers
        function hideAllLayers(UICollection) {
            for (var i = 0; i < UICollection.length; i++) {
                UICollection[i].style.display = 'none';
            }
        }
        function removeChildNodes(parentNode) {
            while (parentNode.firstChild) {
                parentNode.removeChild(parentNode.firstChild);
            }
        }

        return MainController
    }());
    return MainController
});