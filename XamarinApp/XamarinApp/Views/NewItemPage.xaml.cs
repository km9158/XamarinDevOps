using System;

using XamarinApp.Models;

using Xamarin.Forms;
using Microsoft.Azure.Mobile.Analytics;

namespace XamarinApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is a nice description"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            Analytics.TrackEvent("Item Added");
            await Navigation.PopToRootAsync();
        }
    }
}