using SQLite;

namespace DataFormMAUI
{
    public class SQLiteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public SQLiteDatabase()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _database.CreateTableAsync<ContactFormModel>();
        }

        public async Task<List<ContactFormModel>> GetContactsAsync()
        {
            return await _database.Table<ContactFormModel>().ToListAsync();
        }

        public async Task<ContactFormModel> GetContactAsync(ContactFormModel item)
        {
            return await _database.Table<ContactFormModel>().Where(i => i.ID == item.ID).FirstOrDefaultAsync();
        }
        
        public async Task<int> AddContactAsync(ContactFormModel item)
        {
            return await  _database.InsertAsync(item);
        }

        public Task<int> DeleteContactAsync(ContactFormModel item)
        {            
            return _database.DeleteAsync(item);
        }

        public Task<int> UpdateContactAsync(ContactFormModel item)
        {
            if (item.ID != 0)
                return _database.UpdateAsync(item);
            else
                return _database.InsertAsync(item);
        }
    }
}
