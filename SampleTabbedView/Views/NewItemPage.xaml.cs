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
        public static ImageSource UploadedImage { get; set; }
        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Name = "",
                Email = "",
                Designation = "",
                Mobile = "",
                Description = "",
                ImageName = UploadedImage
            };

            BindingContext = this;
        }

        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{12})$").Success;
        }

        public static bool IsEmailValidate(string email)
        {
            return Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (Item.Name != "" && Item.Email != "" && Item.Designation != "" && Item.Mobile != "")
            {
                //Console.WriteLine("{0}correctly entered", IsPhoneNumber(Item.Mobile) ? "" : "in");
               

                if (IsEmailValidate(Item.Email))
                {
                    if (IsPhoneNumber(Item.Mobile))
                    {
                        MessagingCenter.Send(this, "AddItem", Item);
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        await DisplayAlert("", "Please enter valid Phone Number", "OK");
                    }
                    //MessagingCenter.Send(this, "AddItem", Item);
                    //await Navigation.PopModalAsync();
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
                UploadedImage = ImageSource.FromStream(() => stream);
                imageName.Text = "UploadedImage.png";
                MessagingCenter.Send(this, "selected", image.Source);
            }
            (sender as Label).IsEnabled = true;
        }
    }
}