using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.ViewModels
{
    public class TrackItem : ObservableObject
    {
        public string AlbumArtUrl { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }

        public bool IsPositive { get; set; }

        public string SongName { get; set; }

        public string TrackToken { get; set; }

        public RelayCommand ThumbUpCommand { get; set; }
        public RelayCommand ThumbDownCommand { get; set; }
    }
}
