var products = require('../lib/products');

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
      products.dispenseRecipe(msg.recipe, msg.volume);
    });
  });
};
