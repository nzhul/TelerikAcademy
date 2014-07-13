define([], function () {
   var Layer = (function () {
       function Layer(parentSelector, options) {
           this.width = options.width;
           this.height = options.height;
           this.id = options.id || 'unknown';
           this.class = options.class || 'unknownClass';
           this.parent = document.querySelector(parentSelector);
       }

       Layer.prototype = {
           init: function () {
               var canvas = document.createElement('canvas');
               canvas.width = this.width;
               canvas.height = this.height;
               canvas.className = this.class;
               canvas.id = this.id;
               this.parent.appendChild(canvas);
               this.canvas = canvas;
               return this;
           },
           getCtx: function () {
               return this.canvas.getContext('2d');
               return this;
           }
       }

       return Layer;
   }());
    return Layer;
});