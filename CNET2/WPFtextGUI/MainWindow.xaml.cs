using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        static string bigFilesDirectory = @"C:\Programovani\bigfiles";



        //  var d= Directory.EnumerateFiles(bigFilesDirectory, "*.txt");
        static IEnumerable<string> getBigFiles()
        {
            return Directory.EnumerateFiles(bigFilesDirectory, "*.txt");
        }




        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Načteno
            // string Cesta = @"C:\Programovani\CNET2\CNET2\PlayGround\bin\Debug\net6.0\Books";

            //var d = Directory.EnumerateFiles(bigFilesDirectory, "*.txt");
            //foreach (var file in GetFilesFromDir(Cesta))
            //{
            //    var dict = await TextTools.Analyza.FreqAnalysisFromFile(big);
            //    var top10 =  TextTools.Analyza.GetTopWords(10, dict);

            //    var fi = new FileInfo(file);

            //    txbInfo.Text += fi.Name + Environment.NewLine;
            //    foreach (var kv in top10)
            //    {
            //        txbInfo.Text += $"{kv.Key}: {kv.Value}{Environment.NewLine}";
            //    }
            //}

            //var top10_string = top10.Select(c=>$"")

            //TextTools.Analyza.GetTopWords(10, "rur.txt");
        }
        static IEnumerable<string> GetFilesFromDir(string dir)
        {
            return Directory.EnumerateFiles(dir);
        }

        private async void btn_load_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            var files = getBigFiles();
           

            txbInfo.Text = "";
            progressBar.Value = 0.0;
            foreach (var file in files)
            {
                var ww = await TextTools.Analyza.FreqAnalysisFromFileAsync(file, Environment.NewLine);
                var top10 = TextTools.Analyza.GetTopWords(10, ww);

                txbInfo.Text += $"Analýza pro soubor {file}{Environment.NewLine}";

                foreach (var polozka in top10)
                {
                    txbInfo.Text += $"Slovo: {polozka.Key}, počet: {polozka.Value}{Environment.NewLine}";
                }

                progressBar.Value += 100.0 / files.Count();
            }
            btn_load.Content = "Načteno";
            stopwatch.Stop();
            txt_debug.Text = $"Délka trvání: {stopwatch.Elapsed} = {stopwatch.ElapsedMilliseconds} ms";
            Mouse.OverrideCursor = null;
            //// var file = System.IO.Path.Combine(bigFilesDirectory, "words01.txt");
            // //var content = File.ReadAllText(file);
            // txbInfo.Text = "Načteno";
            // var analyza = TextTools.Analyza.FreqAnalysis(file);
            // Dictionary<string,int> vysledek= TextTools.Analyza.GetTopWords(10, analyza);

            // txbInfo.Text = "Analýza pro soubor " + file;
            // foreach (var item in vysledek)
            // {
            //     txbInfo.Text += $"Slovo: {item.Key}, počet {item.Value}";
            // }
        }

        private void btn_load2_Click(object sender, RoutedEventArgs e)
        {

            Stopwatch stopwatch = new();
            stopwatch.Start();


            var files2 = getBigFiles();
            var allwords = string.Join(Environment.NewLine, files2.Select(f => File.ReadAllText(f)));

            var dict = TextTools.Analyza.FreqAnalysisFromString(allwords, Environment.NewLine);
            var top10 = TextTools.Analyza.GetTopWords(10, dict);

            //txbInfo.Text += fi.Name + Environment.NewLine;
            txbInfo.Text = "";
            foreach (var kv in top10) txbInfo.Text += $"{kv.Key}: {kv.Value}{Environment.NewLine}";
            stopwatch.Stop();
            txt_debug.Text = $"trvání {stopwatch.Elapsed}";
        }

        private void btnStatsAllParallel_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();


            stopwatch.Stop();
            txt_debug.Text = $"Trvání: {stopwatch.Elapsed}";
        }
    }



}

