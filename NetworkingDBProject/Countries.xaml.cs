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
    public partial class Countries : ContentPage
    {
        private string Country { get; set; }
        public ObservableCollection<CountryData> countryData;
        public NetworkingManager networkingManager = new NetworkingManager();
        public Countries(string CountryName)
        {
            InitializeComponent();

            this.Country = CountryName;
        }

        protected async override void OnAppearing()
        {
            detailList.ItemsSource = null;
            var list = await networkingManager.GetByCountry(this.Country);
            countryData = new ObservableCollection<CountryData>(list);
            detailList.ItemsSource = countryData;
            base.OnAppearing();

        }
    }
}