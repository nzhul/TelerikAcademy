var movingShapes = (function () {
    var canvas = document.getElementById('canvas')
    var ctx = canvas.getContext('2d');
    var rectArray = [];
    var circleArray = [];

    function MovingObject(x, y, width, height, movementType) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.color = 'red';
        this.border = 'black';
        this.angle = 0;
        this.speed = 0.01;
        this.shift = 0;
        this.direction = 'right';
        this.movementType = movementType;
    }
    MovingObject.prototype.drawObject = function () {
        ctx.beginPath();
        ctx.rect(this.x, this.y, this.width, this.height);
        ctx.fillStyle = this.color;
        ctx.strokeStyle = this.border;
        ctx.closePath();
        ctx.fill();
    };
    MovingObject.prototype.circleUpdate = function () {
        this.angle +=  this.speed;
        var r = 100,
            centerX = (canvas.width / 2),
            centerY = (canvas.height / 2);
            this.x = Math.floor(centerX + (r * Math.cos(this.angle * 1 + this.shift))),
            this.y = Math.floor(centerY + (r * Math.sin(this.angle * 0.5)));
            this.shift+= 0.1;
        // Uncomment this code for Perfect Circle motion
        // this.x = Math.floor(centerX + (r * Math.cos(this.angle))),
        // this.y = Math.floor(centerY + (r * Math.sin(this.angle)));
    }
    MovingObject.prototype.rectUpdate = function () {
        switch(this.direction){
            case 'right':
                this.x += 1;
                break;
            case 'left':
                this.x -= 1;
                break;
            case 'up':
                this.y -= 1;
                break;
            case 'down':
                this.y += 1;
                break;
        }
        if (this.direction === 'right' && this.x >= canvas.width - 5 - this.width) {
            this.direction = 'down';
        } else if(this.direction === 'down' && this.y >= canvas.height - 5 - this.height){
            this.direction = 'left';
        } else if(this.direction === 'left' && this.x <= 5){
            this.direction = 'up';
        } else if(this.direction === 'up' && this.y <= 5){
            this.direction = 'right';
        }
    }

    function add(movementType) {
        var newElement = new MovingObject(canvas.width / 2,canvas.height / 2, 10,10, 'unknown');
        if(movementType === 'circle'){
            newElement.movementType = movementType;
            circleArray.push(newElement);
        } else if(movementType === 'rect'){
            newElement.movementType = movementType;
            newElement.x = 5;
            newElement.y = 5;
            rectArray.push(newElement);
        }
    }


    function engine() {
        ctx.clearRect(0,0,canvas.width, canvas.height);
        for (var i = 0; i < circleArray.length; i++) {
            circleArray[i].circleUpdate();
            circleArray[i].drawObject();
        }
        for (var j = 0; j < rectArray.length; j++) {
            rectArray[j].rectUpdate();
            rectArray[j].drawObject();
        }

        requestAnimationFrame(function () {
            engine();
        });
    }

    return {
        add: add,
        startEngine: engine
    }
}());