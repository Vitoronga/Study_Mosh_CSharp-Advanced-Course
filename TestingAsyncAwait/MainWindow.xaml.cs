using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace TestingAsyncAwait
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

        private async void main_button_Click(object sender, RoutedEventArgs e)
        {
            //DownloadHTMLAsync("https://msdn.microsoft.com");
            //var html = await GetHtmlAsync("https://msdn.microsoft.com");

            var getHtmlTask = GetHtmlAsync("https://msdn.microsoft.com");
            MessageBox.Show("Waiting task to be completed.");
            
            var html = await getHtmlTask;            
            MessageBox.Show(html.Substring(0, 10));
        }

        private async Task<string> GetHtmlAsync(string url)
        {
            var httpClient = new HttpClient();

            return await httpClient.GetStringAsync(url);
        }

        private string GetHtml(string url)
        {
            var httpClient = new HttpClient();

            return httpClient.GetStringAsync(url).Result;
        }

        private async Task DownloadHTMLAsync(string url)
        {
            var httpClient = new HttpClient();
            string html = await httpClient.GetStringAsync(url);

            using (var streamWriter = new StreamWriter(@"c:\a_html_file.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }

        private void DownloadHTML(string url)
        {
            var httpClient = new HttpClient();
            //HttpResponseMessage response = httpClient.GetAsync(url).Result;
            //HttpContent content = response.Content;
            //string html = content.ReadAsStringAsync().Result;
            string html = httpClient.GetStringAsync(url).Result;

            using (var streamWriter = new StreamWriter(@"c:\a_html_file.html"))
            {
                streamWriter.Write(html);
            }
        }
    }
}
