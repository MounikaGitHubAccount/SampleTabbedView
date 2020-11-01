using System;
using System.Collections.Generic;

namespace SampleTabbedView.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string Description { get; set; }
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

    public class NewsArticle
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
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