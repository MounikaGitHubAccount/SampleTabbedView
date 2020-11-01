using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SampleTabbedView.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleTabbedView.Services
{
    public class SampleService : ContentPage
    {
        HttpClient httpClient;
        DateTime requestTime;
    public SampleService()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        this.httpClient = new HttpClient();
    }
    public async Task<List<NewsArticle>> FetchProjectCodeDetails()
    {
        try
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                List<NewsArticle> ProjectCodeList = new List<NewsArticle>();
                var url = "https://newsapi.org/v2/top-headlines?country=in&apiKey=f023a2d747aa4b82ad9f2441ce30d039";
                //var url = "https://newsapi.org/v2/everything?q=bitcoin&from=2020-10-01&sortBy=publishedAt&apiKey=f023a2d747aa4b82ad9f2441ce30d039";
                //var url = "https://api.androidhive.info/contacts/";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                //var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

                string Response_JSON = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ProjectCodeList = JsonConvert.DeserializeObject<NewsExample>(content).articles;
                }
                else
                {
                    Console.WriteLine(" Test:123" + response.RequestMessage);
                }
            }
            else
            {
                //await Application.Current.MainPage.DisplayAlert("", Resources.Strings.NetworkErrorMessage, "Ok");
            }
        }
        catch (Exception Exe)
        {

        }

        return null;

    }

}
}
