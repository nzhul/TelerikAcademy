define(['chance'], function (Chance) {
    var Chance = new Chance();

    // Helpers
    function hideAllUI(UICollection) {
        for (var i = 0; i < UICollection.length; i++) {
            UICollection[i].style.display = 'none';
        }
    }

    function remove(element)
    {
        return (element.parentNode.removeChild(element));
    }

    function updateProgressUI(resultObject) {
        var ramUI = document.getElementById('ramCountUI');
        var sheepUI = document.getElementById('sheepCountUI');

        ramUI.innerHTML = resultObject.ramCount;
        sheepUI.innerHTML = resultObject.sheepCount;
    }

    function updateWinUI(turnCount) {
        var turnsCountUI = document.getElementById('turnsCountUI');
        turnsCountUI.innerHTML = turnCount;
    }

    function sortUsers(users, sortBy) {
        users.sort(function(userA,userB){return userA[sortBy] - userB[sortBy]; });
    }

    function generateScoreRows(users) {
        var scoreTable = document.getElementById('scoreBoard');
        var scoreTableBody = scoreTable.getElementsByTagName('tbody')[0];

        // Clear the old rows if any
        var allTableRows = scoreTableBody.getElementsByTagName('tr');
        if (allTableRows !== null) {
            var rowCount = allTableRows.length;
            for (var i = 0; i < rowCount; i++) {
                remove(allTableRows[0]);
            }
        }

        //Generate new rows
        sortUsers(users, 'score');
        var tableRow = document.createElement('tr');
        var tableData = document.createElement('td');

        var fragment = document.createDocumentFragment();
        for (var i = 0; i < users.length; i++) {
            var currentUsername = tableData.cloneNode(true);
            var currentScore = tableData.cloneNode(true);
            var currentRow = tableRow.cloneNode(true);
            currentUsername.innerHTML = users[i].username;
            currentScore.innerHTML = users[i].score;
            currentRow.appendChild(currentUsername);
            currentRow.appendChild(currentScore);
            fragment.appendChild(currentRow);
        }
        scoreTableBody.appendChild(fragment);
    }

    function showScoreTable(users) {
        var tableRow = document.createElement('tr');
        var tableData = document.createElement('td');
        var scoreTable = document.getElementById('scoreBoard');

        if (users === null) {
            tableData.colSpan = 2;
            tableData.innerHTML = 'No Records';
            tableRow.appendChild(tableData);
            scoreTable.appendChild(tableRow);
        } else {
            generateScoreRows(users);
        }
    };

    // Helpers

    var Game = (function () {
        function Game() {
            this.gameTurn = 0;
            this.guessNumber = this.generateRandomNumber();
        }

        Game.prototype = {
            generateRandomNumber: function () {
                var computerNumber = '';
                var possibleDigits = ['0','1','2','3','4','5','6','7','8','9'];

                // Populate the first digit manually so there is no chance the digit to be Zero
                var index = Chance.integer({min: 1, max: possibleDigits.length - 1});
                computerNumber += possibleDigits[index];
                possibleDigits.splice(index, 1);

                for( var i = 0; i < 3; i++ ){
                    index = Chance.integer({min: 0, max: possibleDigits.length - 1});
                    computerNumber += possibleDigits[index];

                    // We remove the index after it is used, that way there cannot be repeating digits
                    possibleDigits.splice(index, 1);
                }

                this.guessNumber = computerNumber;
                return this.guessNumber;
            },
            compareInput: function (userNumber) {
                var computerNumber = this.guessNumber;
                var result = {
                    ramCount: 0,
                    sheepCount: 0
                };
                for (var i = 0; i < computerNumber.length; i++) {
                    for (var j = 0; j < userNumber.length; j++) {
                        if (computerNumber[i] === userNumber[j] && i === j) {
                            result.ramCount++;
                        } else if (computerNumber[i] === userNumber[j] && i !== j) {
                            result.sheepCount++;
                        }
                    }
                }
                return result;
            },
            startGame: function () {
                var gameRoot = document.getElementById('gameRoot');
                var guessBtn = document.getElementById('guessBtn');
                var warningBox = document.getElementById('warningBox');
                var progressBox = document.getElementById('progressBox');
                var UICollection = [warningBox, progressBox];
                var selfGame = this;
                guessBtn.addEventListener('click', function () {
                    var inputValue = document.getElementById('userInput').value;
                    if(inputValue.length === 4){
                        selfGame.gameTurn++;
                        hideAllUI(UICollection);
                        var guessResult = selfGame.compareInput(inputValue);
                        updateProgressUI(guessResult);
                        progressBox.style.display = 'block';
                        if(guessResult.ramCount === 4){
                            updateWinUI(selfGame.gameTurn);
                            gameRoot.style.display = 'none';
                            selfGame.processEndGame();
                        }
                    } else {
                        hideAllUI(UICollection);
                        warningBox.style.display = 'block';
                    }
                });
            },
            processEndGame: function () {
                var winBox = document.getElementById('winBox');
                var usernameWarning = document.getElementById('usernameWarning');
                winBox.style.display = 'block';
                showScoreTable(JSON.parse(localStorage.getItem('users')));
                var submitBtn = document.getElementById('submitBtn');
                var usernameInput = document.getElementById('username');
                var UICollection = [usernameWarning, submitBtn, usernameInput];
                var selfGame = this;
                submitBtn.addEventListener('click', function () {
                    var usernameInputValue = usernameInput.value;
                    if(usernameInputValue.length >= 2 && usernameInputValue.length <= 15){
                        hideAllUI(UICollection);

                        // Update the localStorage
                        var usersArray = [];
                        if(localStorage.getItem('users') !== null){
                            usersArray = JSON.parse(localStorage.getItem('users'));
                        }
                        usersArray.push({
                            username: usernameInputValue,
                            score: selfGame.gameTurn
                        });
                        localStorage.setItem('users', JSON.stringify(usersArray));
                        // Update the UI
                        showScoreTable(usersArray);

                    } else {
                        usernameWarning.style.display = 'block';
                    }
                })
            }

        };

        return Game
    }());
    return Game
});