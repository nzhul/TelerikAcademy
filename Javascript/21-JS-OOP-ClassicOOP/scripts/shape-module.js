var drawingModule = (function () {
    var canvas = document.createElement('canvas');
    canvas.width = 450;
    canvas.height = 350;
    var ctx = canvas.getContext('2d');
    document.body.appendChild(canvas);

    function drawRect(x, y, width, height) {
        var newRect = new Rect(x, y, width, height).draw(ctx);
    }

    function drawCircle(x, y, radius) {
        var newCircle = new Circle(x, y, radius).draw(ctx);
    }

    function drawLine(startX, startY, endX, endY) {
        var newLine = new Line(startX, startY, endX, endY).draw(ctx);
    }

    return {
        drawRect: drawRect,
        drawCircle: drawCircle,
        drawLine: drawLine
    }
}());

var Rect = (function () {
    function Rect(x, y, width, height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
    Rect.prototype = {
        draw: function (ctx) {
            ctx.beginPath();
            ctx.rect(this.x, this.y, this.width, this.height);
            ctx.fillStyle = 'red';
            ctx.closePath();
            ctx.fill();
            return this;
        }
    }

    return Rect;
}());

var Circle = (function () {
    function Circle(x, y, radius) {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }
    Circle.prototype = {
        draw: function (ctx) {
            ctx.beginPath();
            ctx.arc(this.x, this.y, this.radius, 0, Math.PI * 2, true);
            ctx.fillStyle = 'red';
            ctx.closePath();
            ctx.fill();
            return this;
        }
    }

    return Circle;
}());

var Line = (function () {
    function Line(startX, startY, endX, endY) {
        this.startX = startX;
        this.startY = startY;
        this.endX = endX;
        this.endY = endY;
    }
    Line.prototype = {
        draw: function (ctx) {
            ctx.beginPath();
            ctx.moveTo(this.startX, this.startY);
            ctx.lineTo(this.endX, this.endY);
            ctx.closePath();
            ctx.strokeStyle = 'red';
            ctx.stroke();
            return this;
        }
    }

    return Line;
}());