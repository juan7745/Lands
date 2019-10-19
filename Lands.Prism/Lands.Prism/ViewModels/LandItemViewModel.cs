using Lands.Prism.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Prism.ViewModels
{
    public class LandItemViewModel : Response
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectCountryCommand;

        public LandItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand SelectCountryCommand => _selectCountryCommand ?? (_selectCountryCommand = new DelegateCommand(SelectCountry));

        private async void SelectCountry()
        {
            var parameters = new NavigationParameters
            {
                { "country", this}
            };
            await _navigationService.NavigateAsync("CountryPage", parameters);
        }
    }
}
