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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;


namespace DBGuiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string baseUrl = "http://10.65.67.87:8090/";
        private const string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc" + 
                                         "3MiOiJJbWFnZS1YIEFjY2VzcyBNYW5hZ2VtZW50IFN" +
                                         "5c3RlbSIsInN1YiI6IkRldmVsb3BtZW50IFVzZXIiL" + 
                                         "CJhdWQiOiJEZXZlbG9wbWVudCBTeXN0ZW0iLCJpYXQ" +
                                         "iOjE2MTMwMTU3NjcsImV4cCI6MTY0NDU1MTc2Nywia" +
                                         "nRpIjoiSlRJRDAwMDAwMDAxIn0.JbEHe1zEl0FVklN" +
                                         "Dubwz0gM27eKs6mibeRFDb7KivRk";

        public MainWindow()
        {
            InitializeComponent();
            urlDataSource.Content = baseUrl;
        }

        private async void retrieveData(object sender, RoutedEventArgs e)
        {
            try
            {
                var dbClient = new ImagingDBClientLibrary.DBClient(baseUrl, accessToken);
                var allFractions = await dbClient.getAllFractions();
                patientsDataGrid.ItemsSource = allFractions.fractions;
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                MessageBox.Show("Could not establish to the data server: " + ex.Message);
            }
        }
    }
}
