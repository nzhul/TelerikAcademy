function spawnGift(x, y, color, type) {
    var vectorY = 1,
        gift = new Kinetic.Circle({
            x: x + BRICK_WIDTH / 2,
            y: y + BRICK_HEIGHT / 2,
            radius: 5,
            fill: color,
            stroke: 'black',
            strokeWidth: .5,
            move: function () {
                moveGiftDown.start();
            }
        }).setAttrs({
            giftType: type
        });

    giftsLayer.add(gift);

    var moveGiftDown = new Kinetic.Animation(function (frame) {
        gift.setY(gift.getY() + vectorY);

        // Check for gift Collision with the paddle
        if (gift.getY() + 5 >= aPaddle.getY() && gift.getY() + 5 < aPaddle.getY() + 1) {
            if (gift.getX() >= aPaddle.getX() && gift.getX() <= aPaddle.getX() + PADDLE_WIDTH) {
                // We have collision

                // If we don't have any bonus - ACCEPT the bonus and display the stuff
                if (aPaddle.getAttr('paddleType').name == 'regular') {
                    aPaddle.setAttrs({
                        paddleType: gift.getAttr('giftType')
                    });
                    shotsLeft = 5;
                    var bonusText = new Kinetic.Text({
                        x: 15,
                        y: STAGE_HEIGHT - 30,
                        text: 'Bonus: ' + gift.getAttr('giftType').name,
                        fontSize: 14,
                        fontFamily: 'Calibri',
                        fill: 'black'
                    });
                    paddleLayer.add(bonusText);
                }
                gift.remove();
            }
        }

        if (gift.getY() >= STAGE_HEIGHT) {
            gift.remove();
        }
    }, giftsLayer);

    return gift;
}
