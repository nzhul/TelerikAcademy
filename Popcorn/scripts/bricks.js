function initBricks() {
    var brickMatrix = [],
        i,
        j,
        brickCount = STAGE_WIDTH / (BRICK_WIDTH + 2),
        currentBrick,
        verticalShift = 0,
        horizontalShift = 0;

    for (i = 0; i < BRICK_ROW_COUNT; i++) {
        brickMatrix[i] = [];
        horizontalShift = 0;
        for (j = 0; j < brickCount; j++) {
            currentBrick = new Kinetic.Rect({
                x: BRICK_SPACING + horizontalShift,
                y: BRICK_SPACING + verticalShift,
                width: BRICK_WIDTH,
                height: BRICK_HEIGHT,
                fill: BRICK_COLOR,
                listening: true
            }).setAttrs({
                    isObjectProducer: (function () {
                        if(getRandomInt(1, 100) > 90){
                            return true;
                        } else {
                            return false;
                        }
                    }())
                });
            if(currentBrick.getAttr('isObjectProducer')){
                currentBrick.setAttr('producedObjectType', PRODUCIBLE_OBJECTS[getRandomInt(0, PRODUCIBLE_OBJECTS.length - 1)]);
                var currProducedObject = currentBrick.getAttr('producedObjectType');
                currentBrick.fill(currProducedObject.color);
            }
            brickMatrix[i][j] = (currentBrick);
            bricksLayer.add(currentBrick);
            horizontalShift += BRICK_WIDTH + 1;
        }
        verticalShift += BRICK_HEIGHT + 1;
    }
    return brickMatrix;
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}