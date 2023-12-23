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

        public List<ContactFormModel> GetContacts()
        {
            List<ContactFormModel> contacts = _database.Table<ContactFormModel>().ToList();
            return contacts.OrderBy(x => x.Name[0]).ToList();
        }

        public ContactFormModel GetContact(ContactFormModel item)
        {
            return _database.Table<ContactFormModel>().Where(i => i.ID == item.ID).FirstOrDefault();
        }

        public int AddContact(ContactFormModel item)
        {
            return _database.Insert(item);
        }

        public int DeleteContact(ContactFormModel item)
        {
            return _database.Delete(item);
        }

        public int UpdateContact(ContactFormModel item)
        {
            if (item.ID != 0)
                return _database.Update(item);
            else
                return _database.Insert(item);
        }
    }
}
