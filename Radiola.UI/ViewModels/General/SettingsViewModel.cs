using GalaSoft.MvvmLight;
using Radiola.UI.Styling.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.ViewModels.General
{
    public class SettingsViewModel : ViewModelBase
    {
        private string _header = "Settings";
        public string Header
        {
            get { return _header; }
            set { Set(ref _header, value); }
        }

        private string _glyph = Icon.GetIcon("GearIcon");
        public string Glyph
        {
            get { return _glyph; }
            set { Set(ref _glyph, value); }
        }

    }
}
