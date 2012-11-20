using DrinkBotLib.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GalaSoft.MvvmLight.Command;
using DrinkBotLib;

namespace DrinkBotUI.ViewModel
{
    public class DrinkBotViewModel : ViewModelBase
    {
        private DrinkBotEntities Database;

        public IEnumerable<User> Users
        {
            get
            {
                return Database.Users.Local;
            }
        }
        public User SelectedUser { get; set; }

        public IEnumerable<Recipe> Recipes
        {
            get
            {
                
                return Database.Recipes.Local;
            }
        }
        public Recipe SelectedRecipe { get; set; }

        public RelayCommand DispenseCommand { get; set; }

        public string DatabaseState
        {
            get
            {
                return this.Database.Database.Connection.State.ToString();

            }
        }

        public DrinkBotViewModel()
        {
            this.Database = new DrinkBotEntities();
            //this.Database.Database.Connection.Open();
            
            Database.Recipes.Load();
            Database.Users.Load();
            

            this.Database.Database.Connection.StateChange += (s,e) =>
                {
                    RaisePropertyChanged("DatabaseState");
                };

            DispenseCommand = new RelayCommand(() =>
                {
                    Dispense(SelectedRecipe, SelectedUser);
                });
            drinkBot = SerialDrinkBot.Local;
        }

        private DrinkMaker drinkBot;

        private void Dispense(Recipe recipe, User user)
        {
            
            drinkBot.Dispense(recipe);

            var serving = new Serving();// Database.Servings.Create();
            
            serving.Recipe = recipe.ID;
            serving.User = user.ID;
            serving.Time = DateTime.Now;
            Database.Servings.Add(serving);
            Database.SaveChanges();

        }
    }
}
