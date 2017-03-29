using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Radiola.Services.Pandora;
using Radiola.Services.Pandora.Concrete;
using Radiola.Services.Playback;
using Radiola.Services.Playback.Concrete;
using Radiola.UI.Services.Navigation;
using Radiola.UI.ViewModels.General;
using Radiola.UI.ViewModels.Layout;
using Radiola.UI.ViewModels.StreamingServices;
using Radiola.UI.Views.General;
using Radiola.UI.Views.StreamingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region Setup Services
            SimpleIoc.Default.Register<INavigationServiceEx>(() =>
            {
                var nav = new Services.Navigation.NavigationService();

                nav.Configure(PageKeys.HOME, typeof(HomePage));
                nav.Configure(PageKeys.SETTINGS, typeof(SettingsPage));
                nav.Configure(PageKeys.ABOUT, typeof(AboutPage));

                nav.Configure(PageKeys.PANDORA_MAIN, typeof(PandoraMainPage));
                nav.Configure(PageKeys.PANDORA_STATION_DETAILS, typeof(PandoraStationDetailsPage));
                nav.Configure(PageKeys.PANDORA_PLAYBACK, typeof(PandoraPlaybackPage));

                return nav;
            });
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IPandoraService, PandoraService>();
            SimpleIoc.Default.Register<IPlaybackService, PlaybackService>();
            #endregion

            #region Setup ViewModels
            SimpleIoc.Default.Register<ShellViewModel>();

            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();

            SimpleIoc.Default.Register<PandoraMainViewModel>();
            SimpleIoc.Default.Register<PandoraStationDetailsViewModel>();
            SimpleIoc.Default.Register<PandoraPlaybackViewModel>();
            #endregion
        }

        #region ViewModel Instances
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        public ShellViewModel Shell => ServiceLocator.Current.GetInstance<ShellViewModel>();

        #region General
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        public SettingsViewModel Settings => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();
        #endregion

        #region StreamingServices
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        public PandoraMainViewModel PandoraMain => ServiceLocator.Current.GetInstance<PandoraMainViewModel>();

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        public PandoraStationDetailsViewModel PandoraStationDetails => ServiceLocator.Current.GetInstance<PandoraStationDetailsViewModel>();

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        public PandoraPlaybackViewModel PandoraPlayback => ServiceLocator.Current.GetInstance<PandoraPlaybackViewModel>();
        #endregion
        #endregion
    }
}
