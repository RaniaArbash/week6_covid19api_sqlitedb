using SQLite;
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
    public partial class SearchHistory : ContentPage
    {
        APIStorageManager db = new APIStorageManager();
        History deleteHistory;
        ObservableCollection<History> allSearch;
        public SearchHistory()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

           allSearch = await db.CreateTable();
           allSearchListView.ItemsSource = allSearch;
           base.OnAppearing();
           
        }

        private  void detailList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            History selectedCountry = allSearchListView.SelectedItem as History;
           Navigation.PushAsync(new Countries(selectedCountry.Country));
        }

        private void DeleteHistory(object sender, EventArgs e)
        {
            
            
            db.deleteCountryData(deleteHistory);
          

            DisplayAlert("Sucess", "All History Deleted !", "OK");
        }
    }
}