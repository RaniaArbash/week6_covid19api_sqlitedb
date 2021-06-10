using CovidDetail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetworkingDBProject
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<CountryData> countryData;
        public NetworkingManager networkingManager = new NetworkingManager();
        public MainPage()
        {

            InitializeComponent();

        }
        
        protected async override void OnAppearing()
        {
            /* detailList.ItemsSource = null;
             var list = await networkingManager.GetAllCountries();
             countryData = new ObservableCollection<CountryData>(list);
             detailList.ItemsSource = countryData;*/

            var overview_ = await networkingManager.GetOverview();

            NewConfirmed.Text = overview_.NewConfirmed.ToString();
            TotalConfirmed.Text = overview_.TotalConfirmed.ToString();
            NewDeaths.Text = overview_.NewDeaths.ToString();
            TotalDeaths.Text = overview_.TotalDeaths.ToString();
            NewRecovered.Text = overview_.NewRecovered.ToString();
            TotalRecovered.Text = overview_.TotalRecovered.ToString();
            Date.Text = overview_.Date.ToString();

            base.OnAppearing();

        }

        async private void more_Info(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Options());

        }
    }
}
