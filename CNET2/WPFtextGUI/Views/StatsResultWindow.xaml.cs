using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

        private async void btnShowName_Click(object sender, RoutedEventArgs e)
        {
            //using System.Net.WebClient webClient   
            Model.StatsResult result = DataContext as Model.StatsResult;

            string localHost = @"https://localhost:7223/";

            using HttpClient httpClient = new();

            httpClient.BaseAddress = new Uri(localHost);

            var res= await httpClient.PostAsJsonAsync<Model.StatsResult>("/stats", result);

            //var res = await httpClient.PostAsJsonAsync<Model.StatsResult>("/stats", result);

            if (res.IsSuccessStatusCode)
                this.Close();
            else
                MessageBox.Show($"Status code:{res.StatusCode}");

    
        }
    }
}
