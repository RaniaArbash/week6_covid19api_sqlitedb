//using CovidDetail.Persistence;
//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Text;
//using System.Threading.Tasks;
//using Xamarin.Forms;


//namespace CovidDetail.Models
//{
//    class APIStorageManager
//    {


//            private SQLiteAsyncConnection _connection;
//            public APIStorageManager()
//            {
//                _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
//           // _connection.DropTableAsync<History>();
               
//        }
//            public async Task<ObservableCollection<History>> CreateTable()
//            {
           
//            await _connection.CreateTableAsync<History>();
//                var api = await _connection.Table<History>().ToListAsync();
//                var _api = new ObservableCollection<History>(api);
//                return _api;
//            }

//            public void insertCountryData(History api)
//            {
//                _connection.InsertAsync(api);
               
//            }

//            public void deleteCountryData(History api)
//            {
//             _connection.DropTableAsync<History>();
//            }

//            public void updateCountryData(History api)
//            {
//                _connection.UpdateAsync(api);

//            }

//        }
//    }
