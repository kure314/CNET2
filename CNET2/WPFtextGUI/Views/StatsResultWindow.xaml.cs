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

namespace WPFtextGUI.Views
{
    /// <summary>
    /// Interaction logic for StatsResultWindow.xaml
    /// </summary>
    public partial class StatsResultWindow : Window
    {
        public StatsResultWindow(Model.StatsResult result)
        {
            InitializeComponent();
            //StatsResultView
            //userConstrolStatsResultView.

            //dataBindig pro userControlku
            DataContext = result;
        }

        private void btnShowName_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
