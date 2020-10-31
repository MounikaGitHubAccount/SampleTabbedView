using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using GSSTaskApplication.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleTabbedView.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            GetJsonData();
        }
        void GetJsonData()
        {
            string jsonFileName = "BitCoin.json";
            BitCoin ObjContactList = new BitCoin();
            var assembly = typeof(AboutPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();
                ObjContactList = JsonConvert.DeserializeObject<BitCoin>(jsonString);
            }
            Items.ItemsSource = ObjContactList.articles;
        }
    }
}