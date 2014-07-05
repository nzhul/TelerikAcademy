var ui = (function () {
    var collisionText,
        scoreText;

    function UI (score, collisionStatus) {
        this.scoreValue = score || 0;
        this.collisionStatus =  collisionStatus || 'none';
    }

    UI.prototype = {
        initStatusBar: function () {
            // Create the status bar below the game
            var statusBox = document.createElement('div');
            statusBox.style.width = '495px';
            statusBox.style.height = '100px';
            statusBox.style.paddingLeft = '20px';
            statusBox.style.border = '1px solid black';

            collisionText = document.createElement('h3');
            collisionText.innerHTML = 'Collision: ' + this.collisionStatus;
            scoreText = document.createElement('h3');
            scoreText.innerHTML = 'Score: ' + this.scoreValue;

            statusBox.appendChild(collisionText);
            statusBox.appendChild(scoreText);

            document.body.appendChild(statusBox);
        },
        updateScore: function (value) {
            this.scoreValue += value;
            scoreText.innerHTML = 'Score: ' + this.scoreValue;
        },
        updateCollision: function (value) {
            this.collisionStatus = value;
            collisionText.innerHTML = 'Collision: ' + this.collisionStatus;
        }
    };

    return {
        getUI: function () {
            return new UI();
        }
    }
}());