document.addEventListener('click', function () {
    console.log(aPaddle.getAttr('paddleType').name);
    if (shotsLeft) {
        if (aPaddle.getAttr('paddleType').name == 'ShootingPaddle') {
            var vectorY = -5;
            var leftBullet = new Kinetic.Rect({
                x: aPaddle.getX() + aPaddle.getWidth() / 2,
                y: aPaddle.getY(),
                width: 5,
                height: 5,
                fill: 'black',
                moveBullet: function () {
                    moveLeftBulletUp.start();
                    shotsLeft--;
                    if (shotsLeft == 0) {
                    aPaddle.setAttrs({
                            paddleType: { name: 'regular', color: 'black'}
                        });
                    }
                }
            });

//        var rightBullet = new Kinetic.Rect({
//            x: aPaddle.getX() + PADDLE_WIDTH,
//            y: aPaddle.getY(),
//            width: 5,
//            height: 5,
//            fill: 'black',
//            moveBullet: function () {
//                moveRightBulletUp.start();
//            }
//        });

            giftsLayer.add(leftBullet);
//        giftsLayer.add(rightBullet);

            var moveLeftBulletUp = new Kinetic.Animation(function (frame) {
                leftBullet.setY(leftBullet.getY() + vectorY);

                if (leftBullet.getY() < 0) {
                    leftBullet.remove();
                }

                bulletHitBrickCollision(leftBullet);
            }, giftsLayer);

//        var moveRightBulletUp = new Kinetic.Animation(function (frame) {
//            rightBullet.setY(rightBullet.getY() + vectorY);
//
//            if (rightBullet.getY() < 0) {
//                rightBullet.remove();
//            }
//
//            bulletHitBrickCollision(rightBullet);
//        }, giftsLayer);

            var move1 = leftBullet.attrs.moveBullet;
            move1();
//        var move2 = rightBullet.attrs.moveBullet;
//        move2();
        }
    }

});