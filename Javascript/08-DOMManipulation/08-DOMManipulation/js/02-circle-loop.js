(function () {
    var console = document.getElementById("console");

    var counter = 0;
    var increase = Math.PI * 2 / 100;
    for (var i = 0; i <= 500; i+= 1) {
        var x = i;
        //var y = ((Math.sin(counter) * 100) / 2 + 80) * (i/100);
        //var y = i * (i / 500)
        //var y = Math.pow((i / 100), 4);
        var y = (Math.sin(counter)*100) / 5 + 150;
        counter += increase;
        circleDiv = document.createElement("div"),
        style = circleDiv.style;
        style.position = 'absolute';
        style.left = x + 'px';
        style.top = y + 'px';
        circleDiv.classList.add("circle");
        console.appendChild(circleDiv);
    }

}())
