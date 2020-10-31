using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SampleTabbedView.Models;

namespace SampleTabbedView.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Name = "",
                Email = "",
                Designation = "",
                Mobile = "",
                Description = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            Navigation.PopModalAsync();
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}