function getRandomInt(min, max){
    var randomInt = Math.floor(Math.random() * (max - min + 1)) + min;
    return randomInt;
}

function getRandomRGB(){
    var red = getRandomInt(0, 255),
        green = getRandomInt(0, 255),
        blue = getRandomInt(0, 255),
        color = 'rgb(' + red + ',' + green +','+ blue +')';
    return color;
}

function onExecuteClick() {
    var console = document.getElementById('console'),
        randomDiv = document.createElement('div'),
        style = randomDiv.style;
    style.width = getRandomInt(20,100) + 'px';
    style.height = getRandomInt(20,100) + 'px';

    style.backgroundColor = getRandomRGB();
    style.color = getRandomRGB();
    randomDiv.innerHTML = '<strong>div</strong>';
    style.border = getRandomInt(1,20) + 'px solid '+ getRandomRGB();
    style.borderRadius = getRandomInt(0, 20) + 'px';
    
    style.position = 'absolute';
    style.top = getRandomInt(150,530)+'px'; // 150 - 530
    style.left = getRandomInt(15,680)+'px'; // 15 - 680
    
    console.appendChild(randomDiv);
}