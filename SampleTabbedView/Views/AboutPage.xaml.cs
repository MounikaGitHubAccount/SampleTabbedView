﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using GSSTaskApplication.Models;
using Newtonsoft.Json;
using SampleTabbedView.Models;
using SampleTabbedView.Services;
using SampleTabbedView.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleTabbedView.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            //if (Items.ItemsSource == null)
            //{
            //    lblNodata.IsVisible = true;
            //    //loader.IsVisible = false;
            //}
            //else
            //{
            //    lblNodata.IsVisible = false;
            //    //loader.IsVisible = true;
            //}
        }
    }
}