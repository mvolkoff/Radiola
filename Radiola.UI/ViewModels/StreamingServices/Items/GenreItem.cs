using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.ViewModels
{
    public class GenreItem : ObservableObject
    {
        public string Name { get; set; }
        public ObservableCollection<GenreStationItem> Stations { get; set; }
    }
}
