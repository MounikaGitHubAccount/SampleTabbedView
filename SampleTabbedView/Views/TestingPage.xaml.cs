using System;
using System.Collections.Generic;
using SampleTabbedView.ViewModels;
using Xamarin.Forms;

namespace SampleTabbedView.Views
{
    public partial class TestingPage : ContentPage
    {
        TestingViewModel _testingViewModel;
        public TestingPage()
        {
            InitializeComponent();
            _testingViewModel = new TestingViewModel();
            BindingContext = _testingViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _testingViewModel.RegisteredList = await App.TasksDatabase.GetTaskAsync();
        }
    }
}
