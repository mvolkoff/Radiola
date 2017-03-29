using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Radiola.UI.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.ViewModels
{
    public class UserStationItem : ViewModelBase
    {
        public string StationToken { get; set; }
        public string Name { get; set; }
        public string ArtUrl { get; set; }

        public INavigationServiceEx NavigationService { get; set; }

        public RelayCommand<string> NavigateToStationDetailsCommand => new RelayCommand<string>((id) => { NavigationService?.NavigateTo(PageKeys.PANDORA_STATION_DETAILS, id); });
    }
}
