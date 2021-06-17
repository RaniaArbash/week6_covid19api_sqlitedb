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
    
    public partial class AddVaccine : ContentPage
    {
        DBManager dbModel = new DBManager();
        ObservableCollection<VaccinesData> Vaccine;
        VaccinesData newVaccine;
        bool InDemand;
        bool Stock;
        public AddVaccine(ObservableCollection<VaccinesData> _Vaccine)
        {
            InitializeComponent();
            this.Vaccine = _Vaccine;
        }

        private void Demand_Toggled(object sender, ToggledEventArgs e)
        {
            InDemand = e.Value;
            
        }

        private void InStock_Toggled(object sender, ToggledEventArgs e)
        {
            Stock = e.Value;
        }
      async private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text))
            {
                await DisplayAlert("Error", "Please add all the information!", "OK");
            }
            else
            {
                newVaccine = new VaccinesData();
                newVaccine.Name = Name.Text;
                newVaccine.Demand = Demand.IsToggled;
                newVaccine.InStock = InStock.IsToggled;
                Vaccine.Add(newVaccine);
                await DisplayAlert("Success", "New Vaccine is added!", "Ok");
                dbModel.insertNewToDo(newVaccine);
                await Navigation.PopAsync();
            }

        }


    }
}