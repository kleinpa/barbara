module.exports.SimulatedChannel = function(i) {
  this.speed = 20;
  this.dispense = function(volume, callback) {
    setTimeout(function() {
      callback();
    }, volume/this.speed*1000);
  };
}

module.exports.GPIOChannel = function(pin) {
  this.speed = 20;

  var valve = new require('onoff').Gpio(pin, 'out');
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
