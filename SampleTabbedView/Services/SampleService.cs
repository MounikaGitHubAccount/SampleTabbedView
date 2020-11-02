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
                        url = "https://newsapi.org/v2/top-headlines?country=in&apiKey=f023a2d747aa4b82ad9f2441ce30d039";
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
