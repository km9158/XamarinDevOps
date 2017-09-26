
using XamarinApp.ViewModels;

using Xamarin.Forms;
using Microsoft.Azure.Mobile.Analytics;

namespace XamarinApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            Analytics.TrackEvent("Item Details");
            BindingContext = this.viewModel = viewModel;
        }
    }
}
