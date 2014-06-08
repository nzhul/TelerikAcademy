var stage = new Kinetic.Stage({
    container: 'container',
    width: 411,
    height: 350
});

var layer = new Kinetic.Layer(),
    pulenTashsak = 0,
    pulenTashsak2 = 0,
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
var containerRect = container.getBoundingClientRect();

var aBall = new Kinetic.Circle({
    x: BALL_START_X,
    y: BALL_START_Y,
    radius: BALL_RADIUS,
    fill: BALL_COLOR
}).setAttrs({
        directionX: DIRECTION_X,
        directionY: DIRECTION_Y,
        type: 'regular',
        changeDirection: function(){
            if (this.getAttr('x') + this.getAttr('radius') >= stage.getWidth()) {
                this.setAttr('directionX', this.getAttr('directionX')  -DIRECTION_X )
            }
            if (this.getAttr('x') <= this.getAttr('radius')) {
                this.setAttr('directionX', this.getAttr('directionX') + DIRECTION_X )
            }
            // no reflection from down
            if (this.getAttr('y') <= this.getAttr('radius')) {
                this.setAttr('directionY', this.getAttr('directionY') + DIRECTION_Y )
            }
            this.setAttr('x',this.getAttr('x') + this.getAttr('directionX') );
            this.setAttr('y',this.getAttr('y') + this.getAttr('directionY') );
        }
    });

var aPaddle = new Kinetic.Rect({
    x: PADDLE_START_X,
    y: PADDLE_START_Y,
    width: PADDLE_WIDTH,
    height: PADDLE_HEIGHT,
    fill: PADDLE_COLOR,
    listening: true
});



window.addEventListener('mousemove', function (ev) {
    var mouseX = ev.clientX;
    if (mouseX < containerRect.left) {
        aPaddle.setPosition({
            x: 0,
            y: aPaddle.getY()
        });
    } 
    else if (mouseX + PADDLE_WIDTH < stage.getWidth() + containerRect.left) {
        aPaddle.setPosition({
            x: ev.clientX - containerRect.left,
            y: aPaddle.getY()
        });
    } 
    else {
        aPaddle.setPosition({
            x: stage.getWidth() - PADDLE_WIDTH,
            y: aPaddle.getY()
        });
    }
});

layer.add(aBall);
layer.add(aPaddle);
stage.add(layer);


function engine() {
    aBall.changeDirection;
    layer.draw();
    window.requestAnimationFrame(engine);
}

engine();
