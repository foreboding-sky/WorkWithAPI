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
using TestAPI.ViewModels;

namespace TestAPI.Views
{
    /// <summary>
    /// Interaction logic for TopCoinsView.xaml
    /// </summary>
    public partial class TopCoinsView : Page
    {
        public TopCoinsView()
        {
            InitializeComponent();
            this.DataContext = new TopCoinsViewModel();
        }
    }
}
