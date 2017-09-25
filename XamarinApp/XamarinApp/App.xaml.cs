using XamarinApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Xamarin.Forms.Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About1",
                        Icon = Xamarin.Forms.Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }

        protected override void OnStart()
        {
            MobileCenter.Start("3d714e48-190e-418f-91fb-57de609ac477",
                   typeof(Analytics), typeof(Crashes));
        }
    }
}
