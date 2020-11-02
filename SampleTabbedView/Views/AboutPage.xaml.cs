using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using GSSTaskApplication.Models;
using Newtonsoft.Json;
using SampleTabbedView.Models;
using SampleTabbedView.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleTabbedView.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            var timer = new System.Threading.Timer((e) =>
            {
                FetchDetails();
            }, null, startTimeSpan, periodTimeSpan);
            
        }

        public async Task<List<NewsArticle>> FetchDetails()
        {
            SampleService toolsData = new SampleService();
            var SystemsData = await toolsData.FetchData();
            Items.ItemsSource = SystemsData;
            return SystemsData;
        }
    }
}