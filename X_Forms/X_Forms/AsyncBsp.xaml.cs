using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AsyncBsp : ContentPage
    {
        public AsyncBsp()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Lbl_Output.Text = await Machwas();
        }

        private async Task<string> Machwas()
        {
            try
            {
                await Task.Delay(5000);

                throw new Exception();
            }
            catch
            {
                return "FAILED";
            }

            return "FINISHED";
        }
    }
}