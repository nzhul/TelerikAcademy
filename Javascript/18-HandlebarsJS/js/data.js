function generateData(rows) {
    var data = {
        rows: []
    };

    for (var i = 0; i < rows; i++) {
        data.rows.push({
            number: i,
            title: 'Random title ' + i,
            date1: randomDate(new Date(2012, 0, 1), new Date()).format("isoDateTime"),
            date2: randomDate(new Date(2012, 0, 1), new Date()).format("isoDateTime")
        });
    }
    return data;
}

function randomDate(start, end) {
    var currDate = new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));
    return currDate;
}