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
        });
      else if(!msg.s && syncDispenses[msg.c]) {
        syncDispenses[msg.c]();
        delete syncDispenses[msg.c];
      }
    });

    socket.on('test-dispense', function (msg) {
      var fdone;
      channels[msg.c].syncDispense(function(done){
          fdone = done;
      });
      setTimeout(fdone, msg.ms);
    });

    socket.on('test-dispense-vol', function (msg) {
      channels[msg.c].dispense(msg.ml, function(done){
	console.log("Dispenseing " + msg.ml + " of " + msg.c);
      });
    });

    socket.on('index-recipes', function (msg, fn) {
      var recipes = require('../lib/recipes');
      fn(recipes);
    });

    socket.on('get-users', function (msg, fn) {
      var models = require('../models');
      models.User.findAll().then(function(users) {
        fn(users);
      });
    });

    socket.on('order', function(msg){
      dispenser.dispenseRecipe(msg.recipe, msg.volume);
    });
    dispenser.ee.on('dispensing', function() { socket.emit('dispensing'); });
    dispenser.ee.on('done-dispensing', function() { socket.emit('done-dispensing'); });

    function serveModel(model){
      var name = model.options.name;
      socket.on('index-'+name.plural.toLowerCase(), function (msg, fn) {
        models.User.findAll().then(function(users) {
          fn(users);
        });
      });
      var name = model.options.name;
      socket.on('create-'+name.singular.toLowerCase(), function(msg, fn){
        model.create(msg)
          .then(fn())
          .catch(function(error) { fn(error); });
      });
      socket.on('show-'+name.singular.toLowerCase(), function (msg, fn) {
        model.find({where: msg})
          .then(fn())
          .catch(function(error) { fn(error); });
      });
      socket.on('update-'+name.singular.toLowerCase(), function (msg, fn) {
        model.find({where: msg})
          .then(fn())
          .catch(function(error) { fn(error); });
        //TODO: Complete
      });
      socket.on('destroy-'+name.singular.toLowerCase(), function (msg, fn) {
        model.find({where: msg})
          .then(fn())
          .catch(function(error) { fn(error); });
        //TODO: Complete
      });
    }
    var models = require('../models');
    serveModel(models.User);
  });
};
