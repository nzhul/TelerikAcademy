define(['jquery'], function ($) {
   var Game = (function () {
       function Game() {
           this.canvas;
           this.context;
       }

       Game.prototype = {
         init: function () {
             $('.gameLayer').hide();
             $('#mainMenu').show();
             this.canvas = $('#gamecanvas')[0];
             this.context = this.canvas.getContext('2d');
         }  
       };
       return Game;
   }());
    return Game;
});