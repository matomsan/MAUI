using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace TabbedPageSample.Views;

public class MultiLayerPage : ContentPage, IContentView {

    IView IContentView.PresentedContent { get => Children[0]; }

    public MultiLayerPage()
    {
        Children = new ObservableCollection<Page>();
        Children.CollectionChanged += Children_CollectionChanged;
    }

    private void Children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add) {
            foreach (var item in e.NewItems) {
                var page = item as Page;
                page.Parent = this;
            }
        }
        else if (e.Action == NotifyCollectionChangedAction.Remove) {
            foreach (var item in e.OldItems) {
                var page = item as Page;
                page.Parent = null;
            }
        }
        else if (e.Action == NotifyCollectionChangedAction.Reset) {
            foreach (var item in e.OldItems) {
                var page = item as Page;
                page.Parent = null;
            }
        }
    }

    public ObservableCollection<Page> Children { get; }
}