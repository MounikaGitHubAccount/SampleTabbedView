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
            if (Item.Name != "" && Item.Email != "" && Item.Designation != "" && Item.Mobile != "")
            {
                MessagingCenter.Send(this, "AddItem", Item);
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("","Please enter all fields!","OK");
            }
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}