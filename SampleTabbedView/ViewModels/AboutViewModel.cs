using System;
using System.Windows.Input;
using GSSTaskApplication.Models;
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
        }

        private void NewsFieldOnClick(object obj)
        {
            var SelectedField = (Article)obj;
            if (SelectedField != null)
            {
                Launcher.OpenAsync(SelectedField.url);
            }
        }

        //public ICommand OpenWebCommand { get; }
    }
}