using Lands.Prism.Models;
using Lands.Prism.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lands.Prism.ViewModels
{
     public class LandsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<Land> _lands;

        public LandsPageViewModel(
            INavigationService navigationService,
            ApiService apiService) : base(navigationService)

        {
           
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Lands";
            LoadLands();
        }

        public ObservableCollection<Land> Lands
        {
            get => _lands;
            set => SetProperty(ref _lands, value);
        }


        private async void LoadLands()
        {

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetListAsync<Land>(
                url,
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

                var list = (List<Land>)response.Result;
                Lands = new ObservableCollection<Land>(list);
        }
    }
}
