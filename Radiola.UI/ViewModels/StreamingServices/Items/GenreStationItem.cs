using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.ViewModels
{
    public class GenreStationItem : ObservableObject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ArtUrl { get; set; }
    }
}
