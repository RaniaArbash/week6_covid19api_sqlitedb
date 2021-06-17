using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetworkingDBProject
{
   
    public class DBManager
    {
        private SQLiteAsyncConnection _connection;
        public DBManager()
        {
            _connection = DependencyService.Get<ISOLiteDb>().GetConnection();
        }
        public async Task<ObservableCollection<VaccinesData>> CreateTable()
        {
            await _connection.CreateTableAsync<VaccinesData>();
            var veccines = await _connection.Table<VaccinesData>().ToListAsync();
            var _vaccines = new ObservableCollection<VaccinesData>(veccines);
            return _vaccines;
        }

        public void insertNewToDo(VaccinesData vaccine)
        {
            _connection.InsertAsync(vaccine);
        }

        public void deleteTask(VaccinesData vaccine)
        {
            _connection.DeleteAsync(vaccine);
        }

        public void updateTask(VaccinesData vaccine)
        {
            _connection.UpdateAsync(vaccine);

        }

    }
}
