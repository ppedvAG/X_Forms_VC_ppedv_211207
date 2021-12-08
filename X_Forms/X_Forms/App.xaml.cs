using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    public partial class App : Application
    {
        //Die App-Klasse beinhaltet eine grundlegen Initialisierung der App sowie die MainPage-Property, welche defniert,
        //welche Page gerade in der App angezeigt wird. Diese Property wird auch als Einstiegspunkt verwendet.
        public App()
        {
            InitializeComponent();

            //Zuweisung der MainPage-Property zu einer Page
            //MainPage = new MainPage();

            //Zuweisung der MainPage - Property zu einer NavigationPage(ermöglicht Stack - Navigation) mit Angabe der Startpage.
            //MainPage = new NavigationPage(new MainPage());

            MainPage = new NavigationBsp.FlyoutBsp.FlyoutP();
        }

        public DateTime timestamp { get; set; } = DateTime.Now;

        //Methoden, welche zu bestimmten globalen Events ausgeführt werden (Start, Unterbrechen der App [Sleep], Wiederaktivierung der App [Resume])
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
