"use strict";

var Sequelize = require('sequelize');

module.exports = function(sequelize, DataTypes) {
  var Product = sequelize.define('Product', {
    name: Sequelize.STRING,
  });
  return Product;
};
