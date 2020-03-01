using System;
using Xamarin.Forms; 
using TestApp.Views;

namespace TestApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new ChecksPage();
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
