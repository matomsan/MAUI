using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace TabbedPageSample.Handlers;

public partial class MultiLayerPageHandler : ViewHandler<Views.MultiLayerPage, ContentPanel> {

    internal class MyContentPanel : ContentPanel {
        protected override Windows.Foundation.Size ArrangeOverride(Windows.Foundation.Size finalSize)
        {
            foreach (var child in Children) {
                var bound = new Windows.Foundation.Rect(0, 0, finalSize.Width, finalSize.Height);
                child.Arrange(bound);
                if (child is Microsoft.UI.Xaml.Shapes.Path path) {
                    path.Width = finalSize.Width;
                    path.Height = finalSize.Height;
                }
                else if (child is Microsoft.UI.Xaml.Controls.Frame frame) {
                    frame.Width = finalSize.Width;
                    frame.Height = finalSize.Height;
                }
                else if (child is Microsoft.Maui.Platform.ContentPanel contentPanel) {
                    contentPanel.Width = finalSize.Width;
                    contentPanel.Height = finalSize.Height;
                }
            }
            return finalSize;
        }
    }

    public static PropertyMapper<Views.MultiLayerPage, MultiLayerPageHandler> PropertyMapper = new PropertyMapper<Views.MultiLayerPage, MultiLayerPageHandler>(ViewHandler.ViewMapper) {
    };

    public MultiLayerPageHandler() : base(PropertyMapper)
    {
    }

    protected override ContentPanel CreatePlatformView()
    {
        var view = new MyContentPanel() {
            CrossPlatformLayout = VirtualView,
        };
        return view;
    }

    protected override void ConnectHandler(ContentPanel platformView)
    {
        base.ConnectHandler(platformView);
        platformView.Loaded += OnLoaded;

        foreach (var child in VirtualView.Children) {
            var element = child.ToPlatform(MauiContext);
            platformView.Children.Add(element);
        }
    }

    protected override void DisconnectHandler(ContentPanel platformView)
    {
        platformView.Loaded -= OnLoaded;
        base.DisconnectHandler(platformView);
    }

    private void OnLoaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (this is IPlatformViewHandler handler) {
            if (handler.VirtualView is Views.MultiLayerPage multiLayerPage) {
                foreach (var child in multiLayerPage.Children) {
                    child.SendAppearing();
                }
            }
        }
    }
}