'use strict';
module.exports = function(sequelize, DataTypes) {
  var Product = sequelize.define('Product', {
    channel: DataTypes.INTEGER,
    name: DataTypes.STRING
  }, {
    classMethods: {
      associate: function(models) {
        // associations can be defined here
      }
    }
  });
  return Product;
};