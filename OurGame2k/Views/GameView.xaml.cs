using OurGame2k.ViewModels;
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

namespace OurGame2k.Views
{
    public partial class GameView : Window
    {
        public GameView()
        {
            InitializeComponent();
            GameViewModel viewModel = new GameViewModel();
            this.DataContext = viewModel;
        }
    }
}
