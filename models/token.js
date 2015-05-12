'use strict';
module.exports = function(sequelize, DataTypes) {
  var Token = sequelize.define('Token', {
    volume: DataTypes.DECIMAL
  }, {
    classMethods: {
      associate: function(models) {
        Token.belongsTo(models.User)
        Token.belongsTo(models.Recipe)
      }
    }
  });
  return Token;
};
