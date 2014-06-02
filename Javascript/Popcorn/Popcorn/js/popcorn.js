(function () {
    //Init canvas stuff
    var canvas = document.getElementById('canvas'),
        cx = canvas.getContext('2d'),
        canvasW = 450,
        canvasH = 450,
        BALL_START_X = 50,
        BALL_START_Y = 50,
        BALL_RADIUS = 10,
        BALL_COLOR = 'red',
        PADDLE_WIDTH = 100,
        PADDLE_HEIGHT = 10,
        PADDLE_COLOR = 'black';

    cx.fillStyle = 'white';
    cx.fillRect(0, 0, canvasW, canvasH);

    function circle(x, y, r, color) {
        cx.beginPath();
        cx.arc(x, y, r, 0, Math.PI * 2, true);
        cx.fillStyle = color;
        cx.closePath();
        cx.fill();
    };
    function rect(x, y, w, h, color) {
        cx.beginPath();
        cx.rect(x, y, w, h);
        cx.fillStyle = color;
        cx.closePath();
        cx.fill();
    };

    function clear() {
        cx.clearRect(0, 0, canvasW, canvasH);
    }

    function Ball(x, y, directionX, directionY, radius, color, type) {
        var self = this;
        this.x = x,
        this.y = y,
        this.radius = radius,
        this.directionX = directionX,
        this.directionY = directionY,
        this.type = type,
        this.drawBall = function () {
            circle(self.x, self.y, radius, color);
        };
        this.changeDirection = function () {
            if (self.x + self.radius >= canvasW) {
                self.directionX = -directionX;
            }
            if (self.x <= self.radius) {
                self.directionX = directionX;
            }
            if (self.y + self.radius > canvasH) {
                self.directionY = -directionY;
            }
            if (self.y <= self.radius) {
                self.directionY = directionY;
            }
            self.x += self.directionX;
            self.y += self.directionY;
        }
        return self;
    }

    function Brick(x, y, type) {
        this.x = x,
        this.y = y,
        this.type = type
    }

    function Paddle(x, y, width, height, type, color) {
        var self = this;
        this.x = x,
        this.y = y,
        this.width = width,
        this.height = height,
        this.type = type,
        this.color = color,
        this.drawPaddle = function () {
            rect(self.x, self.y, self.width, self.height, self.color);
        }
    }

    function engine() {
        clear();
        aBall.drawBall();
        aPaddle.drawPaddle();
        aBall.changeDirection();
        paddleCollision(aBall, aPaddle);
        window.requestAnimationFrame(engine);
    }

    // TODO FIX ME
    function paddleCollision(ball, paddle) {
        if (ball.y + ball.radius >= paddle.y - PADDLE_HEIGHT) {
            if (ball.x >= paddle.x && ball.x <= paddle.x + PADDLE_WIDTH) {
                console.log('paddle collision');
            } else {
                console.log('dead');
            }
        }
    }


    
    var aBall = new Ball(BALL_START_X, BALL_START_Y, 2, 6, BALL_RADIUS, BALL_COLOR, 'regular');
    var aPaddle = new Paddle(canvasW / 2 - PADDLE_WIDTH / 2, canvasH - PADDLE_HEIGHT, PADDLE_WIDTH, PADDLE_HEIGHT, 'regular', PADDLE_COLOR);
    engine();




}())