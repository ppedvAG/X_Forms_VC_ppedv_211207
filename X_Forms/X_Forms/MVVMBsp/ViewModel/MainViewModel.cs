using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.MVVMBsp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Page ContextPage { get; set; }

        public string NeuerVorname { get; set; }
        public string NeuerNachname { get; set; }

        public Command HinzufuegenCmd { get; set; }

        public ObservableCollection<Model.Person> Personenliste 
        {
            get { return Model.Person.Personenliste; } 
            set { Model.Person.Personenliste = value; }
        }

        public MainViewModel()
        {
            HinzufuegenCmd = new Command(AddPerson, CanAddPerson);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void AddPerson(object p)
        {
            Model.Person person = new Model.Person()
            {
                Vorname = NeuerVorname,
                Nachname = NeuerNachname
            };

            Personenliste.Add(person);

            NeuerVorname = string.Empty;
            NeuerNachname = string.Empty;

            UpdateGUI(nameof(NeuerVorname));
            UpdateGUI(nameof(NeuerNachname));

            ContextPage.DisplayAlert("Person erfolgreich erstellt", "Person", "Ok");

        }

        bool CanAddPerson(object p)
        {
            return (bool)p;
        }

        void UpdateGUI(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
