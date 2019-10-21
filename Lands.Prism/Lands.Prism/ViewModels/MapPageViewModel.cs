﻿using Lands.Prism.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lands.Prism.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {   
        public MapPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "Map";
        }            
    }
}

