var stage,
    layer,
    STAGE_WIDTH = 500,
    STAGE_HEIGHT = 350,
    BALL_START_X = 50,
    BALL_START_Y = 50,
    BALL_RADIUS = 5,
    BALL_COLOR = 'red',
    DIRECTION_X = 2,
    DIRECTION_Y = 6,
    MAX_X_SPEED = 4,
    PADDLE_WIDTH = 100,
    PADDLE_HEIGHT = 5,
    PADDLE_COLOR = 'black',
    PADDLE_START_X = STAGE_WIDTH / 2 - PADDLE_WIDTH / 2,
    PADDLE_START_Y = STAGE_HEIGHT - PADDLE_HEIGHT,
    GAME_OVER = false,
    RIGHT_DOWN = false,
    LEFT_DOWN = false,
    BRICK_WIDTH = 40,
    BRICK_HEIGHT = 15,
    BRICK_SPACING = 1,
    BRICK_COLOR = 'black',
    BRICK_ROW_COUNT = 5;

stage = new Kinetic.Stage({
    container: 'container',
    width: STAGE_WIDTH,
    height: STAGE_HEIGHT
});
layer = new Kinetic.Layer();


//we create new layer for the explosions animation
var explosionLayer = new Kinetic.Layer();
//get the underlaying context from the layer:
var ctx = explosionLayer.canvas.context._context;

//the collection of the explosion particles
var particles = [];

//we need this for the explosion animations
var frameRate = 50.0;
var frameDelay = 1000.0 / frameRate;



function update(frameDelay) {
    // draw a white background to clear canvas
    ctx.fillStyle = "#FFF";
    ctx.fillRect(0, 0, ctx.canvas.width, ctx.canvas.height);

    // update and draw particles
    for (var i = 0; i < particles.length; i++) {
        var particle = particles[i];

        particle.update(frameDelay);
        particle.draw(ctx);
    }
}

function explode() {
    var x = aBall.attrs.x;
    var y = aBall.attrs.y;

    createExplosion(x, y, "#525252");

    createExplosion(x, y, "#FFA318");

    function randomFloat(min, max) {
        return min + Math.random() * (max - min);
    }

    function Particle() {
        this.scale = 1.0;
        this.x = 0;
        this.y = 0;
        this.radius = 20;
        this.color = "#000";
        this.velocityX = 0;
        this.velocityY = 0;
        this.scaleSpeed = 0.5;

        this.update = function (ms) {
            // shrinking
            this.scale -= this.scaleSpeed * ms / 1000.0;
            if (this.scale <= 0) {
                this.scale = 0;
            }

            // moving away from explosion center
            this.x += this.velocityX * ms / 1000.0;
            this.y += this.velocityY * ms / 1000.0;
        };

        this.draw = function (ctx) {
            // translating the 2D context to the particle coordinates
            ctx.save();
            ctx.translate(this.x, this.y);
            ctx.scale(this.scale, this.scale);

            // drawing a filled circle in the particle's local space
            ctx.beginPath();
            ctx.arc(0, 0, this.radius, 0, Math.PI * 2, true);
            ctx.closePath();

            ctx.fillStyle = this.color;
            ctx.fill();

            ctx.restore();
        };
    }
    function createExplosion(x, y, color) {
        var minSize = 10;
        var maxSize = 30;
        var count = 10;
        var minSpeed = 60.0;
        var maxSpeed = 200.0;
        var minScaleSpeed = 1.0;
        var maxScaleSpeed = 4.0;


        for (var angle = 0; angle < 360; angle += Math.round(360 / count)) {
            var particle = new Particle();

            particle.x = x;
            particle.y = y;

            particle.radius = randomFloat(minSize, maxSize);

            particle.color = color;

            particle.scaleSpeed = randomFloat(minScaleSpeed, maxScaleSpeed);

            var speed = randomFloat(minSpeed, maxSpeed);

            particle.velocityX = speed * Math.cos(angle * Math.PI / 180.0);
            particle.velocityY = speed * Math.sin(angle * Math.PI / 180.0);

            particles.push(particle);
        }
    }
    //createBasicExplosion(x, y);
    //requestAnimationFrame(up(frameDelay));
    //setInterval(function () {
    //   update(frameDelay);
    //   console.log(frameDelay);
    //}, frameDelay);
    //setTimeout(up(frameDelay), 1000)
}


//containerRect gets the location of the gamefield in the window
var container = document.getElementById('container');
var containerX = Math.round(container.getBoundingClientRect().left) + PADDLE_WIDTH / 2; // !

Kinetic.Circle.prototype.directionX = null;
Kinetic.Circle.prototype.directionY = null;
Kinetic.Circle.prototype.move = function () {
    this.setY(this.attrs.y - this.attrs.directionY);
    this.setX(this.attrs.x - this.attrs.directionX);

    return this;
};

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

function playSingleSound() {
    document.getElementById('audiotag1').play();
}

function initBricks() {
    var brickMatrix = [],
        i,
        j,
        brickCount = STAGE_WIDTH / (BRICK_WIDTH + 2),
        currentBrick,
        verticalShift = 0,
        horizontalShift = 0;

    for (i = 0; i < BRICK_ROW_COUNT; i++) {
        brickMatrix[i] = [];
        horizontalShift = 0;
        for (j = 0; j < brickCount; j++) {
            currentBrick = new Kinetic.Rect({
                x: BRICK_SPACING + horizontalShift,
                y: BRICK_SPACING + verticalShift,
                width: BRICK_WIDTH,
                height: BRICK_HEIGHT,
                fill: BRICK_COLOR,
                listening: true
            });
            brickMatrix[i][j] = (currentBrick);
            layer.add(currentBrick);
            horizontalShift += BRICK_WIDTH + 1;
        }
        verticalShift += BRICK_HEIGHT + 1;
    }
    return brickMatrix;
}

initBricks();

function calcBallAngle(ball){
    var ballPosition = ball.attrs.x - aPaddle.attrs.x;
    var xChange = ((ballPosition / PADDLE_WIDTH) * 10) - MAX_X_SPEED;
    return xChange * -1;
}

function ballHitBrickDetection(ball) {
    var currentStage = ball.getStage(),
        colisionObject = currentStage.getIntersection({ x: ball.getX(), y: ball.getY() });
    
    if (colisionObject) {
        console.log(colisionObject);
        playSingleSound();
        colisionObject.remove();
        explode();
        ctx.fillRect(ball.getX(), ball.getY, 50, 50);
        ball.attrs.directionY *= -1;
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

            if(ball.attrs.directionX > MAX_X_SPEED){
                ball.attrs.directionX = MAX_X_SPEED;
            }
            else if(ball.attrs.directionX < -MAX_X_SPEED){
                ball.attrs.directionX = -MAX_X_SPEED;
            }
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
stage.add(explosionLayer).add(layer);

var anim = new Kinetic.Animation(function (frame) {
    //For performance test
    //console.log(frame.frameRate);
    //ctx.fillRect(10, 10, 100, 100);
    aBall.move();
    ballHitWallDetection(aBall);
    ballHitBrickDetection(aBall);
    update(frameDelay);
}, layer , explosionLayer);
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
