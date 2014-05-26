(function () {
    //Init canvas stuff
    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');
    var w = 450;
    var h = 450;
    var cellWidth = 10;
    var cellSpacing = 11;
    canvas.style.width = w +'px';
    canvas.style.height = h + 'px';
    var direction = 'right';

    // Paint the canvas
    ctx.strokeStyle = 'white';
    ctx.strokeRect(0, 0, w, h);

    // Create Snake
    var snakeArr = [];

    
    function createSnake() {
        var length = 15; // Length of the snake
        snakeArr = [];
        for (var i = length - 1; i >= 0; i--) {
            snakeArr.push({
                x: i,
                y: 0
            });
        }
    }
    createSnake();

    // Draw the snake
    function Draw() {

        //Pain the Whole CANVAS to Clear everything
        ctx.fillStyle = 'black';
        ctx.fillRect(0, 0, w, h);
        ctx.strokeStyle = 'white';
        ctx.strokeRect(0, 0, w, h);

        // Change Direction
        document.onkeydown = function () {
            switch (window.event.keyCode) {
                case 37: // left
                    direction = 'left';
                    break;
                case 38: // left
                    direction = 'up';
                    break;
                case 39: // right
                    direction = 'right';
                    break;
                case 40: // down
                    direction = 'down';
                    break;
            }
        }

        // Generate new head and removes the tail
        var newHeadX = snakeArr[0].x;
        var newHeadY = snakeArr[0].y;

        switch (direction) {
            case 'right':
                newHeadX++;
                break;
            case 'down':
                newHeadY++;
                break;
            case 'left':
                newHeadX--;
                break;
            case 'up':
                newHeadY--;
                break;
        }

        var tail = snakeArr.pop();
        tail.x = newHeadX;
        tail.y = newHeadY
        snakeArr.unshift(tail);

        // Draw the snake
        for (var i = 0; i < snakeArr.length; i++) {
            var bodyElement = snakeArr[i];
            ctx.fillStyle = 'white';
            ctx.fillRect(bodyElement.x * cellSpacing, bodyElement.y * cellSpacing, cellWidth, cellWidth);
        }
    }
    Draw();

    gameLoop = setInterval(Draw, 100);



}())