using System.Collections.ObjectModel;

namespace DataFormMAUI
{
    public class ContactsViewModel
    {
        public ContactFormModel SelectedItem { get; set; }
        public ObservableCollection<ContactFormModel> ContactsInfo { get; set; }
        public Command CreateContactsCommand { get; set; }
        public Command<object> EditContactsCommand { get; set; }
        public Command DeleteItemCommand { get; set; }
        public Command AddItemCommand { get; set; }
        public Command CancelEditCommand { get; set; }

        public ContactsViewModel()
        {
            GenerateContacts();
            CreateContactsCommand = new Command(OnCreateContacts);
            EditContactsCommand = new Command<object>(OnEditContacts);
            DeleteItemCommand = new Command(OnDeleteItem);
            AddItemCommand = new Command(OnAddNewItem);
            CancelEditCommand = new Command(OnCancelEdit);
        }

        private void GenerateContacts()
        {
            ContactsInfo = new ContactsInfoRepository().GetContactDetails(20);
            PopulateDB();
        }

        private void PopulateDB()
        {
            foreach (ContactFormModel contact in ContactsInfo)
            {
                var item = App.Database.GetContact(contact);
                if (item == null)
                    App.Database.AddContact(contact);
            }
        }

        private async void OnCancelEdit()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnAddNewItem()
        {
            App.Database.AddContact(SelectedItem);
            ContactsInfo.Add(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnDeleteItem()
        {
            App.Database.DeleteContact(SelectedItem);
            ContactsInfo.Remove(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }
        private void OnEditContacts(object obj)
        {
            SelectedItem = (obj as Syncfusion.Maui.ListView.ItemTappedEventArgs).DataItem as ContactFormModel;
            var editPage = new EditPage() { BindingContext = this};
            App.Current.MainPage.Navigation.PushAsync(editPage);
        }

        private void OnCreateContacts()
        {
            SelectedItem = new ContactFormModel() { Name = "", Mobile = "", ProfileImage = "newcontact.png" };
            var editPage = new EditPage() { BindingContext = this };
            App.Current.MainPage.Navigation.PushAsync(editPage);
        }
    }
}
