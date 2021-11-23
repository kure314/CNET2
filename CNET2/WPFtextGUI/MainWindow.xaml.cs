using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPFtextGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Načteno
             string Cesta = @"C:\Programovani\CNET2\CNET2\PlayGround\bin\Debug\net6.0\Books";

            foreach (var file in GetFilesFromDir(Cesta))
            {
                var dict = TextTools.Analyza.FreqAnalysis(file);
                var top10 = TextTools.Analyza.GetTopWords(10, dict);

                var fi = new FileInfo(file);

                txbInfo.Text += fi.Name + Environment.NewLine;
                foreach (var kv in top10)
                {
                    txbInfo.Text += $"{kv.Key}: {kv.Value}{Environment.NewLine}";
                }
            }

            //var top10_string = top10.Select(c=>$"")

            //TextTools.Analyza.GetTopWords(10, "rur.txt");
        }
        static IEnumerable<string> GetFilesFromDir(string dir)
        {
            return Directory.EnumerateFiles(dir);
        }
    }
}
