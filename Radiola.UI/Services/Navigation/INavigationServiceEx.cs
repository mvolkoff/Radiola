using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Radiola.UI.Services.Navigation
{
    public interface INavigationServiceEx : INavigationService
    {
        event EventHandler Navigated;
        Frame Root { get; set; }
    }
}
