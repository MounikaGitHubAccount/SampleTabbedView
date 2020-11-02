using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using SampleTabbedView.Models;
using SampleTabbedView.Services;
using Xamarin.Forms;

namespace SampleTabbedView.ViewModels
{
    public class TestingViewModel : BaseViewModel
    {
        public ICommand UploadCommand { set; get; }
        public ICommand SaveCommand { set; get; }
        public ICommand CancelCommand { set; get; }
        public TestingViewModel()
        {
            UploadCommand = new Command(UploadOnClick);
            SaveCommand = new Command(SaveOnClick);
            CancelCommand = new Command(CancelOnClick);
        }

        private void CancelOnClick(object obj)
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
        }

        async void SaveOnClick(object obj)
        {
            var test = (Item)obj;
            var taskList = await App.TasksDatabase.GetTaskAsync();
            RegisteredList = taskList;
            Item task = new Item()
                {
                    Name = test.Name,
                    Mobile = test.Mobile,
                    Email = test.Email,
                    Designation = test.Designation,
                    ImageName = test.ImageName
            };

                //Add New Task  
                await App.TasksDatabase.SaveTaskAsync(task);
                await Application.Current.MainPage.DisplayAlert("Success", "Task added Successfully", "OK");
                //Get All Tasks  
                //var taskList = await App.TasksDatabase.GetTaskAsync();
                RegisteredList = taskList;
        }

        async void UploadOnClick(object obj)
        {
            //var test = obj;
            IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                ImageName = ImageSource.FromStream(() => stream);
                //UploadedImage = ImageSource.FromStream(() => stream);
                UploadImageName = "UploadedImage.png";
               // MessagingCenter.Send(this, "ImageName", ImageName);
            }
            IsEnabled = true;
        }

        bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        string _mobile;
        public string Mobile
        {
            get => _mobile;
            set
            {
                _mobile = value;
                OnPropertyChanged("Mobile");
            }
        }

        string _designation;
        public string Designation
        {
            get => _designation;
            set
            {
                _designation = value;
                OnPropertyChanged("Designation");
            }
        }

        ImageSource _imageName;
        public ImageSource ImageName
        {
            get => _imageName;
            set
            {
                _imageName = value;
                OnPropertyChanged("ImageName");
            }
        }

        string _uploadImageName;
        public string UploadImageName
        {
            get => _uploadImageName;
            set
            {
                _uploadImageName = value;
                OnPropertyChanged("UploadImageName");
            }
        }

        List<Item> _registeredList;
        public List<Item> RegisteredList
        {
            get => _registeredList;
            set
            {
                _registeredList = value;
                OnPropertyChanged("RegisteredList");
            }
        }
    }
}

