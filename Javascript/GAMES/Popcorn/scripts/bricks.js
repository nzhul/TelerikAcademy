function initBricks() {
    var brickMatrix = [],
        i,
        j,
        brickCount = STAGE_WIDTH / (BRICK_WIDTH + 2) - 1,
        currentBrick,
        verticalShift = 0,
        horizontalShift = 0;
    levelBrickCount = Math.floor(brickCount) * BRICK_ROW_COUNT + 1;

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
                stroke: 'black',
                strokeWidth: 1,
                listening: true
            }).setAttrs({
                    isObjectProducer: (function () {
                        if(getRandomInt(1, 100) < 15){
                            return true;
                        } else {
                            return false;
                        }
                    }()),
                    gameObjectType: 'brick'
                });
            if(currentBrick.getAttr('isObjectProducer')){
                currentBrick.setAttr('producedObjectType', PRODUCIBLE_OBJECTS[0]);//getRandomInt(0, PRODUCIBLE_OBJECTS.length - 1)]);
                var currProducedObject = currentBrick.getAttr('producedObjectType');
                currentBrick.fill(currProducedObject.color);
            }
            brickMatrix[i][j] = (currentBrick);
            bricksLayer.add(currentBrick);
            horizontalShift += BRICK_WIDTH + 5;
        }
        verticalShift += BRICK_HEIGHT + 5;
    }
    return brickMatrix;
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}