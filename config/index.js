var nconf = require('nconf');

// setup nconf
nconf.argv()
  .env()
  .add('user', { type: 'file', file: 'config/local.json' })
  .add('default', { type: 'file', file: 'config/default.json' });

module.exports = nconf;
