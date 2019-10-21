using Lands.Prism.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Prism.ViewModels
{
    public class LandItemViewModel : Land
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectLandComand;
        private DelegateCommand _selectMapComand;

        public LandItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand SelectLandComand => _selectLandComand ?? (_selectLandComand = new DelegateCommand(SelectCountry));
        public DelegateCommand SelectMapComand => _selectMapComand ?? (_selectMapComand = new DelegateCommand(SelectMap));

        private async void SelectMap()
        {
            var parameters = new NavigationParameters
            {
                { "map", this}
            };
            await _navigationService.NavigateAsync("MapPage", parameters);
        }

        private async void SelectCountry()
        {
            var parameters = new NavigationParameters
            {
                { "land", this}
            };
            await _navigationService.NavigateAsync("DetailLand", parameters);
        }
    }
}
