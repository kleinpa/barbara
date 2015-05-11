var rpitest = require('../lib/rpitest');
var products = require('../lib/products');
var dispenser = require('../lib/dispenser');

module.exports = function (io) {
  'use strict';
  io.on('connection', function (socket) {
    socket.broadcast.emit('user connected');
    socket.emit('init', {name: 'Peter'});
    socket.on('test-set', function (msg) {
      rpitest.set(msg.c, msg.s);
    });
    socket.on('request-recipe-list', function (msg) {
      var recipes = require('../lib/recipes');
      socket.emit('recipe-list', recipes);
    });
    socket.on('order', function(msg){
      dispenser.dispenseRecipe(msg.recipe, msg.volume);
    });
    dispenser.ee.on('dispensing', function() { socket.emit('dispensing'); });
    dispenser.ee.on('done-dispensing', function() { socket.emit('done-dispensing'); });
  });
};
