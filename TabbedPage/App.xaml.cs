namespace TabbedPageSample;

public partial class App : Application {
    public App()
    {
        InitializeComponent();

        var tabMultiPage = new Views.TabMultiPage();

        var floatingView = new Views.FloatingPage();

        Views.MultiLayerPage multiLayerPage = new Views.MultiLayerPage() {
            Children = {
                            tabMultiPage,
                            floatingView,
                        },
        };

        MainPage = multiLayerPage;
    }
}
