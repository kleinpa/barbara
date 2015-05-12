"use strict";

var Sequelize = require('sequelize');

module.exports = function(sequelize, DataTypes) {
  var RecipeIngredient = sequelize.define('RecipeIngredient', {
    name: {type: Sequelize.STRING},
    porportion: {type: Sequelize.FLOAT}
  });
  var Recipe = sequelize.define('Recipe', {
    name: {type: Sequelize.STRING}
  });
  return Recipe;
};
