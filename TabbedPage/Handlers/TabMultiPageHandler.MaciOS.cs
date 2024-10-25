using Microsoft.Maui.Controls.Handlers.Compatibility;
using UIKit;

namespace TabbedPageSample.Handlers;

public partial class TabMultiPageHandler : TabbedRenderer {

    public override void ViewDidLayoutSubviews()
    {
        base.ViewDidLayoutSubviews();

        var window = UIApplication.SharedApplication.Delegate.GetWindow();
        if (window != null) {
            View.Frame = window.Bounds;
        }
    }
}