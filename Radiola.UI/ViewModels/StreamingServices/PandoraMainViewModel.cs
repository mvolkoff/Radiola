using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Radiola.Services.Pandora;
using Radiola.Services.Pandora.Messages;
using Radiola.UI.Services.Navigation;
using Radiola.UI.Styling.Icons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.ViewModels.StreamingServices
{
    public class PandoraMainViewModel : ViewModelBase
    {
        private INavigationServiceEx _navigationService;
        private IPandoraService _pandoraService;
        private IDialogService _dialogService;

        private string _header = "Pandora® Radio";
        public string Header
        {
            get { return _header; }
            set { Set(ref _header, value); }
        }

        private string _glyph = Icon.GetIcon("HomeIcon");
        public string Glyph
        {
            get { return _glyph; }
            set { Set(ref _glyph, value); }
        }

        private string _connectionIcon = Icon.GetIcon("DisconnectedIcon");
        public string ConnectionIcon
        {
            get { return _connectionIcon; }
            set { Set(ref _connectionIcon, value); }
        }

        private int _userStationsCount;
        public int UserStationsCount
        {
            get { return _userStationsCount; }
            set { Set(ref _userStationsCount, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { Set(ref _isBusy, value); }
        }

        private string _busyMessage;
        public string BusyMessage
        {
            get { return _busyMessage; }
            set { Set(ref _busyMessage, value); }
        }

        private ObservableCollection<UserStationItem> _userStations;
        public ObservableCollection<UserStationItem> UserStations
        {
            get { return _userStations; }
            set { Set(ref _userStations, value); }
        }

        private ObservableCollection<GenreItem> _genres;
        public ObservableCollection<GenreItem> Genres
        {
            get { return _genres; }
            set { Set(ref _genres, value); }
        }

        public RelayCommand<string> SearchCommand { get; private set; }

        public PandoraMainViewModel(INavigationServiceEx navigationService, IPandoraService pandoraService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _pandoraService = pandoraService;
            _dialogService = dialogService;

            SearchCommand = new RelayCommand<string>((searchText) => Search(searchText));

            Messenger.Default.Register<AwaitableOperationMessage>(this, (args) =>
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() => { IsBusy = args.IsRunning; BusyMessage = args.Message; });
            });

            Messenger.Default.Register<FaultMessage>(this, (args) =>
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    if (args.FaultDetails != null)
                        _dialogService.ShowError(args.FaultDetails, "Connection error", "OK", () => { _navigationService.NavigateTo(PageKeys.HOME); });
                    else
                        _dialogService.ShowError(args.DisplayedMessage, "Connection error", "OK", () => { _navigationService.NavigateTo(PageKeys.HOME); });
                });
            });

            Connect();

        }

        #region Helpers
        private async void Connect()
        {
            if (_pandoraService != null)
            {
                ConnectionIcon = await _pandoraService.ConnectAsync(FakeServices.UserName, FakeServices.Password) ? Icon.GetIcon("ConnectedIcon") : Icon.GetIcon("DisconnectedIcon");

                if (_pandoraService.UserStations != null)
                {
                    UserStations = new ObservableCollection<UserStationItem>(from station
                                                                             in _pandoraService.UserStations
                                                                             select new UserStationItem
                                                                             {
                                                                                 StationToken = station.StationToken,
                                                                                 Name = station.StationName,
                                                                                 ArtUrl = station.ArtUrl,
                                                                                 NavigationService = _navigationService
                                                                             });
                    UserStationsCount = UserStations.Count - 1;
                }

                if (_pandoraService.GenreCategories != null)
                {
                    Genres = new ObservableCollection<GenreItem>(from genre
                                                                 in _pandoraService.GenreCategories
                                                                 select new GenreItem
                                                                 {
                                                                     Name = genre.GenreName,
                                                                     Stations = new ObservableCollection<GenreStationItem>(from station
                                                                                                                           in genre.Stations
                                                                                                                           select new GenreStationItem
                                                                                                                           {
                                                                                                                               ID = station.StationID,
                                                                                                                               Name = station.StationName
                                                                                                                           })
                                                                 });
                }
            }
        }

        private void Search(string searchText)
        {
            var result = _pandoraService.SearchAsync(searchText);
        }
        #endregion
    }
}
