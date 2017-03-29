using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.ViewModels.Layout
{
    public class MenuItem : ObservableObject
    {
        private string _glyph;
        public string Glyph
        {
            get { return _glyph; }
            set { Set(ref _glyph, value); }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { Set(ref _text, value); }
        }

        private RelayCommand _navigateCommand;
        public RelayCommand NavigateCommand
        {
            get { return _navigateCommand; }
            set { Set(ref _navigateCommand, value); }
        }
    }
}
