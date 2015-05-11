var channels = require('../lib/channels');

products = {
  "rum": {
      volume: 1000,
      channel: new channels.SimulatedChannel()
  },
  "gin": {
      volume: 1000,
      channel: new channels.SimulatedChannel()
  },
  "whiskey": {
      volume: 1000,
      channel: new channels.SimulatedChannel()
  },
  "coke": {
      volume: 1000,
      channel: new channels.SimulatedChannel()
  },
  "tonic": {
      volume: 1000,
      channel: new channels.SimulatedChannel()
  },
}

function checkRecipe(recipe, recipeVolume) {
  var recipeTotalProportion = recipe.ingredients.reduce(function(total, x){
    return total + x.proportion; }, 0);
  recipe.ingredients.forEach(function (ingredient) {
    var volume = ( ingredient.proportion/recipeTotalProportion ) * recipeVolume
    console.log(volume + "ml " + ingredient.name);
  });
}

module.exports.dispenseRecipe = function(recipe, volume){
  console.log("About to dispense a " + recipe.name);
  checkRecipe(recipe, volume);
};
