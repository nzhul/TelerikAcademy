(function () {
    //Init canvas stuff
    var canvas = document.getElementById('canvas');
    var cx = canvas.getContext('2d');
    var canvasW = 450;
    var canvasH = 450;

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
        this.animateBall = function () {
            clear();
            circle(self.x, self.y, radius, color);
            self.x += self.directionX;
            self.y += self.directionY;
            if (self.x + self.radius + self.directionX > canvasW || self.x + self.directionX + self.radius < 0) {
                self.directionX = -self.directionX;
            }
            if (self.y + self.radius + self.directionY > canvasH || self.y + self.directionY + self.radius < 0) {
                self.directionY = -self.directionY;
            }
            self.x += self.directionX;
            self.y += self.directionY;
            window.requestAnimationFrame(self.animateBall);
        };
        return self;
    }

    function Brick(x, y, type) {
        this.x = x,
        this.y = y,
        this.type = type
    }

    var activeBall = new Ball(50, 50, 2, 4, 25, 'red', 'regular');
    activeBall.animateBall();




}())