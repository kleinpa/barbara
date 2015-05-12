var config = require('nconf');

var types = {}

types.SimulatedChannel = function(config) {
  this.speed = 20;
  this.dispense = function(volume, callback) {
    setTimeout(function() {
      callback();
    }, volume/this.speed*1000);
  };
}

types.GPIOChannel = function(config) {
  if (!config.pin) throw new Error("GPIO Channel must specify pin number");
  this.speed = 20;

  var valve = new require('onoff').Gpio(config.pin, 'out');
  valve.writeSync(0);

  this.dispense = function(volume, callback) {
    status = true;
    valve.writeSync(1);
    setTimeout(function() {
      valve.write(0, function() {
        callback();
      });
    }, volume/this.speed*1000);
  };
}

module.exports = config.get('channel_spec').map(function(spec) {
  return new types[spec.type](spec);
})
