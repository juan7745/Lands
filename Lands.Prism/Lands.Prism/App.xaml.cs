using Prism;
using Prism.Ioc;
using Lands.Prism.ViewModels;
using Lands.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lands.Prism.Services;
using MyVet.Common.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Lands.Prism
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTU5NDM4QDMxMzcyZTMzMmUzMGVIaDFtK1d1NzdGOGVQSTdUOTNHQ0pwQmJYU0R5Q05ubyt1dVpiYWNpdHM9");
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LandsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IGeolocatorService, GeolocatorService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LandsPage, LandsPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailLand, DetailLandViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
        }
    }
}
