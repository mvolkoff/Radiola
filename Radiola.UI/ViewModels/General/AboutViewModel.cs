using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.ViewModels.General
{
    public class AboutViewModel : ViewModelBase
    {
        private string _header;
        public string Header
        {
            get { return _header; }
            set { Set(ref _header, value); }
        }

        private string _glyph;
        public string Glyph
        {
            get { return _glyph; }
            set { Set(ref _glyph, value); }
        }
    }
}
