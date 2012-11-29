
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
        /*private DrinkBotEntities Database;

        public IEnumerable<User> Users
        {
            get
            {
                return Database.Users.Local;
            }
        }
        

        public IEnumerable<Recipe> Recipes
        {
            get
            {
                
                return Database.Recipes.Local;
            }
        }

        private User selectedUser;
        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                this.selectedUser = value;
                RaisePropertyChanged("SelectedUser");
                RaisePropertyChanged("ReadyToDispense");
            }
        }

        private Recipe selectedRecipe;
        public Recipe SelectedRecipe
        { 
            get
            {
                return this.selectedRecipe;
            } 
            set
            {
                this.selectedRecipe = value;
                RaisePropertyChanged("SelectedRecipe");
                RaisePropertyChanged("ReadyToDispense");
            }
        }

        public RelayCommand DispenseCommand { get; set; }

        public string DatabaseState
        {
            get
            {
                return this.Database.Database.Connection.State.ToString();

            }
        }

        public bool ReadyToDispense
        {
            get
            {
                return SelectedRecipe != null && SelectedUser != null && recipeDispenser.CanDispense(SelectedRecipe);
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

            recipeDispenser = new RecipeDispenser(SerialDrinkBot.Local);
        }

        private RecipeDispenser recipeDispenser;

        private void Dispense(Recipe recipe, User user)
        {
            
            recipeDispenser.Dispense(recipe);

            var serving = new Serving();// Database.Servings.Create();
            
            serving.Recipe = recipe.ID;
            serving.User = user.ID;
            serving.Time = DateTime.Now;
            Database.Servings.Add(serving);
            Database.SaveChanges();

        }*/
    }
}
