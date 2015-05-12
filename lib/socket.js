var products = require('../lib/products');
var channels = require('../lib/channels');
var dispenser = require('../lib/dispenser');

module.exports = function (io) {
  'use strict';
  io.on('connection', function (socket) {
    socket.broadcast.emit('user connected');
    socket.emit('init', {name: 'Peter'});

    var syncDispenses = [];
    socket.on('test-set', function (msg) {
      if(msg.s && !syncDispenses[msg.c])
        channels[msg.c].syncDispense(function(done){
          syncDispenses[msg.c] = done;
        })
      else if(!msg.s && syncDispenses[msg.c]) {
        syncDispenses[msg.c]();
        delete syncDispenses[msg.c];
      }
    });

    socket.on('get-recipes', function (msg, fn) {
      var recipes = require('../lib/recipes');
      fn(recipes);
    });

    socket.on('order', function(msg){
      dispenser.dispenseRecipe(msg.recipe, msg.volume);
    });
    dispenser.ee.on('dispensing', function() { socket.emit('dispensing'); });
    dispenser.ee.on('done-dispensing', function() { socket.emit('done-dispensing'); });
  });
};
