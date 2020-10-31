using System;
using System.Collections.Generic;
using SampleTabbedView.ViewModels;
using Xamarin.Forms;

namespace GSSTaskApplication.Models
{
    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Article : BaseViewModel
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        //public string urlToImage { get; set; }
        string _urlToImage;
        public string urlToImage
        {
            get { return _urlToImage; }
            set
            {
                if (value == null || value == "")
                {
                    NoImage = true;
                }
                _urlToImage = value;
                OnPropertyChanged("urlToImage");
            }
        }

        bool _noImage = false;
        public bool NoImage
        {
            get { return _noImage; }
            set
            {
                _noImage = value;
                OnPropertyChanged("NoImage");
            }
        }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }

    public class BitCoin
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }
}

