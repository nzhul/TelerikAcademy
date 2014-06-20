/**
 * Created by kakadu5 on 20.6.2014 г..
 */
window.onload = function(){

    function Layer(parent, options){
        this.width = options.width;
        this.height = options.height;
        this.id = options.id || 'unknown';
        var self = this;
        this.init = function () {
            var canvas = document.createElement('canvas');
            canvas.style.width = self.width + 'px';
            canvas.style.height = self.height + 'px';
            var parent = document.querySelector(parent);
            parent.appendChild(canvas);
            return canvas.getContext('2d');
        }
    }

    var map = new Layer('#root',
    {
        width: 500,
        height: 500,
        id: 'map'
    });

    map.init();



//    function initCanvas() {
//        var mapLayer = document.createElement('canvas');
//        mapLayer.id = 'map';
//        mapLayer.style.width = mapLayer_WIDTH + 'px';
//        mapLayer.style.height = mapLayer_HEIGHT + 'px';
//        document.body.appendChild(mapLayer);
//    }
//
//    initCanvas();

}

