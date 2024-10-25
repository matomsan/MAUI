namespace TabbedPageSample.Views;

public class TabMultiPage : TabbedPage {
    public TabMultiPage()
    {
        var page = new MainPage() { Title = "One" };
        Children.Add(page);
        CurrentPage = Children[0];
    }

    public async Task SwitchTabMultiPageAsync()
    {
        var page = new NewPage1() { Title = "Two" };
        Children.Add(page);
        CurrentPage = Children[1];
    }
}