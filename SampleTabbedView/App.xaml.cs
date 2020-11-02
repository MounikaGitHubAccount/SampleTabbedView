using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleTabbedView.Services;
using SampleTabbedView.Views;
using System.IO;

namespace SampleTabbedView
{
    public partial class App : Application
    {

        static LocalDatabase database;
        public static LocalDatabase TasksDatabase
        {
            get
            {
                if (database == null)
                {
                    database = new LocalDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SampleDatabase.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
