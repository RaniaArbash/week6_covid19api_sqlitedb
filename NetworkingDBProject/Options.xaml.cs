using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetworkingDBProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Options : ContentPage
    {
        public Options()
        {
            InitializeComponent();
        }

        async private void View_By_Country(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new World());
        }

        async private void Search_History(object sender, EventArgs e)
        {
       //     await Navigation.PushAsync(new SearchHistory());
        }
        async private void Vaccine_Info(object sender, EventArgs e)
        {
         //   await Navigation.PushAsync(new Vaccine());
        }


    }
}