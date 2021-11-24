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

namespace WPFtextGUI.WebChecker
{
    /// <summary>
    /// Interaction logic for WebControlPanel.xaml
    /// </summary>
    public partial class WebControlPanel : Window
    {
        public WebControlPanel()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            string url = txtURL.Text;
            string term = txtTerm.Text;

           if( Webs.WebToCheck.TryAdd(url, true))
            {
                WebCheck wc = new WebCheck(url, term);
                WebCheckWindow wcw = new WebCheckWindow(wc);
                wcw.Show();
                //wc.Start();
            }
            txtURL.Text = txtTerm.Text = "";
            

        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            string url = txtURL.Text;
            var succ=  Webs.WebToCheck.TryUpdate(url, false, true);
            if (!succ)
            {
                MessageBox.Show($"URL: {url} není v chodu");
            }
        }
    }
}
