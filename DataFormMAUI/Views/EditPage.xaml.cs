namespace DataFormMAUI
{
    public partial class EditPage : ContentPage
    {
        public EditPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.contactForm.DataObject as ContactFormModel).PropertyChanged += ContactFormBehavior_PropertyChanged;
        }

        private void ContactFormBehavior_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            App.Database.UpdateContactAsync(this.contactForm.DataObject as ContactFormModel);
        }
    }
}