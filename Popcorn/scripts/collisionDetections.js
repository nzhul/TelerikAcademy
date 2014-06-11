function ballHitBrickDetection(ball) {
    var currentStage = ball.getStage(),
        collisionObject = currentStage.getIntersection({ x: ball.getX(), y: ball.getY() });

    if (collisionObject) {
        if(collisionObject.getAttr('gameObjectType') == 'brick'){
            playSingleSound('explosionSound');
            collisionObject.remove();
            explode();
            ball.attrs.directionY *= -1;
            if(collisionObject.getAttr('isObjectProducer')){
                spawnGift(collisionObject.getAttr('x'),collisionObject.getAttr('y'),collisionObject.getAttr('fill'), collisionObject.getAttr('producedObjectType'))
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
        //else {
        //    GAME_OVER = true;
        //}
    }
}