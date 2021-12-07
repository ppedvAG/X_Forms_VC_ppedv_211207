using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());

            MainPage = new AsyncBsp();
        }

        public DateTime timestamp { get; set; } = DateTime.Now;

        protected override void OnStart()
        {
            MainPage.DisplayAlert("Start", $"App started: {timestamp.ToShortTimeString()}", "OK");
        }

        protected override void OnSleep()
        {
            timestamp = DateTime.Now;
        }

        protected override void OnResume()
        {
            MainPage.DisplayAlert("Restart", $"Sleeptime: {DateTime.Now.Subtract(timestamp).ToString()}", "OK");

        }
    }
}
