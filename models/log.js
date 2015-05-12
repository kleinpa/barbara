'use strict';
module.exports = function(sequelize, DataTypes) {
  var Log = sequelize.define('Log', {
    time: DataTypes.TIME,
    volume: DataTypes.DECIMAL
  }, {
    classMethods: {
      associate: function(models) {
        Log.belongsTo(models.Recipe)
        Log.belongsTo(models.User)
      }
    }
  });
  return Log;
};
