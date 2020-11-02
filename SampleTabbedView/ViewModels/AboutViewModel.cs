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
        }

        private void NewsFieldOnClick(object obj)
        {
            var SelectedField = (NewsArticle)obj;
            if (SelectedField != null)
            {
                Launcher.OpenAsync(SelectedField.url);
            }
        }
    }
}