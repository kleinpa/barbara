'use strict';
module.exports = {
  up: function(queryInterface, Sequelize) {
    return queryInterface.createTable('Logs', {
      id: {
        allowNull: false,
        autoIncrement: true,
        primaryKey: true,
        type: Sequelize.INTEGER
      },
      time: {
        type: Sequelize.TIME
      },
      volume: {
        type: Sequelize.DECIMAL
      },
      UserId: {
        type: Sequelize.INTEGER,
        references: 'Users',
        referencesKey: 'id'
      },
      RecipeId: {
        type: Sequelize.INTEGER,
        references: 'Recipes',
        referencesKey: 'id'
      },
      createdAt: {
        allowNull: false,
        type: Sequelize.DATE
      },
      updatedAt: {
        allowNull: false,
        type: Sequelize.DATE
      }
    });
  },
  down: function(queryInterface, Sequelize) {
    return queryInterface.dropTable('Logs');
  }
};
