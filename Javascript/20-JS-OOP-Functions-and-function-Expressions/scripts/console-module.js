var awesomeConsole = (function () {
    function parseString() {
        var args = arguments;
        var text = args[0];
        var valuesArray = Array.prototype.slice.call(arguments, 1);
        return text.replace(/{(\d+)}/g, function(match, number) {
            return typeof valuesArray[number] != 'undefined' ? valuesArray[number] : match;
        });
    }

    function writeLine() {
        console.log(parseString.apply(null, arguments));
    }
    function writeError() {
        console.error(parseString.apply(null, arguments));
    }
    function writeWarn() {
        console.warn(parseString.apply(null, arguments));
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarn: writeWarn
    }
}());