define([], function () {
    var Store = (function () {

        // Constructor Validation helpers
        var nameMinLength = 6,
            nameMaxLength = 30;
        function nameIsValid(name) {
            if(name.length >= nameMinLength && name.length <= nameMaxLength){
                return true
            }
        }
        // helpers end

        function sortItems(items, sortBy) {
            switch(sortBy){
                case 'price':
                    items.sort(function(a,b){return a[sortBy] - b[sortBy]; });
                    return items.slice(0);
                    break;
                case 'name':
                    items.sort(function(a,b){return a[sortBy].localeCompare(b[sortBy]); });
                    return items.slice(0);
                    break;
            }
        }

        function filterItems(items, filterBy) {
            return items.filter(function (item) {
                return item.type === filterBy;
            });
        }

        function filterByPrice(items, min, max) {
            return items.filter(function (item) {
                return item.price > min && item.price < max;
            });
        }

        function filterByPartOfName(items, partOfName) {
            return items.filter(function (item) {
                var loweredString = item.name.toLowerCase();
                return loweredString.indexOf(partOfName) > -1;
            });
        }

        function Store(name) {
            if(nameIsValid(name)){
                this.name = name;
            } else {
                throw new Error('Invalid name: the name must be between '+ nameMinLength +' and '+nameMaxLength+' characters long');
            }
            this._itemsList = [];
        }

        Store.prototype = {
            addItem: function (item) {
                this._itemsList.push(item);
                return this;
            },
            getAll: function () {
                return sortItems(this._itemsList, 'name');
            },
            getSmartPhones: function () {
                var filteredItems = filterItems(this._itemsList, 'smart-phone');
                return sortItems(filteredItems, 'name');
            },
            getMobiles: function () {
                var smartPhones = filterItems(this._itemsList, 'smart-phone');
                var tablets = filterItems(this._itemsList, 'tablet');
                var allMobiles = smartPhones.concat(tablets);
                return sortItems(allMobiles, 'name');
            },
            getComputers: function () {
                var pcs = filterItems(this._itemsList, 'pc');
                var notebooks = filterItems(this._itemsList, 'notebook');
                var allComputers = pcs.concat(notebooks);
                return sortItems(allComputers, 'name');
            },
            filterItemsByType: function (filterType) {
                var filteredItems =  filterItems(this._itemsList, filterType);
                return sortItems(filteredItems, 'name');
            },
            filterItemsByPrice: function (options) {
                if(options !== undefined){
                    if(options.min !== undefined){
                        var min = options.min;
                    } else {
                        var min = 0;
                    }
                    if(options.max !== undefined){
                        var max = options.max;
                    } else {
                        var max = +Infinity;
                    }
                } else {
                    var min = 0;
                    var max = +Infinity;
                }
                // I know that there is a better way to make this, but my brain is full of **** right now. sry

                var filteredItems = filterByPrice(this._itemsList, min, max);
                return sortItems(filteredItems, 'price');
            },
            countItemsByType: function () {
                var dictionary = [];
                for (var i = 0; i < this._itemsList.length; i++) {
                    if(this._itemsList[i].type in dictionary){
                        dictionary[this._itemsList[i].type]++;
                    } else {
                        dictionary[this._itemsList[i].type] = 1;
                    }
                }
                return dictionary;
            },
            filterItemsByName: function (partOfName) {
                var filteredItems = filterByPartOfName(this._itemsList, partOfName);
                return sortItems(filteredItems, 'name');
            }
        };

        return Store;
    }());
    return Store;
});