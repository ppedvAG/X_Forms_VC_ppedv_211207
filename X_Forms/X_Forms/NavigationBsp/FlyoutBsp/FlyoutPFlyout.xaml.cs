using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.NavigationBsp.FlyoutBsp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutPFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class FlyoutPFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutPFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPFlyoutMenuItem>(new[]
                {
                    new FlyoutPFlyoutMenuItem { Id = 0, Title = "MainPage", TargetType=typeof(MainPage) },
                    new FlyoutPFlyoutMenuItem { Id = 1, Title = "GridLayout", TargetType=typeof(Layouts.GridLayoutBsp) },
                    new FlyoutPFlyoutMenuItem { Id = 2, Title = "TabbedPage", TargetType=typeof(NavigationBsp.TabbedPageBsp) },
                    new FlyoutPFlyoutMenuItem { Id = 3, Title = "PersonenDb", TargetType=typeof(PersonenDb.Nav.FlyoutNav) },
                    new FlyoutPFlyoutMenuItem { Id = 4, Title = "MVVM_Bsp", TargetType=typeof(MVVMBsp.View.MainView) },
                    new FlyoutPFlyoutMenuItem { Id = 5, Title = "GoogleBooks", TargetType=typeof(Uebungen.GoogleBooks.View.MainView) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}