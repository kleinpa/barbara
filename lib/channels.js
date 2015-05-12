var config = require('../config');

var types = {}

types.SimulatedChannel = function(config) {
  this.speed = 20;
  this.dispense = function(volume, callback) {
    setTimeout(function() {
      callback();
    }, volume/this.speed*1000);
  };

  this.syncDispense = function(callback) {
    status = true;
    console.log("Start sync dispense");

    var done = function(callback){
      clearTimeout(to);
      console.log("Stop sync dispense");
    }

    var to = setTimeout(done, 10*1000);
    callback(done);
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

  this.syncDispense = function(callback) {
    status = true;
    valve.writeSync(1);

    var done = function(callback){
      clearTimeout(to);
      valve.write(0);
    }

    var to = setTimeout(done, 10*1000);
    callback(done);
  };
}

module.exports = config.get('channel_spec').map(function(spec) {
  return new types[spec.type](spec);
})
