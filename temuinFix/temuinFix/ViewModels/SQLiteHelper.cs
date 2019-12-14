using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using temuinFix.Models;

namespace temuinFix.ViewModels
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<DataModel>().Wait();
        }

        //Insert and Update new record
        public Task<int> SaveItemAsync(DataModel person)
        {
            if (person.Id != 0)
            {
                return db.UpdateAsync(person);
            }
            else
            {
                return db.InsertAsync(person);
            }
        }

        //Delete
        public Task<int> DeleteItemAsync(DataModel person)
        {
            return db.DeleteAsync(person);
        }

        //Read All Items
        public Task<List<DataModel>> GetItemsAsync()
        {
            return db.Table<DataModel>().ToListAsync();
        }


        //Read Item
        public Task<DataModel> GetItemAsync(int id)
        {
            return db.Table<DataModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}
