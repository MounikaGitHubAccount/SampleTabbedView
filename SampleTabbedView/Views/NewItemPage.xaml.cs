using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SampleTabbedView.Models;
using System.Text.RegularExpressions;
using System.IO;
using SampleTabbedView.Services;

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
                Mobile = 0,
                Description = "",
                ImageName = ""
            };

            BindingContext = this;
        }

        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\[0-9]{9})$").Success;
        }

        public static bool IsEmailValidate(string email)
        {
            return Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (Item.Name != "" && Item.Email != "" && Item.Designation != "" && Item.Mobile != 0)
            {               
                if (IsEmailValidate(Item.Email.Trim()))
                {
                    //if (IsPhoneNumber(Item.Mobile))
                    if (Item?.Mobile.ToString().Trim().Length ==9)
                    {
                        MessagingCenter.Send(this, "AddItem", Item);
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        await DisplayAlert("", "Please enter valid 10 digit Phone Number", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("", "Please enter valid Email id", "OK");
                }

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

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Label).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
                imageName.Text = "UploadedImage.png";
            }
            (sender as Label).IsEnabled = true;
        }
    }
}