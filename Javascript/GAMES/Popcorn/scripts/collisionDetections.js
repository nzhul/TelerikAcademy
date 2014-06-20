function ballHitBrickDetection(ball) {
    var currentStage = ball.getStage(),
        collisionObject = currentStage.getIntersection({ x: ball.getX(), y: ball.getY() });

    if (collisionObject) {
        if (collisionObject.getAttr('gameObjectType') == 'brick') {
            playSingleSound('explosionSound');
            collisionObject.remove();
            levelBrickCount -= 1;
            explode();
            playerScore += 10 * getRandomNumber(25, 75);
            updateScore();
            ball.attrs.directionY *= -1;
            if (collisionObject.getAttr('isObjectProducer')) {
                var newGift = spawnGift(collisionObject.getAttr('x'), collisionObject.getAttr('y'), collisionObject.getAttr('fill'), collisionObject.getAttr('producedObjectType'));
                var moveGiftDown = newGift.attrs.move;
                moveGiftDown();
            }
        }
    }

    function getRandomNumber(min, max) {
        var randomNumber = Math.floor(Math.random() * (max - min + 1)) + min;
        return randomNumber;
    }
}

function bulletHitBrickCollision(bullet) {
    var currentStage = bullet.getStage()
    if (currentStage) {
        var collisionObject = currentStage.getIntersection({ x: bullet.getX(), y: bullet.getY() });

        if (collisionObject) {
            if (collisionObject.getAttr('gameObjectType') == 'brick') {
                bullet.remove();
                levelBrickCount -= 1;
                playerScore += 10;
                playSingleSound('explosionSound');
                explode(bullet.getX(), bullet.getY());
                updateScore();
                if (collisionObject.getAttr('isObjectProducer')) {
                    var newGift = spawnGift(collisionObject.getAttr('x'), collisionObject.getAttr('y'), collisionObject.getAttr('fill'), collisionObject.getAttr('producedObjectType'));
                    var moveGiftDown = newGift.attrs.move;
                    moveGiftDown();
                }
                collisionObject.remove();
            }
        }
    }
}

//Can add this method to ball or circle object. Now it is just for testing.
function ballHitWallDetection(ball) {
    var ballX = ball.attrs.x,
        ballY = ball.attrs.y,
        ballRadius = ball.attrs.radius;

    if (ballX + ballRadius >= stage.attrs.width) {
        ball.attrs.directionX *= -1;
    }
    else if (ballX <= ballRadius) {
        ball.attrs.directionX *= -1;
    }
    //if (self.y + self.radius > canvasH) {
    //    self.directionY = -directionY;
    //}
    if (ballY <= ballRadius) {
        ball.attrs.directionY *= -1;
    }
    else if (ballY + ballRadius >= PADDLE_START_Y) {
        if (ballX >= aPaddle.attrs.x && ballX <= aPaddle.attrs.x + PADDLE_WIDTH) {
            ball.attrs.directionY *= -1;
            ball.attrs.directionX += calcBallAngle(ball);
            playSingleSound('paddleReflectionSound');
            if (ball.attrs.directionX > MAX_X_SPEED) {
                ball.attrs.directionX = MAX_X_SPEED;
            }
            else if (ball.attrs.directionX < -MAX_X_SPEED) {
                ball.attrs.directionX = -MAX_X_SPEED;
            }

        }
        else if (ballY >= STAGE_HEIGHT) {
            anim.stop();
            if (isAnimationRunning) {
                endGame();
                gameOverText.animate(textAnimBigger);
                //Add label to indicate restart of the game 
                var restartGameLabel = document.getElementById('restart-game');
                restartGameLabel.style.display = 'block';
            }

            var canvases = document.getElementsByTagName('canvas');
            for (var i = 0; i < canvases.length; i += 1) {
                canvases[i].style.zIndex = '1';
            }

        }
    }
}
