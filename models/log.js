"use strict";

var Sequelize = require('sequelize');

module.exports = function(sequelize, DataTypes) {
  var Log = sequelize.define('Log', {
    time: {type: Sequelize.DATE}
  });
  return Log;
};
