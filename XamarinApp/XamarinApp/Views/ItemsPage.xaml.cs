using System;

using XamarinApp.Models;
using XamarinApp.ViewModels;

using Xamarin.Forms;
using Microsoft.Azure.Mobile.Analytics;

namespace XamarinApp.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            bool isEnabled = Analytics.IsEnabledAsync().Result;
            if (!isEnabled)
            {
                Analytics.SetEnabledAsync(true);
            }
            Analytics.TrackEvent("Items Page OnAppearing");



            //throw new Exception("Boom goes the dynamite");

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
