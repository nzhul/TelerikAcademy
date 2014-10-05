/*global console, $*/
var Sender = (function (data) {
    "use strict";

    var _form = document.getElementById('file-form'),
        _fileSelect = document.getElementById('file-select'),
        i = null,
        image = null;

    function getUploadedImagesNames(urlData) {
        var parsingDone = false,
            currentEndIndex = 0,
            currentString = urlData,
            files = [];

        while (!parsingDone) {
            currentEndIndex = currentString.indexOf('[|]');

            if (currentEndIndex <= 0) {
                if (currentString.length > 30) {
                    files.push(currentString);
                }

                parsingDone = true;
                console.log(files);
                return files;
            }

            files.push(currentString.substring(0, currentEndIndex));
            currentString = currentString.substring(currentEndIndex + 3);
        }
    }

    // TODO : fix it using the best practices
    function insertImages(images) {
        var $imageLinkDiv = $("#guidLinks");

        for (var image in images) {
            if (images.hasOwnProperty(image)) {
                $imageLinkDiv.append('<a href="getImage/' + images[image] + '">image</a> </br>');
            }
        }
    }

    _form.onsubmit = function (event) {
        event.preventDefault();

        var files = _fileSelect.files,
            imagesForm = new FormData();

        for (i = 0; i < files.length; i += 1) {
            image = files[i];
            if (image.type && image.type.match('image.*')) {
                imagesForm.append('photos', image, image.name);
            }
        }

        $.ajax({
            url: "uploads",
            type: "POST",
            data: imagesForm,
            async: false,
            success: function (msg) {
                insertImages(getUploadedImagesNames(msg));
            },
            cache: false,
            contentType: false,
            processData: false
        });
    };
}
());