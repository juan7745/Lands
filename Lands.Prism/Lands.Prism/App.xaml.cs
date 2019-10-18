using Prism;
using Prism.Ioc;
using Lands.Prism.ViewModels;
using Lands.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lands.Prism.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Lands.Prism
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LandsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LandsPage, LandsPageViewModel>();
        }
    }
}
