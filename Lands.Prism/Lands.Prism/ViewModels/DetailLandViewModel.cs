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
        public DetailLandViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Country";
        }
    }
}
