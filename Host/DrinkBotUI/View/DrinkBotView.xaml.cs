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
using System.Windows.Shapes;
using DrinkBotUI.ViewModel;

namespace DrinkBotUI.View
{
    /// <summary>
    /// Interaction logic for DrinkBotView.xaml
    /// </summary>
    public partial class DrinkBotView : Window
    {
        public DrinkBotView()
        {
            this.DataContext = new DrinkBotViewModel();
            InitializeComponent();
        }
    }
}
