'use strict';
module.exports = function(sequelize, DataTypes) {
  var User = sequelize.define('User', {
    name: DataTypes.STRING
  }, {
    classMethods: {
      associate: function(models) {
        models.Recipe.hasMany(models.RecipeIngredient, {as: 'Ingredients'})
        User.hasMany(models.Log)
      }
    }
  });
  return User;
};
