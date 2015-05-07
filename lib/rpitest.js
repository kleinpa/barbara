var GPIO = require('onoff').Gpio,
channel_pin = {
  0: new GPIO(25, 'out'),
  1: new GPIO(24, 'out'),
  2: new GPIO(23, 'out'),
  3: new GPIO(22, 'out'),
  4: new GPIO(27, 'out')
};

module.exports.set = function(channel, state) {
  channel_pin[channel].writeSync(state);
}


