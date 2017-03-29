using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Radiola.UI.Services.Navigation
{
    public class NavigationService : INavigationServiceEx
    {
        #region Events
        public event EventHandler Navigated;
        #endregion

        #region Fields
        private readonly IDictionary<string, Type> _pages = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        #endregion

        #region Properties
        public string CurrentPageKey { get; private set; }

        private Frame _root;
        public Frame Root
        {
            get { return _root; }
            set { _root = value; }
        }
        #endregion

        #region Ctor
        public NavigationService()
        {
            SystemNavigationManager.GetForCurrentView().BackRequested += (o, e) => GoBack();
        }
        #endregion

        #region Public methods
        public void Configure(string key, Type type)
        {
            _pages.Add(key, type);
        }

        public void GoBack()
        {
            if (Root.CanGoBack)
            {
                Root.GoBack();
                var kvp = _pages.FirstOrDefault(pair => pair.Value == Root.CurrentSourcePageType);
                if (kvp.Key != null)
                {
                    CurrentPageKey = kvp.Key;
                }
                OnNavigated();
            }
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            if (Root.Navigate(_pages[pageKey], parameter))
            {
                CurrentPageKey = pageKey;
                OnNavigated();
            }
        }
        #endregion

        #region Private methods
        private void OnNavigated()
        {
            Navigated?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
