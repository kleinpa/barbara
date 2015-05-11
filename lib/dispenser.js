var channels = require('../lib/channels');

var config = require('nconf');
config.get('channels');

var events = require('events');
module.exports.ee = new events.EventEmitter();

function checkRecipe(recipe, recipeVolume) {
  var recipeTotalProportion = recipe.ingredients.reduce(function(total, x){
    return total + x.proportion; }, 0);
  return recipe.ingredients.map(function (ingredient) {
    return {
      channel: products[ingredient.name].channel,
      volume: ( ingredient.proportion/recipeTotalProportion ) * recipeVolume
    }
  });
}

var canDispense = true;

module.exports.dispenseRecipe = function(recipe, volume, callback){
  if(!canDispense) {
    if(callback) callback("Can not dispense now");
    return;
  }

  module.exports.ee.emit('dispensing');
  canDispense = false;

  console.log("About to dispense a " + recipe.name);
  var steps = checkRecipe(recipe, volume);

  var stepsRemaining = steps.length;
  steps.forEach(function (step) {
    step.channel.dispense(step.volume, function() {
      --stepsRemaining;
      if (stepsRemaining == 0) {
        console.log("Done dispensing " + recipe.name);
        canDispense = true;
        module.exports.ee.emit('done-dispensing');
        if(callback) callback();
      }
    });
  });
};
