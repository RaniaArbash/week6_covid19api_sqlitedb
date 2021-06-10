using CovidDetail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetworkingDBProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class World : ContentPage
    {
       // APIStorageManager dbAPIModel = new APIStorageManager();
        public ObservableCollection<History> history;
        public ObservableCollection<WorldData> worldData;
        public NetworkingManager networkingManager = new NetworkingManager();
        WorldData selectedCountry;
        public World()
        {
            history = new ObservableCollection<History>() { };
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            detailList.ItemsSource = null;
            var list = await networkingManager.GetAllCountries();
            worldData = new ObservableCollection<WorldData>(list);
            detailList.ItemsSource = worldData;
            base.OnAppearing();

        }

        private async void detailList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedCountry = detailList.SelectedItem as WorldData;

            History tempHistory = new History();
            tempHistory.Country = selectedCountry.Country;
            tempHistory.TotalDeaths = selectedCountry.TotalDeaths;
            tempHistory.NewConfirmed = selectedCountry.NewConfirmed;
            tempHistory.TotalRecovered = selectedCountry.TotalRecovered;
            tempHistory.TotalConfirmed = selectedCountry.TotalConfirmed;
            tempHistory.CountryCode = selectedCountry.CountryCode;
            history.Add(tempHistory);

          //  dbAPIModel.insertCountryData(tempHistory);

            await Navigation.PushAsync(new Countries(selectedCountry.Country));
        }

        private async void History_page(object sender, EventArgs e)
        {
          //  await Navigation.PushAsync(new SearchHistory());
        }
    }
}