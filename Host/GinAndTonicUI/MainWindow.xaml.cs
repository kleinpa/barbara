﻿using DrinkBotLib;
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

namespace GinAndTonicUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecipeDispenser dispenser;

        public MainWindow()
        {
            dispenser = new RecipeDispenser(SerialDrinkBot.Local); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dispenser.Dispense("Gin and Tonic");
        }
    }
}