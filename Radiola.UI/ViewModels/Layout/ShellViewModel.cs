using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Radiola.UI.Services.Navigation;
using Radiola.UI.Styling.Icons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace Radiola.UI.ViewModels.Layout
{
    public class ShellViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItem> _primaryMenu = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> PrimaryMenu
        {
            get { return _primaryMenu; }
            private set { _primaryMenu = value; }
        }

        private ObservableCollection<MenuItem> _secondaryMenu = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> SecondaryMenu
        {
            get { return _secondaryMenu; }
            private set { _secondaryMenu = value; }
        }

        public ShellViewModel(INavigationServiceEx navigationService)
        {
            navigationService.Navigated += (sender, args) =>
            {
                switch (navigationService.CurrentPageKey)
                {
                    case PageKeys.HOME:
                    case PageKeys.SETTINGS:
                    case PageKeys.ABOUT:
                        {
                            navigationService.Root.BackStack.Clear();
                        }
                        break;
                }

                if (navigationService.Root.CanGoBack)
                {
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                }
                else
                {
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                }

                foreach (var item in PrimaryMenu)
                {
                    (item.NavigateCommand as RelayCommand).RaiseCanExecuteChanged();
                }

                foreach (var item in SecondaryMenu)
                {
                    (item.NavigateCommand as RelayCommand).RaiseCanExecuteChanged();
                }
            };

            // Build the menus
            PrimaryMenu.Add(new MenuItem()
            {
                Glyph = Icon.GetIcon("HomeIcon"),
                Text = "Home",
                NavigateCommand = new RelayCommand(() => { navigationService.NavigateTo(PageKeys.HOME); },
                    () => { return !navigationService.CurrentPageKey.Equals(PageKeys.HOME); })
            });
            PrimaryMenu.Add(new MenuItem()
            {
                Glyph = Icon.GetIcon("HomeIcon"),
                Text = "Pandora® Radio",
                NavigateCommand = new RelayCommand(() => { navigationService.NavigateTo(PageKeys.PANDORA_MAIN); },
                    () => { return !navigationService.CurrentPageKey.Equals(PageKeys.PANDORA_MAIN); })
            });


            SecondaryMenu.Add(new MenuItem()
            {
                Glyph = Icon.GetIcon("GearIcon"),
                Text = "Settings",
                NavigateCommand = new RelayCommand(() => { navigationService.NavigateTo(PageKeys.SETTINGS); },
                    () => { return !navigationService.CurrentPageKey.Equals(PageKeys.SETTINGS); })
            });
            SecondaryMenu.Add(new MenuItem()
            {
                Glyph = Icon.GetIcon("InfoIcon"),
                Text = "About",
                NavigateCommand = new RelayCommand(() => { navigationService.NavigateTo(PageKeys.ABOUT); },
                    () => { return !navigationService.CurrentPageKey.Equals(PageKeys.ABOUT); })
            });
        }
    }
}
