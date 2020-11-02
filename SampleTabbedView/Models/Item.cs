using System;
using System.Collections.Generic;
using SampleTabbedView.ViewModels;
using Xamarin.Forms;

namespace SampleTabbedView.Models
{
    public class Item : BaseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public int? Mobile { get; set; }
        public string Description { get; set; }
        string _imageName = "profile.png";
        public string ImageName
        {
            get => _imageName;
            set
            {
                _imageName = value;
                OnPropertyChanged("ImageName");
            }
        }
    }

    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class NewsSource
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class NewsArticle : BaseViewModel
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

    public class NewsExample
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<NewsArticle> articles { get; set; }
    }
}