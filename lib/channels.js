module.exports.SimulatedChannel = function(i) {
  this.speed = 20;
  this.status = false;
  this.dispense = function(volume, callback) {
    status = true;
    setTimeout(function() {
      console.log("Done dispensing channel " + i);
      callback();
    }, volume/this.speed*1000);
  };
}
