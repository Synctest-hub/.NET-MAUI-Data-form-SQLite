namespace DataFormMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        this.Loaded += MainPage_Loaded;
	}

    private void MainPage_Loaded(object sender, EventArgs e)
    {
       listView.ItemsSource =  App.Database.GetContactsAsync();
    }
}

    