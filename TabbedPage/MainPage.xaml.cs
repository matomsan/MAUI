namespace TabbedPageSample;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnClicked(object sender, EventArgs e)
	{
		var page = Application.Current.MainPage;
		if (page is Views.MultiLayerPage multiLayerPage) {
			var tabMultiPage = multiLayerPage.Children.FirstOrDefault() as Views.TabMultiPage;
			tabMultiPage?.SwitchTabMultiPageAsync();
        }
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}

