using Lands.Prism.Models;
using Lands.Prism.Services;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lands.Prism.ViewModels
{
    public class LandsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private string _filter;
        private ObservableCollection<LandItemViewModel> _lands;
        private List<Land> _landList;

        public LandsPageViewModel(
            INavigationService navigationService,
            ApiService apiService) : base(navigationService)

        {

            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Lands";
            IsRunning = true;
            LoadLands();
        }

        public ObservableCollection<LandItemViewModel> Lands
        {
            get => _lands;
            set => SetProperty(ref _lands, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public string Filter
        {
            get => _filter;
            set
            {
                SetProperty(ref _filter, value);
                Search();
            }
        }

        private async void LoadLands()
        {

            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnection(url);

            if (!connection)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Check the internet connection.",
                    "Accept");
                return;
            }

            var response = await _apiService.GetListAsync<Land>(
                url,
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            _landList = (List<Land>)response.Result;
            Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel());
            IsRunning = false;
        }
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return _landList.Select(l => new LandItemViewModel(_navigationService)
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }
        private void Search()
        {
            if (string.IsNullOrEmpty(Filter))
            {
                Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel());

            }
            else
            {
                Lands = new ObservableCollection<LandItemViewModel>(
                    ToLandItemViewModel().Where(l => l.Name.ToLower().Contains(_filter.ToLower()) ||
                                         l.Capital.ToLower().Contains(_filter.ToLower())));
            }
        }
    }
}
