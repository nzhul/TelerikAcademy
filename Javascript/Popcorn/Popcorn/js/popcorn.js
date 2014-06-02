(function () {
    //Init canvas stuff
    var canvas = document.getElementById('canvas'),
        cx = canvas.getContext('2d'),
        canvasW = canvas.width,
        canvasH = canvas.height,
        BALL_START_X = 50,
        BALL_START_Y = 50,
        BALL_RADIUS = 10,
        BALL_COLOR = 'red',
        DIRECTION_X = 2,
        DIRECTION_Y = 6,
        PADDLE_WIDTH = 100,
        PADDLE_HEIGHT = 10,
        PADDLE_COLOR = 'black',
        GAME_OVER = false,
        RIGHT_DOWN = false,
        LEFT_DOWN = false;

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

    function remove(id) {
        return (elem = document.getElementById(id)).parentNode.removeChild(elem);
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
            //if (self.y + self.radius > canvasH) {
            //    self.directionY = -directionY;
            //}
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
            document.onkeydown = function () {
                switch (window.event.keyCode) {
                    case 37: // left
                        LEFT_DOWN = true;
                        break;
                    case 65: // A
                        LEFT_DOWN = true;
                        break;
                    case 39: // right
                        RIGHT_DOWN = true;
                        break;
                    case 68: // D
                        RIGHT_DOWN = true;
                        break;
                }
            }
            document.onkeyup = function () {
                switch (window.event.keyCode) {
                    case 37: // left
                        LEFT_DOWN = false;
                        break;
                    case 65: // A
                        LEFT_DOWN = false;
                        break;
                    case 39: // right
                        RIGHT_DOWN = false;
                        break;
                    case 68: // D
                        RIGHT_DOWN = false;
                        break;
                }
            }
            if (RIGHT_DOWN) {
                self.x += 5;
            } else if (LEFT_DOWN) {
                self.x -= 5;
            }
            rect(self.x, self.y, self.width, self.height, self.color);
        }
    }

    function engine() {
        if (GAME_OVER) {
            showEndGameUI();
            return;
        }
        clear();
        aBall.drawBall();
        aPaddle.drawPaddle();
        aBall.changeDirection();
        paddleCollision(aBall, aPaddle);
        window.requestAnimationFrame(engine);
    }

    // TODO FIX ME
    function paddleCollision(ball, paddle) {
        if (ball.y + ball.radius >= paddle.y) {
            if (ball.x >= paddle.x && ball.x <= paddle.x + PADDLE_WIDTH) {
                ball.directionY = -DIRECTION_Y;
            } else {
                GAME_OVER = true;
            }
        }
    }

    function showEndGameUI() {
        cx.font = '20px Arial';
        cx.fillStyle = 'red';
        var text = 'GAME OVER';
        var textLength = cx.measureText(text);
        cx.fillText('GAME OVER', canvasW / 2 - textLength.width / 2, canvasH / 2 + 30);

        var restartButton = document.createElement('a');
        restartButton.innerHTML = 'Restart the game!';
        restartButton.href = '#';
        restartButton.id = 'restartBtn';
        restartButton.onclick = function () {
            restartGame();
        };
        document.body.appendChild(restartButton);
    }

    function restartGame() {
        remove('restartBtn');
        GAME_OVER = false;
        aBall.x = BALL_START_X;
        aBall.y = BALL_START_Y;
        aBall.directionX = DIRECTION_X;
        aBall.directionY = DIRECTION_Y;
        engine();
    }


    
    var aBall = new Ball(BALL_START_X, BALL_START_Y, DIRECTION_X, DIRECTION_Y, BALL_RADIUS, BALL_COLOR, 'regular');
    var aPaddle = new Paddle(canvasW / 2 - PADDLE_WIDTH / 2, canvasH - PADDLE_HEIGHT, PADDLE_WIDTH, PADDLE_HEIGHT, 'regular', PADDLE_COLOR);
    engine();




}())