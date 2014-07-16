define([], function () {
   var Levels = (function () {
       function Levels(game) {
           this.game = game;
           this.data = [];
       }

       Levels.prototype = {
           init: function () {
               var levelSelectLayer = document.getElementById('levelSelectScreen');
               var fragment = document.createDocumentFragment();
               var levelButton = document.createElement('button');
               var self_levels = this;
               for (var i = 0; i < this.data.length; i++) {
                   var currentButton = levelButton.cloneNode(true);
                   currentButton.value = i + 1;
                   currentButton.innerHTML = i + 1;
                   currentButton.addEventListener('click', function () {
                      self_levels.load(this.value - 1);
                   });
                   fragment.appendChild(currentButton);
               }
               levelSelectLayer.appendChild(fragment);

               return this;
           },
           load: function (number) {
               // TODO: WORK HERE
               console.log('Level ' + number + ' loaded !')
           },
           addLevel: function (levelData) {
               this.data.push(levelData);
               return this;
           }
       };
       return Levels;
   }());
    return Levels;
});