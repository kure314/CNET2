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
    /// Interaction logic for WebCheckWindow.xaml
    /// </summary>
    public partial class WebCheckWindow : Window
    {
        private WebCheck webcheck;
        public WebCheckWindow(WebCheck wc)
        {
            InitializeComponent();
            webcheck = wc;
        }

  
        public WebCheck Wc { get; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtWebCheckInfo.Text = $"Spouštím hledání výrazu {webcheck.Term} na webu: {Environment.NewLine}{webcheck.Url}";
            

            //co se má vykonat, když přijde message
            IProgress<string> progress = new Progress<string>(message =>
            {
                txtWebCheckInfo.Text += message;
            });

            webcheck.Start(progress);

            
        }
    }

 
     
}
