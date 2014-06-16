function createCalendar(selector, events) {
    var daysOfWeek = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
    var selectedBox = null;
    var calendarParent = document.querySelector(selector);
    calendarParent.style.width = '1100px';
    var fragment = document.createDocumentFragment();
    var dayBox = document.createElement('div');
    dayBox.style.width = '150px';
    dayBox.style.height = '150px';
    dayBox.style.border = '1px solid black';
    dayBox.style.display = 'inline-block';
    dayBox.style.cursor = 'pointer';

    var boxTitle = document.createElement('strong');
    boxTitle.style.display = 'block';
    boxTitle.style.width = '100%';
    boxTitle.style.height = '25px';
    boxTitle.style.background = 'lightgray';
    boxTitle.style.borderBottom = '1px solid black';
    boxTitle.style.textAlign = 'center';
    boxTitle.style.lineHeight = '25px';

    dayBox.appendChild(boxTitle);

    for (var i = 1; i <= 30; i++) {
        boxTitle.innerHTML = daysOfWeek[i % 7] + ' ' + i + ' June 2014';
        var currentBox = dayBox.cloneNode(true);
        currentBox.addEventListener('click', function () {
            var clickedBox = this;
            if(selectedBox){
                selectedBox.style.background = '';
            }
            clickedBox.style.background = 'green';
            selectedBox = clickedBox;
        });
        currentBox.addEventListener('mouseover', function () {
            var hoveredBox = this;
            if(hoveredBox != selectedBox){
                hoveredBox.style.background = 'yellowgreen';
            }
        });
        currentBox.addEventListener('mouseout', function () {
            var hoveredBox = this;
            if(hoveredBox != selectedBox){
                hoveredBox.style.background = '';
            }
        })
        fragment.appendChild(currentBox);
    }
    calendarParent.appendChild(fragment);
}