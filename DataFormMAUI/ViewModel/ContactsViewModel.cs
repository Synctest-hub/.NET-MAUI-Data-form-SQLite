using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataFormMAUI
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<ContactFormModel> contactsInfo;
        private ContactFormModel selectedContact;

        #endregion

        #region Properties
        public ContactFormModel SelectedItem
        {
            get 
            {
                return selectedContact;
            }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public ObservableCollection<ContactFormModel> ContactsInfo
        {
            get
            {
                return contactsInfo;
            }
            set
            {
                contactsInfo = value;
                OnPropertyChanged("ContactsInfo");
            }
        }

        public Command CreateContactsCommand { get; set; }
        public Command<object> EditContactsCommand { get; set; }
        public Command SaveItemCommand { get; set; }
        public Command DeleteItemCommand { get; set; }
        public Command AddItemCommand { get; set; }

        #endregion

        #region Constructor
        public ContactsViewModel()
        {
            GenerateContacts();
            CreateContactsCommand = new Command(OnCreateContacts);
            EditContactsCommand = new Command<object>(OnEditContacts);
            SaveItemCommand = new Command(OnSaveItem);
            DeleteItemCommand = new Command(OnDeleteItem);
            AddItemCommand = new Command(OnAddNewItem);
        }
        #endregion

        #region Methods

        private async void GenerateContacts()
        {
            ContactsInfo = new ObservableCollection<ContactFormModel>();
            ContactsInfo = new ContactsInfoRepository().GetContactDetails(20);
            PopulateDB();
        }

        private async void PopulateDB()
        {
            foreach (ContactFormModel contact in ContactsInfo)
            {
                var item = await App.Database.GetContactAsync(contact);
                if(item == null)
                   await App.Database.AddContactAsync(contact);
            }
        }
        private async void OnAddNewItem()
        {
            await App.Database.AddContactAsync(SelectedItem);
            ContactsInfo.Add(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnDeleteItem()
        {
            await App.Database.DeleteContactAsync(SelectedItem);
            ContactsInfo.Remove(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnSaveItem()
        {
            await App.Database.UpdateContactAsync(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void OnEditContacts(object obj)
        {
            SelectedItem = (obj as Syncfusion.Maui.ListView.ItemTappedEventArgs).DataItem as ContactFormModel;
            var editPage = new EditPage();
            editPage.BindingContext = SelectedItem;
            App.Current.MainPage.Navigation.PushAsync(editPage);
        }

        private void OnCreateContacts()
        {
            SelectedItem = new ContactFormModel() { Name = "", Mobile = "", ProfileImage = "" };
            var editPage = new EditPage();
            editPage.BindingContext = SelectedItem;
            App.Current.MainPage.Navigation.PushAsync(editPage);
        }
        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
