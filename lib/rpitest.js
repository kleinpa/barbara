var GPIO = require('onoff').Gpio,

led = new GPIO(25, 'out');
var state = false;
function toggle() {
  led.writeSync(state?1:0);
  state = !state;
}

module.exports.toggle = toggle;
