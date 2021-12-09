using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class McSubscriberPage : ContentPage
    {
        public McSubscriberPage()
        {
            InitializeComponent();

            //Abonieren der Nachricht unter Angabe von <Sender, Inhaltstyp>(Empfänger, Titel, Callback-Methode)
            MessagingCenter.Subscribe<MainPage, string>(this, "Nachricht", (sender, inhalt) => Lbl_Main.Text = inhalt);
        }
    }
}