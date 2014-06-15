$.fn.showCoolMessage = function (options) {
    $messageAttachedTo = this;
    var $messageText = $('<span>')
        .addClass('clearfix')
        .text(options.message);
    var $closeBtn = $('<button>')
        .addClass('close');
    var $msgBox = $('<div>')
        .addClass('message');
    switch(options.type){
        case 'error':
            $msgBox.addClass('error');
            $closeBtn.addClass('errorImg');
            break;
        case 'warn':
            $msgBox.addClass('warn');
            $closeBtn.addClass('warnImg');
            break;
        case 'success':
            $msgBox.addClass('success');
            $closeBtn.addClass('successImg');
            break;
    }
    $msgBox.append($messageText).append($closeBtn);
    $messageAttachedTo.append($msgBox);
    $msgBox.delay(3000)
        .animate({
            opacity: 0
        }, 500, function() {
            $msgBox.remove();
        });
};