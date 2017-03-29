using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.Controls
{
    public class CoverFlowEventArgs : EventArgs
    {
        public int Index { get; set; }
        public object Item { get; set; }
    }
}
