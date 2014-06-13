var paper = Raphael(document.getElementById('svg-container'), STAGE_WIDTH, STAGE_HEIGHT + 4),
    gameOverText = paper.text(250, 160, 'Game Over'),
    textAnimBigger,
    isAnimationRunning = true;

gameOverText.attr({
    'font-size': 0
});
  //  var canvasEl = document.getElementsByClassName('kineticjs-content');
////
  //  canvasEl.style.display = 'none !important';
//
    textAnimBigger = Raphael.animation({
        '40%': {'font-size': 95, fill: 'darkred', easing: 'bounce'},
        '100%': {'font-size': 1, easing: 'bounce'}
    }, 1000).repeat(Infinity);


    //gameOverText.animate(textAnimBigger);

//    gameOverText.mouseover(function(){
//        gameOverText.stop();
//        gameOverText.attr({
//            'font-size': 95,
//            fill: 'darkred'
//        })
//    });

//    gameOverText.mouseout(function(){
//        gameOverText.animate(textAnimBigger);
//    });

    gameOverText.click(function(){
        gameOverText.stop();
        gameOverText.attr({
            'font-size': 95,
            fill: 'darkred'
        });
        isAnimationRunning = false;
    });

