using Lands.Prism.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lands.Prism.ViewModels
{
    public class DetailLandViewModel : ViewModelBase
    {
        private Land _country;

        public DetailLandViewModel(
            INavigationService navigationService) : base(navigationService)
        {
        }

        public Land Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("land"))
            {
                Country = parameters.GetValue<Land>("land");
                Title = "Details";
            }
        }
    }
}
