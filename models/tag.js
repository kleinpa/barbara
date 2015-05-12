"use strict";

var Sequelize = require('sequelize');

module.exports = function(sequelize, DataTypes) {
  var Token = sequelize.define('Token', {
    volume: Sequelize.FLOAT
  }, {
    classMethods: {
      associate: function(models) {
	Token.belongsTo(models.User);
	Token.hasOne(models.Recipe);
      }
    }});
  return Token;
};
