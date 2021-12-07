using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace X_Forms
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Vorname="Rainer", Nachname="Zufall"},
            new Person(){Vorname="Anna", Nachname="Nass"}
        };

        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = this;
        }

        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            Btn_KlickMich.Text = "Wurde geklickt";

            (sender as Button).BackgroundColor = Color.White;
        }

        private void Ibt_Beispiel_Clicked(object sender, EventArgs e)
        {
            Lbl_Output.Text = "ImageButton geklickt";
        }

        private void Btn_Name_Clicked(object sender, EventArgs e)
        {
            (Stl_DataBinding.BindingContext as Person).Vorname = "Martin";
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Löschung", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                Person p = (sender as MenuItem).CommandParameter as Person;

                Personenliste.Remove(p);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.AbsolutLayoutBsp());
        }
    }
}
