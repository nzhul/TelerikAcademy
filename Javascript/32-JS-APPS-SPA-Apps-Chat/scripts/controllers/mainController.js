define(['user', 'jquery', 'requestModule'], function (User, $, requestModule) {
    var MainController = (function () {
        function MainController(rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new User();
        }

        MainController.prototype = {
            loadUI: function (selector) {
                this.loginFormUI = document.getElementById('loginForm');
                this.chatUI = document.getElementById('chatBox');
                this.usernameUi = document.getElementById('usernameUi');
                this.UICollection = [this.loginFormUI, this.chatUI];
                if(this.user.isLoggedIn()){
                    this.loadChatUI(selector);
                } else {
                    this.loadLoginUI(selector);
                }
                this.attachEventHandlers(selector);
            },
            loadLoginUI: function () {
                hideAllLayers(this.UICollection);
                this.loginFormUI.style.display = 'block';
            },
            loadChatUI: function () {
                this.usernameUi.innerHTML = localStorage.getItem('username');

                var messagesList = document.getElementById('messagesList');
                var authorPostTemplate = document.createElement('li');
                var authorNameTemplate = document.createElement('strong');
                var fragment = document.createDocumentFragment();

                //setInterval(function(){alert("Hello")}, 3000);

                requestModule.getJSON(this.rootUrl, function (data) {
                    console.log(data);

                    // Get only the last 200 posts from the result
                    data = data.slice(data.length - 200, data.length);

                    for (var i = data.length - 1; i >= 0; i--) {
                        var currentLiElement = authorPostTemplate.cloneNode(true);
                        var currentAuthorElement = authorNameTemplate.cloneNode(true);
                        currentAuthorElement.innerHTML = data[i].by;
                        currentLiElement.appendChild(currentAuthorElement);
                        if(!(data[i].text.length >= 2 && data[i].text.length <= 500)){
                            continue;
                        }
                        currentLiElement.innerHTML += ': ' + data[i].text;
                        fragment.appendChild(currentLiElement);
                    }
                    messagesList.appendChild(fragment);
                }, function (err) {
                    console.log(err);
                });


                hideAllLayers(this.UICollection);
                this.chatUI.style.display = 'block';
            },
            attachEventHandlers: function (selector) {
                var wrapper = $(selector);
                var self = this;

                wrapper.on('click', '#btn-login', function () {
                    var usernameInput = document.getElementById('tb-login-username').value;
                    if(usernameInput.length >= 3 && usernameInput.length <= 20){
                        self.user.login(usernameInput);
                        self.loadChatUI();
                    } else {
                        console.log('Invalid username: min: 3; max: 20');
                    }
                    return false;
                });

                wrapper.on('click', '#btn-logout', function () {
                    self.user.logout();
                    hideAllLayers(self.UICollection);
                    self.loginFormUI.style.display = 'block';
                    return false;
                });

                wrapper.on('click', '#btn-message-submit', function () {
                    var data = {
                        user: self.user.username,
                        text: $('#tb-chat-submit').val()
                    }
                    requestModule.postJSON(self.rootUrl, data, function () {
                       console.log('message success send');
                        var messagesList = document.getElementById('messagesList');
                        var newPost = $('<li/>').html('<strong>'+self.user.username+'</strong>: ' + data.text);
                        $(messagesList).prepend(newPost);
                    }, function () {
                       console.log('Error sending message');
                    });
                    return false;
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

        return MainController;
    }());
    return MainController;
});