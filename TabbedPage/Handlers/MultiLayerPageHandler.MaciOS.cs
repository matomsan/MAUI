using Microsoft.Maui.Handlers;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Platform;

namespace TabbedPageSample.Handlers;

public partial class MultiLayerPageHandler : PageHandler
{
    internal class MultiLayerPageViewController : PageViewController {

        IViewHandler _handler;

        public MultiLayerPageViewController(IView page, IMauiContext mauiContext, IViewHandler handler) : base(page, mauiContext)
        {
            _handler = handler;
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            Rect bounds = View.Bounds.ToRectangle();

            foreach (var child in (_handler.VirtualView as Views.MultiLayerPage).Children) {
                child.Layout(bounds);
                child.ComputeDesiredSize(bounds.Size.Width, bounds.Size.Height);
            }
        }
    }

    Views.MultiLayerPage MultiLayerPage => VirtualView as Views.MultiLayerPage;

    protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
    {
        if (ViewController == null)
            ViewController = new MultiLayerPageViewController(VirtualView, MauiContext, this);

        if (ViewController is PageViewController pc && pc.CurrentPlatformView is Microsoft.Maui.Platform.ContentView pv)
            return pv;

        if (ViewController.View is Microsoft.Maui.Platform.ContentView cv)
            return cv;

        throw new InvalidOperationException($"PageViewController.View must be a {nameof(Microsoft.Maui.Platform.ContentView)}");
    }

    protected override void ConnectHandler(Microsoft.Maui.Platform.ContentView nativeView)
    {
        base.ConnectHandler(nativeView);
        MultiLayerPage.Loaded += OnLoaded;
    }

    protected override void DisconnectHandler(Microsoft.Maui.Platform.ContentView nativeView)
    {
        MultiLayerPage.Loaded -= OnLoaded;
        base.DisconnectHandler(nativeView);
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        if (this is IPlatformViewHandler handler) {
            foreach (var child in MultiLayerPage.Children) {
                var view = child.ToUIViewController(MauiContext).View;
                if (view != null) {
                    handler.PlatformView.AddSubview(view);
                }
            }
        }
    }
}