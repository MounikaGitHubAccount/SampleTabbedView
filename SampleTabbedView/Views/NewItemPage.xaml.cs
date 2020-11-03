using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SampleTabbedView.Models;
using System.Text.RegularExpressions;
using System.IO;
using SampleTabbedView.Services;
using SampleTabbedView.ViewModels;

namespace SampleTabbedView.Views
{
    public partial class NewItemPage : ContentPage
    {
        ItemsViewModel _itemsViewModel;
        public Item Item { get; set; }
        public NewItemPage()
        {
            InitializeComponent();
            //_itemsViewModel = new ItemsViewModel();
            //BindingContext = _itemsViewModel;
            Item = new Item
            {
                Name = "",
                Email = "",
                Designation = "",
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
                        //    Item task = new Item()
                        //    {
                        //        Name = Item.Name,
                        //        Email = Item.Email,
                        //        Mobile = Item.Mobile,
                        //        Designation = Item.Designation
                        //    };

                        ////Add New Task  
                        //await App.TasksDatabase.SaveTaskAsync(task);
                        //await Application.Current.MainPage.DisplayAlert("Success", "Task added Successfully", "OK");
                        //Get All Tasks  
                        //_itemsViewModel.Items1 = await App.TasksDatabase.GetTaskAsync();
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