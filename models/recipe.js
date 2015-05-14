'use strict';
module.exports = function(sequelize, DataTypes) {
  var Recipe = sequelize.define('Recipe', {
    name: DataTypes.STRING
  }, {
    classMethods: {
      associate: function(models) {
        Recipe.hasMany(models.RecipeIngredient, {as: 'Ingredients'})
      }
    }
  });
  return Recipe;
};
