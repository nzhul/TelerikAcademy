var paper = Raphael(document.getElementById('svg-container'), STAGE_WIDTH, STAGE_HEIGHT + 4),
    gameOverText = paper.text(250, 160, 'Game Over'),
    textAnimBigger,
    isAnimationRunning = true;

    gameOverText.attr({
        'font-size': 0
    });

    textAnimBigger = Raphael.animation({
        '40%': {'font-size': 95, fill: 'darkred', easing: 'bounce'},
        '100%': {'font-size': 1, easing: 'bounce'}
    }, 1000).repeat(Infinity);

    gameOverText.click(function(){
        gameOverText.stop();
        gameOverText.attr({
            'font-size': 95,
            fill: 'darkred'
        });
        isAnimationRunning = false;
        location.reload(true);
    });

