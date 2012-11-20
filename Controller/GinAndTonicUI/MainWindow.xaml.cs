using DrinkBotLib;
using DrinkBotLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialDrinkBot drinkBot;
        IEnumerable<KeyValuePair<Ingredient, double>> ginAndTonic;

        public MainWindow()
        {
            drinkBot = SerialDrinkBot.Local;

            using(var db = new DrinkBotEntities())
            {
                ginAndTonic = db.Recipes.Single(r => r.Name == "Gin and Tonic");
            }


            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            drinkBot.Dispense(ginAndTonic);
        }
    }
}
