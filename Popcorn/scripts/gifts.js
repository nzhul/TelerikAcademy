function spawnGift (x, y, color, type) {
var gift = new Kinetic.Circle({
    x: x + BRICK_WIDTH / 2,
    y: y + BRICK_HEIGHT / 2,
    radius: 5,
    fill: color
}).setAttrs({
        type: type
    });

    giftsLayer.add(gift);
}
