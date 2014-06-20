stage = new Kinetic.Stage({
    container: 'container',
    width: STAGE_WIDTH,
    height: STAGE_HEIGHT
});

bricksLayer = new Kinetic.Layer();
ballLayer = new Kinetic.Layer();
paddleLayer = new Kinetic.Layer();
giftsLayer = new Kinetic.Layer();
explosionsLayer = new Kinetic.Layer();

//get the underlaying context from the layer:
ctx = explosionsLayer.canvas.context._context;

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
    directionY: DIRECTION_Y,
    stroke: 'black',
    strokeWidth: .5,
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
}).setAttrs({
    paddleType: { name: 'regular', color: 'black'}
});

//var aPaddle = new Kinetic.Shape({
//    sceneFunc: function(context) {
//        context.beginPath();
//        context.moveTo(this.attrs.x, this.attrs.y);
//        context.lineTo(this.attrs.x, this.attrs.y + this.attrs.height);
//        context.lineTo(this.attrs.x + this.attrs.width, this.attrs.y + this.attrs.height);
//        context.lineTo(this.attrs.x + this.attrs.width, this.attrs.y);
//        context.lineTo(this.attrs.x + this.attrs.width / 2 + 10, this.attrs.y - this.attrs.height);
//        context.lineTo(this.attrs.x + this.attrs.width / 2 - 10, this.attrs.y - this.attrs.height);
//        context.closePath();
//        // KineticJS specific context method
//        context.fillStrokeShape(this);
//    },
//    x: PADDLE_START_X,
//    y: 200, //PADDLE_START_Y,
//    width: 100,
//    height: 5,
//    fill: '#00D2FF',
//    stroke: 'black',
//    strokeWidth: 3
//});
initBricks();

function calcBallAngle(ball) {
    var ballPosition = ball.attrs.x - aPaddle.attrs.x;
    var xChange = ((ballPosition / PADDLE_WIDTH) * 10) - MAX_X_SPEED;
    return xChange * -1;
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

ballLayer.add(aBall);
paddleLayer.add(aPaddle);

stage.add(bricksLayer);
stage.add(ballLayer);
stage.add(paddleLayer);
stage.add(giftsLayer);
stage.add(explosionsLayer);

var layers = [bricksLayer, ballLayer, paddleLayer, giftsLayer];
var anim = new Kinetic.Animation(function (frame) {
    //For performance test
    //console.log(frame.frameRate);
    //ctx.fillRect(10, 10, 100, 100);

    update(frameDelay);
    aBall.move();
    ballHitWallDetection(aBall);
    ballHitBrickDetection(aBall);

    if (levelBrickCount == 0){
        gameWin();
    }
}, layers, explosionsLayer); // !

document.getElementById('start-btn').addEventListener('click', onStartBtnClick);
document.getElementById('pause-btn').addEventListener('click', onPauseBtnClick);
document.getElementById('best-scores-btn').addEventListener('click', onScoreBtnClick);

//TO DO
function gameWin(){
    anim.stop();
}

function endGame(){
    anim.stop();
    gameOverText.animate(textAnimBigger);
    var canvases = document.getElementsByTagName('canvas');

    for (var i = 0; i < canvases.length; i += 1) {
        canvases[i].style.zIndex = '1';
    }

    setTimeout(function(){
        var currentName = prompt('Your socre is: '+ playerScore + '! Please enter your name:');
        if (currentName === '') {
            currentName = 'Anonymous';
        }
        else if (currentName === null) {
            currentName = 'Anonymous';
        }
        localStorage.setItem(playerScore, currentName);
        updateTopScores();
    }, 1500);

}

function onStartBtnClick() {
    document.getElementById('container').addEventListener('click', onClickStartGame);
    var gameInstruction = document.getElementById('start-game-instruction');
    gameInstruction.style.display = 'block';
    //Hide the label that indicates restart of the game
    var restartGameLabel = document.getElementById('restart-game');
    restartGameLabel.style.display = 'none';

    playerScore = 0;
}

function onClickStartGame() {
    anim.start();
    var gameInstruction = document.getElementById('start-game-instruction');
    gameInstruction.style.display = 'none';
}

function onPauseBtnClick() {
    anim.stop();
}

function onScoreBtnClick(){
    var scoreDiv = document.getElementById('score');

    if(scoreDiv.style.display == 'block'){
        scoreDiv.style.display = 'none';
    }
    else{
        updateTopScores();
        scoreDiv.style.display = 'block';
    }

}
