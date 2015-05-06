var models  = require('../models');
var express = require('express');
var router = express.Router();

router.get('/', function(req, res) {
  require('../lib/rpitest').toggle()
  models.User.findAll({
  }).then(function(users) {
    res.render('index', {
      title: 'Express',
      users: users
    });
  });
});

router.post('/create', function(req, res) {
  models.User.create({
    username: req.param('username')
  }).then(function() {
    res.redirect('/');
  });
});

module.exports = router;
