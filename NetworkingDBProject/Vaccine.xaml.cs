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

	

	public partial class Vaccine : ContentPage
    {
        DBManager dbModel = new DBManager();
        VaccinesData updatedVaccine;
        ObservableCollection<VaccinesData> allVaccines;
        public Vaccine()
        {
            InitializeComponent();	

		}

        protected async override void OnAppearing()
        {

            allVaccines = await dbModel.CreateTable();
            veccinesListView.ItemsSource = allVaccines;
            base.OnAppearing();

        }

        public async void addNewVaccine(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddVaccine(allVaccines));

        }
       
        public void deleteFromDB(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Name.Text))
            {
                DisplayAlert("Error", "Plese select the vaccine!", "OK");
            }
            else
            {
                updatedVaccine = veccinesListView.SelectedItem as VaccinesData;
                allVaccines.Remove(updatedVaccine);
                dbModel.deleteTask(updatedVaccine);
                Name.Text = "";
                Demand.IsToggled = false;
                InStock.IsToggled = false;
                DisplayAlert("Sucess", " Sucessfully Deleted!", "OK");
            }
        }


        public  void updateDB(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text))
            {
                DisplayAlert("Error", "Plese select the vaccine!", "OK");
            }
            else
            {
                updatedVaccine = veccinesListView.SelectedItem as VaccinesData;
                updatedVaccine.Name= Name.Text;
                updatedVaccine.Demand = Demand.IsToggled;
                updatedVaccine.InStock = InStock.IsToggled;
                if (InStock.IsToggled)
                    updatedVaccine.statusInStock = "In Stock";
                else
                    updatedVaccine.statusInStock = "Out of Stock";

                if (Demand.IsToggled)
                    updatedVaccine.statusDemand = "In Demand";
                else
                    updatedVaccine.statusInStock = "Not In Demand";
                (veccinesListView.SelectedItem as VaccinesData).Name = Name.Text;
                (veccinesListView.SelectedItem as VaccinesData).Demand = Demand.IsToggled;
                (veccinesListView.SelectedItem as VaccinesData).InStock = InStock.IsToggled;
                dbModel.updateTask(updatedVaccine);
                Name.Text = "";
                Demand.IsToggled = false;
                InStock.IsToggled = false;

                DisplayAlert("Sucess", " Sucessfully updated!", "OK");
            }
        }

        private void Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            VaccinesData v = e.SelectedItem as VaccinesData;
            Name.Text = v.Name.ToString();
            Demand.IsToggled = v.Demand;
            InStock.IsToggled = v.InStock;
          

        }
    }
}