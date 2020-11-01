using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using GSSTaskApplication.Models;
using SampleTabbedView.Models;
using SampleTabbedView.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleTabbedView.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand NewsFieldCommand { get; set; }
        public AboutViewModel()
        {
            NewsFieldCommand = new Command(NewsFieldOnClick);
            Title = "News";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
            FetchToolsDetails();

        }

        private void NewsFieldOnClick(object obj)
        {
            var SelectedField = (Article)obj;
            if (SelectedField != null)
            {
                Launcher.OpenAsync(SelectedField.url);
            }
        }

        public async Task<List<NewsArticle>> FetchToolsDetails()
        {
            SampleService toolsData = new SampleService();
            var SystemsData = await toolsData.FetchProjectCodeDetails();
            return SystemsData;
        }
        //public ICommand OpenWebCommand { get; }
    }
}