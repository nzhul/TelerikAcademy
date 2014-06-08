var stage = new Kinetic.Stage({
    container: 'container',
    width: 411,
    height: 350
});

var layer = new Kinetic.Layer(),
    BALL_START_X = 50,
    BALL_START_Y = 50,
    BALL_RADIUS = 5,
    BALL_COLOR = 'red',
    DIRECTION_X = 2,
    DIRECTION_Y = 6,
    PADDLE_WIDTH = 100,
    PADDLE_HEIGHT = 5,
    PADDLE_COLOR = 'black',
    PADDLE_START_X = stage.getWidth() / 2 - PADDLE_WIDTH / 2,
    PADDLE_START_Y = stage.getHeight() - PADDLE_HEIGHT,
    GAME_OVER = false,
    RIGHT_DOWN = false,
    LEFT_DOWN = false,
    BRICK_WIDTH = 40,
    BRICK_HEIGHT = 15,
    BRICK_SPACING = 1,
    BRICK_COLOR = 'black',
    BRICK_ROW_COUNT = 4;

//containerRect gets the location of the gamefield in the window
var container = document.getElementById('container');
var containerX = Math.round(container.getBoundingClientRect().left);

Kinetic.Circle.prototype.directionX = null;
Kinetic.Circle.prototype.directionY = null;
Kinetic.Circle.prototype.move = function () {
    this.setY(this.attrs.y - this.attrs.directionY);
    this.setX(this.attrs.x - this.attrs.directionX);
    
    return this;
}

var aBall = new Kinetic.Circle({
    x: PADDLE_START_X + PADDLE_WIDTH / 2,
    y: PADDLE_START_Y - PADDLE_HEIGHT - BALL_RADIUS,
    radius: BALL_RADIUS,
    fill: BALL_COLOR,
    directionX: DIRECTION_X,
    directionY: DIRECTION_Y
}).setAttrs({
    type: 'regular'
});

var aPaddle = new Kinetic.Rect({
    x: PADDLE_START_X,
    y: PADDLE_START_Y,
    width: PADDLE_WIDTH,
    height: PADDLE_HEIGHT,
    fill: PADDLE_COLOR,
    listening: true
});

function initBricks(){
    var brickMatrix = [];
    var brickCount = stage.getWidth() / (BRICK_WIDTH + 2);
    var verticalShift = 0;
    var horizShift = 0;
    for (var i = 0; i < BRICK_ROW_COUNT; i++) {
        brickMatrix[i] = [];
        horizShift = 0;
        for (var j = 0; j < brickCount; j++) {
            var currentBrick = new Kinetic.Rect({
                x: 1 + horizShift,
                y: 1 + verticalShift,
                width: BRICK_WIDTH,
                height: BRICK_HEIGHT,
                fill: BRICK_COLOR,
                listening: true
            });
            brickMatrix[i][j] = (currentBrick);
            layer.add(currentBrick);
            horizShift += BRICK_WIDTH + 1;
        }
        verticalShift += BRICK_HEIGHT + 1;
    }
    return brickMatrix;
}

initBricks();


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
        if (ballX >= aPaddle.attrs.x && ballX <= aPaddle.attrs.x + PADDLE_WIDTH ) {
            ball.attrs.directionY *= -1;
        }
        //else {
        //    GAME_OVER = true;
        //}
    }
}

var prevDate = new Date().getTime();

window.addEventListener('mousemove', function (ev) {
    //Try to reduce mousecalls to fix animation lag on move
    var date = new Date().getTime();
    if (date - prevDate > 10) {
        
        var mouseX = ev.clientX;
        if (mouseX < containerX) {
            aPaddle.setPosition({
                x: 0,
                y: aPaddle.getY()
            });
        } 
        else if (mouseX + PADDLE_WIDTH < stage.getWidth() + containerX) {
            aPaddle.setPosition({
                x: ev.clientX - containerX,
                y: aPaddle.getY()
            });
        } 
        else {
            aPaddle.setPosition({
                x: stage.getWidth() - PADDLE_WIDTH,
                y: aPaddle.getY()
            });
        }
        prevDate = date;
    }
});

layer.add(aBall);
layer.add(aPaddle);
stage.add(layer);

var anim = new Kinetic.Animation(function (frame) {
   //For performance test
   //console.log(frame.frameRate); 
   
   aBall.move();
   ballHitWallDetection(aBall);
}, layer);
//
//function gameLoop() {
//    setTimeout(gameLoop, 1000 / 60);
//    //Process movement, AI, game logic
//    aBall.move();
//    ballHitWallDetection(aBall);
//    layer.draw();
//}


//function engine() {
//    aBall.move();
//    ballHitWallDetection(aBall);
//    layer.draw();
//    window.requestAnimationFrame(engine);
//}
//

anim.start();
//gameLoop();
//engine();
