rpitest = require('../lib/rpitest')
module.exports = function (io) {
  'use strict';
  io.on('connection', function (socket) {
    socket.broadcast.emit('user connected');
    socket.emit('init', {name: 'Peter'});
    socket.on('test-set', function (msg) {
      rpitest.set(msg.c, msg.s);
    });
  });
};
