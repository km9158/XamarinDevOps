
using Microsoft.Azure.Mobile.Analytics;
using Xamarin.Forms;

namespace XamarinApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Analytics.TrackEvent("About Us");
            InitializeComponent();
        }
    }
}
