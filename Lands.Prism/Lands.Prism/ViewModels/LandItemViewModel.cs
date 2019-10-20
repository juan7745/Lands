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

        public LandItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand SelectLandComand => _selectLandComand ?? (_selectLandComand = new DelegateCommand(SelectCountry));

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
