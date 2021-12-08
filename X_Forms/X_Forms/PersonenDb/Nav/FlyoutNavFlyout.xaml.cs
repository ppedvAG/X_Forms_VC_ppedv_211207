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

namespace X_Forms.PersonenDb.Nav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutNavFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutNavFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutNavFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class FlyoutNavFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutNavFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutNavFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutNavFlyoutMenuItem>(new[]
                {
                     new FlyoutNavFlyoutMenuItem { Id = 0, Title = "Add new person", TargetType=typeof(Pages.Pg_Add) },
                     new FlyoutNavFlyoutMenuItem { Id = 1, Title = "List" , TargetType=typeof(Pages.Pg_List)}
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