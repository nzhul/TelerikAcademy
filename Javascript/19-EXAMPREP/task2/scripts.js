$.fn.tabs = function () {
    var $container = this;
    $container.addClass('tabs-container');

    var $allBtns = $('.tab-item-title');
    $allBtns.on('click', function () {
       var $currentBtn = $(this);
        $currentBtn.parent().addClass('current');
    });



//
//
//    var allTabs = $container.find('.tab-item-content');
//    allTabs.hide();
//    $(allTabs[0]).show();

};