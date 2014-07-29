define(['jquery', 'mainPersister', 'underscore'], function ($, MainPersister, _) {
    var MainController = (function () {

        function MainController(rootUrl) {
            this.persister = new MainPersister(rootUrl);
            this.postData = [];
        }

        MainController.prototype = {
            loadUI: function (selector) {
                this.loginFormLayer = document.getElementById('loginFormLayer');
                this.registerFormLayer = document.getElementById('registerFormLayer');
                this.crowdShareLayer = document.getElementById('crowdShareLayer');
                this.LayerCollection = [this.loginFormLayer,this.registerFormLayer, this.crowdShareLayer];

                if(this.persister.isUserLoggedIn()){
                    this.loadCrowdShareLayer(selector);
                } else {
                    this.loadLoginFormLayer(selector);
                }
                this.attachUIEventHandlers(selector);
            },
            loadLoginFormLayer: function (selector) {
                hideAllLayers(this.LayerCollection);
                this.loginFormLayer.style.display = 'block';
            },
            loadCrowdShareLayer: function (selector) {

                var usernameUI = document.getElementById('username-ui');
                usernameUI.innerHTML = this.persister.user.username;

                this.updatePosts();

                hideAllLayers(this.LayerCollection);
                this.crowdShareLayer.style.display = 'block';
            },
            updatePosts: function (options) {
                var self = this;
                var options = options || {
                    filterByUser: '',
                    filterByPattern: ''
                };
                if(options.filterByUser.length > 1 && options.filterByPattern.length > 1){
                    // Do double filtering
                    this.persister.posts.filterByUserAndPattern(options.filterByUser, options.filterByPattern,function (data) {
                        renderPosts(data);
                        self.postData = data;
                    }, function () {
                        console.error('Error getting the posts from the server');
                    });
                } else if(options.filterByUser.length > 1 && options.filterByPattern.length < 1) {
                    // Do user filtering
                    this.persister.posts.filterByUser(options.filterByUser,function (data) {
                        renderPosts(data);
                        self.postData = data;
                    }, function () {
                        console.error('Error getting the posts from the server');
                    });
                } else if(options.filterByUser.length < 1 && options.filterByPattern.length > 1){
                    // Do pattern filtering
                    this.persister.posts.filterByPattern(options.filterByPattern,function (data) {
                        renderPosts(data);
                        self.postData = data;
                    }, function () {
                        console.error('Error getting the posts from the server');
                    });
                } else if(options.filterByUser.length < 1 && options.filterByPattern.length < 1) {
                    this.persister.posts.getAllPosts(function (data) {
                        renderPosts(data);
                        self.postData = data;
                    }, function () {
                        console.error('Error getting the posts from the server');
                    });
                }
            },
            attachUIEventHandlers: function (selector) {
                var wrapper = $(selector);
                var self = this;
                wrapper.on('click', '#btn-show-register-layer', function () {
                    hideAllLayers(self.LayerCollection);
                    self.registerFormLayer.style.display = 'block';
                });
                wrapper.on('click', '#btn-show-login-layer', function () {
                    hideAllLayers(self.LayerCollection);
                    self.loginFormLayer.style.display = 'block';
                });
                wrapper.on('click', '#btn-submit-register', function () {
                    // if the user is succ registered he is redirected
                    // to the loginForm with success message

                    var user = {
                        username: $('#tb-register-username').val(),
                        password: $('#tb-register-password').val()
                    };

                    self.persister.user.register(user, function (data) {
                        // Succ register
                        //TODO: append Success message before the login Form
                        hideAllLayers(self.LayerCollection);
                        self.loginFormLayer.style.display = 'block';
                    }, function (err) {
                        //TODO: implement error handling - Username allready exists and
                        // username length 6-40 characters
                        wrapper.html('Fuck!!');
                        console.log(err);
                    });
                    return false;
                });
                wrapper.on('click', '#btn-submit-login', function () {
                    // If success login the user is redirected to
                    // the application layer

                    var user = {
                        username: $('#tb-login-username').val(),
                        password: $('#tb-login-password').val()
                    };

                    self.persister.user.login(user, function (data) {
                        // Succ register
                        //TODO: append Success message before the login Form
                        self.loadCrowdShareLayer();
                    }, function (err) {
                        //TODO: implement error handling - Invalid username or password
                        wrapper.html('Fuck!!');
                        console.log(err);
                    });
                    return false;
                });

                wrapper.on('click', '#btn-logout', function () {
                    self.persister.user.logout(function (data) {
                        self.loadLoginFormLayer();
                    }, function (err) {
                        wrapper.html('Error logout');
                        console.log(err);
                    });
                    return false;
                });

                wrapper.on('click', '#btn-submit-new-post', function () {
                    var postData = {
                        title: $('#tb-post-title').val(),
                        body: $('#tb-post-content').val()
                    };
                    self.persister.posts.submitNewPost(postData, function (data) {
                        self.updatePosts();
                        $('#tb-post-title').val('');
                        $('#tb-post-content').val('');
                        console.log('succ post');
                        console.log(data);
                    }, function (err) {
                        console.log('err post');
                        console.log(err);
                    });
                    return false;
                });

                wrapper.on('click', '#btn-filter', function () {
                    var options = {
                        filterByUser: $('#tb-filter-user').val(),
                        filterByPattern: $('#tb-filter-pattern').val()
                    };
                    self.updatePosts(options);
                    return false;
                });

                wrapper.on('change', '#sb-sort', function () {
                    //debugger;
                    var sortProperty = $('#sb-sort').val();
                    var isDescending = $('#desc').is(":checked");
                    var sortedPosts = [];
                    if(sortProperty != 'default'){
                        if(isDescending){
                            sortedPosts = _.sortBy(self.postData, sortProperty).reverse();
                        } else {
                            sortedPosts = _.sortBy(self.postData, sortProperty);
                        }
                        renderPosts(sortedPosts);
                        return false;
                    }
                });

                // Some pagination
                self.pageSize = 5;

                showPage = function(page) {
                    $(".post").hide();
                    $(".post").each(function(n) {
                        if (n >= self.pageSize * (page - 1) && n < self.pageSize * page)
                            $(this).show();
                    });
                }



                $("#pagin li a").click(function() {
                    $("#pagin li a").removeClass("current");
                    $(this).addClass("current");
                    showPage(parseInt($(this).text()))
                });

                // Pagination end
            }
        };

        // Helpers

        function renderPosts(postsData) {
            var allPosts = postsData;

            var postsBox = document.getElementById('posts-box');
            removeChildNodes(postsBox);

            var postTemplate = document.createElement('div');
            postTemplate.className = 'post';
            var postTitleTemplate = document.createElement('h2');
            var postInfoBoxTemplate = document.createElement('p');
            postInfoBoxTemplate.className = 'postInfo';
            var postContentTemplate = document.createElement('p');
            var fragment = document.createDocumentFragment();


            for (var i = 0; i < allPosts.length; i++) {
                var currPost = postTemplate.cloneNode(true);
                var currPostTitle = postTitleTemplate.cloneNode(true);
                var currPostInfoBox = postInfoBoxTemplate.cloneNode(true);
                var currPostContent = postContentTemplate.cloneNode(true);

                currPostTitle.innerHTML = allPosts[i].title;
                currPostInfoBox.innerHTML = 'Author: <strong>'+
                    allPosts[i].user.username+'</strong> | Date: <span>'+
                    allPosts[i].postDate+'</span>';
                currPostContent.innerHTML = allPosts[i].body;

                currPost.appendChild(currPostTitle);
                currPost.appendChild(currPostInfoBox);
                currPost.appendChild(currPostContent);
                fragment.appendChild(currPost);
            }

            postsBox.appendChild(fragment);

            // This will generate the pages dynamicaly but not enough time to complete
//            for (var i = 0; i < postsData.length; i++) {
//                if(i % this.pageSize === 0 ){
//                    $('#pagin').append('<li><a href="#">'+i+'</a></li>');
//                }
//            }
            showPage(1);
        }


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