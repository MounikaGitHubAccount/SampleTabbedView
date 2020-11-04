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
        public async Task<List<NewsArticle>> FetchData()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    var handler = new HttpClientHandler();
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                    {
                        return true;
                    };

                    using (var client = new HttpServiceClient(handler))
                    {
                        List<NewsArticle> NewsList = new List<NewsArticle>();
                        var url = "";
                        url = "http://newsapi.org/v2/top-headlines?country=in&apiKey=833ca843b58d482b8219e2665ca77afd";
                        HttpResponseMessage response = await client.GetAsync(url);
                        string Response_JSON = await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            NewsList = JsonConvert.DeserializeObject<NewsExample>(content).articles;
                            return NewsList;
                        }
                        else
                        {
                            Console.WriteLine(" Test:123" + response.RequestMessage);
                        }
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("", "NetworkErrorMessage", "Ok");
                }
            }
            catch (Exception Exe)
            {

            }

            return null;

        }

    }
}
