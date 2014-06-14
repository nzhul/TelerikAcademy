var endGame = function () {
    var currentName = prompt('Your socre is: '+ playerScore + '! Please enter your name:');
    if (currentName === '') {
        currentName = 'Anonymous';
    }
    else if (currentName === null) {
        currentName = 'Anonymous';
    }
    localStorage.setItem(playerScore, currentName);
    updateTopScores();
}
var updateTopScores = function () {
    clearTopScores();
    var sortedScores = Object.keys(localStorage).sort(function (a, b) {
        return b - a;
    });

    for (var i = 0; i < TOP_SCORES_TO_DISPLAY; i++) {
        var currentScore = sortedScores[i];
        if (currentScore && currentScore !== undefined) {
            var scoreDiv = document.createElement('div');
            scoreDiv.innerText = localStorage[currentScore] + ' : ' + currentScore;
            topScoresDiv.appendChild(scoreDiv);
        }
    }
}
var clearTopScores = function () {
    while (topScoresDiv.firstChild) {
        topScoresDiv.removeChild(topScoresDiv.firstChild);
    }
}

var updateScore = function () {
    liveScoreElement.innerText = playerScore;
}
