function moveDiv(t, mDiv, start) {
    t = t + 0.05;
    var r = 150,
        centerX = 200,
        centerY = 200,
        x = Math.floor(centerX + (r * Math.cos(t + start)) + 200),
        y = Math.floor(centerX + (r * Math.sin(t + start)) + 250);
    mDiv.style.top = y + 'px';
    mDiv.style.left = x + 'px';

    setTimeout(function () {
        moveDiv(t, mDiv, start);
    }, 10);
}

function onAnimateDivsClick() {

    for (var i = 0; i < 5; i++) {
        var div = document.getElementById('circle' + i);
        moveDiv(1, div, i / 2);
    }

    //var div = document.getElementById('circle');
    //moveDiv(1, div);
}

function onCreateDivsClick() {
    var console = document.getElementById("console");
    for (var i = 0; i < 5; i++) {
        var centerX = 400,
            centerY = 450,
            radius = 150,
            x = (centerX + radius * Math.cos(2 * Math.PI * i / 5)),
            y = (centerY + radius * Math.sin(2 * Math.PI * i / 5)),
            circleDiv = document.createElement('div');
        circleDiv.classList.add('circle');
        circleDiv.id = 'circle' + i;
        circleDiv.style.left = x + 'px';
        circleDiv.style.top = y + 'px';
        console.appendChild(circleDiv);
    }
}

//(function () {
//    var console = document.getElementById("console");
//        for (var i = 0; i <= 100; i += 1) {
//            var centerX = 200;
//            var centerY = 200;
//            var radius = 100;
//            var x = (centerX + radius * Math.cos(2 * Math.PI * i / 100));
//            var y = (centerY + radius * Math.sin(2 * Math.PI * i / 100));
//            circleDiv = document.createElement("div"),
//            style = circleDiv.style;
//            style.position = 'absolute';
//            style.left = x + 'px';
//            style.top = y + 'px';
//            circleDiv.classList.add("circle");
//            console.appendChild(circleDiv);
//        }
//}())
