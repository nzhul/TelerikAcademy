function moveDiv(t, mDiv) {
    t = t + 0.05;
    var r = 150,
        centerX = 250,
        centerY = 250,
        x = Math.floor(centerX + (r * Math.cos(t))),
        y = Math.floor(centerX + (r * Math.sin(t)));
    mDiv.style.top = x + 'px';
    mDiv.style.left = y + 'px';

    setTimeout(function () {
        moveDiv(t, mDiv);
    }, 10);
}

(function () {
    var div = document.getElementById('circle');
    moveDiv(1, div);
}())

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
