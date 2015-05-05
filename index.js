var http = require('http');
var _ = require('lodash');
var GPIO = require('onoff').Gpio,

var server = http.createServer(function(req, res) {
  res.writeHead(200);
  res.end('Hello Http');
  toggle();
});
server.listen(8080);

led = new GPIO(25, 'out');
var state = 0;
function toggle() {
  if(state == 1) {
    // turn LED on
    led.writeSync(1);
    state = 0;
  } else {
    // turn LED off
    led.writeSync(0);
    state = 1;
  }
}