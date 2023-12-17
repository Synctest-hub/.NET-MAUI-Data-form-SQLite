namespace DataFormMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetContactsAsync();
    }
}

    