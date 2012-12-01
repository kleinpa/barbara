
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GalaSoft.MvvmLight.Command;
using DrinkBotLib;
using DrinkBotLib.Model;

namespace DrinkBotUI.ViewModel
{
    public class DrinkBotViewModel : ViewModelBase
    {
        public IEnumerable<User> Users
        {
            get
            {
                if (recipeDispenser != null)
                    return recipeDispenser.Users;
                else return default(IEnumerable<User>);
            }
        }
        

        public IEnumerable<Recipe> Recipes
        {
            get
            {
                if (recipeDispenser != null)
                    return recipeDispenser.Recipes;
                else return default(IEnumerable<Recipe>);
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

       

        public bool ReadyToDispense
        {
            get
            {
                return SelectedRecipe != null && SelectedUser != null && recipeDispenser.CanDispense(SelectedRecipe);
            }
        }

        public DrinkBotViewModel()
        {
            DispenseCommand = new RelayCommand(() =>
                {
                    Dispense(SelectedRecipe, SelectedUser);
                });
            new Task(() =>
                {
                    recipeDispenser = new RecipeDispenser(SerialDrinkBot.Local);
                    RaisePropertyChanged("SelectedUser");
                    RaisePropertyChanged("ReadyToDispense");
                    RaisePropertyChanged("Recipes");
                    RaisePropertyChanged("Users");
                }).Start();
        }

        

        private RecipeDispenser recipeDispenser;

        private void Dispense(Recipe recipe, User user)
        {
            recipeDispenser.Dispense(recipe, user);
        }
    }
}
