using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace TabbedPageSample.Views;

public class FloatingPage : ContentPage
{
	public FloatingPage()
	{
#if IOS || MACCATALYST
        On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SetUseSafeArea(true);
#endif

        this.BackgroundColor = Colors.Transparent;
        this.InputTransparent = true;

        var floatingView = new FloatingView() {
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.End,
        };

        Content = floatingView;
    }
}