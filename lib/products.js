var channels = require('../lib/channels');

products = {
  "rum": {
      volume: 1000,
      channel: new channels.SimulatedChannel("rum")
  },
  "gin": {
      volume: 1000,
      channel: new channels.SimulatedChannel("gin")
  },
  "whiskey": {
      volume: 1000,
      channel: new channels.SimulatedChannel("whiskey")
  },
  "coke": {
      volume: 1000,
      channel: new channels.SimulatedChannel("coke")
  },
  "tonic": {
      volume: 1000,
      channel: new channels.SimulatedChannel("tonic")
  },
}
