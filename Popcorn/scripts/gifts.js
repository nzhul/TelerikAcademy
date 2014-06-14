function spawnGift(x, y, color, type) {
    var vectorY = 1,
        gift = new Kinetic.Circle({
            x: x + BRICK_WIDTH / 2,
            y: y + BRICK_HEIGHT / 2,
            radius: 5,
            fill: color,
            move: function () {
                moveGiftDown.start();
            }
        }).setAttrs({
            type: type
        });

    giftsLayer.add(gift);

    var moveGiftDown = new Kinetic.Animation(function (frame) {
        gift.setY(gift.getY() + vectorY);
    }, giftsLayer);

    return gift;
}
