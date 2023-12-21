using SQLite;

namespace DataFormMAUI
{
    public class SQLiteDatabase
    {
        readonly SQLiteConnection _database;

        public SQLiteDatabase()
        {
            _database = new SQLiteConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            _database.CreateTable<ContactFormModel>();
        }

        public  List<ContactFormModel> GetContactsAsync()
        {
            return  _database.Table<ContactFormModel>().ToList();
        }

        public  ContactFormModel GetContactAsync(ContactFormModel item)
        {
            return  _database.Table<ContactFormModel>().Where(i => i.ID == item.ID).FirstOrDefault();
        }
        
        public int AddContactAsync(ContactFormModel item)
        {
            return   _database.Insert(item);
        }

        public int DeleteContactAsync(ContactFormModel item)
        {            
            return _database.Delete(item);
        }

        public int UpdateContactAsync(ContactFormModel item)
        {
            if (item.ID != 0)
                return _database.Update(item);
            else
                return _database.Insert(item);
        }
    }
}
