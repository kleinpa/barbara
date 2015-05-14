var channels = require('../lib/channels');

products = {
  "rum": {
      volume: 1000,
      channel: channels[0]
  },
  "gin": {
      volume: 1000,
      channel: channels[1]
  },
  "whiskey": {
      volume: 1000,
      channel: channels[2]
  },
  "coke": {
      volume: 1000,
      channel: channels[3]
  },
  "tonic": {
      volume: 1000,
      channel: channels[4]
  },
}

module.exports = products;
