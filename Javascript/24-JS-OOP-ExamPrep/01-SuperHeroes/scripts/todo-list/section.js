define(function () {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            this._items = [];
            this.title = title;
        }

        Section.prototype = {
            add: function (item) {
                this._items.push(item);
            },
            getData: function () {
                var copiedItems = this._items.map(function (item) {
                    return item.getData();
                });
                return {
                    title: this.title,
                    items: copiedItems
                }
            }
        };

        return Section;
    }());
    return Section;
});