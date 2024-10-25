using Android.Views;
using Android.Widget;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace TabbedPageSample.Handlers;

public partial class MultiLayerPageHandler : ViewHandler<Views.MultiLayerPage, FrameLayout> {

    const int MP = ViewGroup.LayoutParams.MatchParent;

    public static PropertyMapper<Views.MultiLayerPage, MultiLayerPageHandler> PropertyMapper = new PropertyMapper<Views.MultiLayerPage, MultiLayerPageHandler>(ViewHandler.ViewMapper) {
    };

    public MultiLayerPageHandler() : base(PropertyMapper)
    {
    }

    protected override FrameLayout CreatePlatformView()
    {
        return new FrameLayout(Context);
    }

    protected override void ConnectHandler(FrameLayout platformView)
    {
        base.ConnectHandler(platformView);

        foreach (var child in VirtualView.Children) {
            var childView = child.ToPlatform(MauiContext);
            if (childView != null) {
                platformView.AddView(childView, new ViewGroup.LayoutParams(MP, MP));
            }
        }
    }
}