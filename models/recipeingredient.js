'use strict';
module.exports = function(sequelize, DataTypes) {
  var RecipeIngredient = sequelize.define('RecipeIngredient', {
    name: DataTypes.STRING,
    proportion: DataTypes.DECIMAL
  }, {
    classMethods: {
      associate: function(models) {
        RecipeIngredient.belongsTo(models.Recipe)
      }
    }
  });
  return RecipeIngredient;
};
