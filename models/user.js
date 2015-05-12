"use strict";

var Sequelize = require('sequelize');

module.exports = function(sequelize, DataTypes) {
  var User = sequelize.define('User', {
    username: Sequelize.STRING,
    birthday: Sequelize.DATE
  });
  return User;
};
