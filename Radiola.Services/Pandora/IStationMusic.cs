﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora
{
    public interface IStationMusic
    {
        IEnumerable<IArtistInfo> Artists { get; }
        
        //  "songs": [],
        //  "genres": []
    }
}
