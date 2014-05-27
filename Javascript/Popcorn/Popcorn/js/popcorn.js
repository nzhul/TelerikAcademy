(function () {
    //Init canvas stuff
    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');
    var w = 450;
    var h = 450;

    ctx.fillStyle = 'white';
    ctx.fillRect(0, 0, w, h);

    var Ball = {
        x: 0,
        y: 0,
        type: 'regular'
    }

    var Brick = {
        x: 0,
        y: 0,
        type: 'regular'
    }
}())