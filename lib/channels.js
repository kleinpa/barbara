function SimulatedChannel(i) {
  this.status = false;
  this.start = function() {
    status = true;
    console.log("Dispensing channel " + i);
  };
  this.stop = function() {
    status = false;
    console.log("Done dispensing channel " + i);
  };
}

module.exports.SimulatedChannel = SimulatedChannel
