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
        }

        protected override void OnStart()
        {
            // if we want to force users to update to a new version, we can send a silent push notification
            // with the version that is no longer supported, and then compare that here
            var deprecatedVersion = Xamarin.Essentials.Preferences.Get("DeprecatedVersion", string.Empty);
            if (Xamarin.Essentials.VersionTracking.CurrentVersion == deprecatedVersion)
            {
                MainPage = new PleaseUpdateAppPage();
            }
            else
            { 
                SessionManager.Instance.OnSessionExpired = HandleSessionExpired; 
                SessionManager.Instance.StartTrackSessionAsync();

                MainPage = new ChecksPage();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private async void HandleSessionExpired(object sender, EventArgs e)
        {
            // Log the user out
            SessionManager.Instance.EndTrackSession();
        }
    }
}
