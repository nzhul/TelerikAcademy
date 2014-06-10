var particles = [];

//we need this for the explosion animations
var frameRate = 50.0;
var frameDelay = 1000.0 / frameRate;

function update(frmDelay) {
    // draw a white background to clear canvas
    ctx.fillStyle = "#FFF";
    // ctx.fillRect(0, 0, ctx.canvas.width, ctx.canvas.height);
    explosionsLayer.clear();

    // update and draw particles
    for (var i = 0; i < particles.length; i++) {
        var particle = particles[i];

        particle.update(frmDelay);
        particle.draw(ctx);
    }
}

function explode() {
    var x = aBall.attrs.x;
    var y = aBall.attrs.y;

    createExplosion(x, y, "#f0e307");

    createExplosion(x, y, "#f99700");

    createExplosion(x, y, "#de3b00");

    createExplosion(x, y, "#9a1201");

    function randomFloat(min, max) {
        return min + Math.random() * (max - min);
    }

    function Particle() {
        this.scale = 1.0;
        this.x = 0;
        this.y = 0;
        this.radius = 20;
        this.color = "#000";
        this.velocityX = 0;
        this.velocityY = 0;
        this.scaleSpeed = 0.5;

        this.update = function (ms) {
            // shrinking
            this.scale -= this.scaleSpeed * ms / 1000.0;
            if (this.scale <= 0) {
                this.scale = 0;
            }

            // moving away from explosion center
            this.x += this.velocityX * ms / 1000.0;
            this.y += this.velocityY * ms / 1000.0;
        };

        this.draw = function (ctx) {
            // translating the 2D context to the particle coordinates
            ctx.save();
            ctx.translate(this.x, this.y);
            ctx.scale(this.scale, this.scale);

            // drawing a filled circle in the particle's local space
            ctx.beginPath();
            ctx.arc(0, 0, this.radius, 0, Math.PI * 2, true);
            ctx.closePath();

            ctx.fillStyle = this.color;
            ctx.fill();

            ctx.restore();
        };
    }
    function createExplosion(explosionX, explosionY, color) {
        var minSize = 10;
        var maxSize = 30;
        var count = 10;
        var minSpeed = 60.0;
        var maxSpeed = 200.0;
        var minScaleSpeed = 1.0;
        var maxScaleSpeed = 4.0;

        for (var angle = 0; angle < 360; angle += Math.round(360 / count)) {
            var particle = new Particle();

            particle.x = explosionX;
            particle.y = explosionY;

            particle.radius = randomFloat(minSize, maxSize);

            particle.color = color;

            particle.scaleSpeed = randomFloat(minScaleSpeed, maxScaleSpeed);

            var speed = randomFloat(minSpeed, maxSpeed);

            particle.velocityX = speed * Math.cos(angle * Math.PI / 180.0);
            particle.velocityY = speed * Math.sin(angle * Math.PI / 180.0);

            particles.push(particle);
        }
    }
}