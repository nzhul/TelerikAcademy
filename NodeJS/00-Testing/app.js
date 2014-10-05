var http = require('http');
var fs = require('fs');

var port = 1234;

http.createServer(function (request, response) {
   fs.readFile('index.html', function (err, data) {
       response.write(data);
       response.end();
   })
}).listen(port);