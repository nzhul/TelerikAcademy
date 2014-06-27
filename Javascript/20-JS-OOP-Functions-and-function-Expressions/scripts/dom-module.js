var domModule = (function () {
    function appendElement(element, parentSelector) {
        var parent = document.querySelectorAll(parentSelector);
        if(parent instanceof NodeList || parent instanceof HTMLCollection){
            for (var i = 0; i < parent.length; i++) {
                parent[i].appendChild(element.cloneNode(true));
            }
        } else if(parent instanceof  Element){
            parent.appendChild(element);
        }
    }

    function removeElement(selector) {
        var elements = document.querySelectorAll(selector);
        if(elements instanceof NodeList || elements instanceof HTMLCollection){
            for (var i = 0; i < elements.length; i++) {
                if(elements[i] && elements[i].parentElement){
                    elements[i].parentElement.removeChild(elements[i]);
                }
            }
        } else if(elements instanceof  Element){
            elements.parentElement.removeChild(elements);
        }
    }

    function addEvent(selector, eventType, eventHandler) {
        var elements = document.querySelectorAll(selector);
        if(elements instanceof NodeList || elements instanceof HTMLCollection){
            for (var i = 0; i < elements.length; i++) {
                elements[i].addEventListener(eventType, eventHandler);
            }
        } else if(elements instanceof  Element){
            elements.addEventListener(eventType, eventHandler);
        }
    }

    var elementsBuffer = [];
    var MAX_BUFFER_SIZE = 10;
    function appendToBuffer(element, parentSelector) {
        var parent = document.querySelector(parentSelector);
        elementsBuffer.push(element);
        if (elementsBuffer.length - 1 === MAX_BUFFER_SIZE) {
            var fragment = document.createDocumentFragment();
            for (var i = 0; i < elementsBuffer.length; i++) {
                fragment.appendChild(elementsBuffer[i]);
            }
            parent.appendChild(fragment);
            elementsBuffer = [];
        }
    }

    return {
        appendElement: appendElement,
        removeElement: removeElement,
        addEvent: addEvent,
        appendToBuffer: appendToBuffer
    }
}());
