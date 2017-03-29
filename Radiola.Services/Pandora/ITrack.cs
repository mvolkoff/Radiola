using Radiola.Services.Pandora.Common;
using Radiola.Services.Pandora.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace Radiola.Services.Pandora
{
    public interface ITrack
    {
        string AlbumArtUrl { get; }
        string AlbumIdentity { get; }
        string AlbumName { get; }
        bool AllowFeedback { get; }
        string ArtistName { get; }
        IDictionary<QualityNames, IAudio> AudioUrlMap { get;}

        string CategoryDescriptor { get; }

        DateTime DateCreated { get; }

        string FeedbackId { get; }

        bool IsFeatured { get; }
        bool IsPositive { get; }

        string MusicId { get; }
        string MusicToken { get; }

        string PandoraId { get; }
        string PandoraType { get; }
        string ProgramDescriptor { get; }

        string SongIdentity { get; }
        string SongName { get; }
        int SongRating { get; }
        string StationId { get; }

        double TrackGain { get; }
        string TrackToken { get; }
        string TrackType { get; }

        // Что делать с этим пока не решил....
        //"songExplorerUrl": "http://www.pandora.com/xml/music/song/dave-brubeck-quartet/time-out-50th-anniversary-legacy-edition/everybodys-jumpin?explicit=false",
        //"artistDetailUrl": "http://www.pandora.com/dave-brubeck-quartet?dc=1777&ad=1:30:1:12345::0:0:0:0:532:069:NY:36093:2:0:0:0:0:1",
        //"itunesSongUrl": "http://itunes.apple.com/album/everybodys-jumpin/id193085545?i=193085829&uo=5&at=11l3Hh&app=itunes&ct=Generic",
        //"shareLandingUrl": "http://www.pandora.com/dave-brubeck-quartet/time-out-50th-anniversary-legacy-edition/everybodys-jumpin?shareImp=true",
        //"artistExplorerUrl": "http://www.pandora.com/xml/music/artist/dave-brubeck-quartet?explicit=false",
        //"albumDetailUrl": "http://www.pandora.com/dave-brubeck-quartet/time-out-50th-anniversary-legacy-edition?dc=1777&ad=1:30:1:12345::0:0:0:0:532:069:NY:36093:2:0:0:0:0:1",
        //"songDetailUrl": "http://www.pandora.com/dave-brubeck-quartet/time-out-50th-anniversary-legacy-edition/everybodys-jumpin?dc=1777&ad=1:30:1:12345::0:0:0:0:532:069:NY:36093:2:0:0:0:0:1",
        //"albumExplorerUrl": "http://www.pandora.com/xml/music/album/dave-brubeck-quartet/time-out-50th-anniversary-legacy-edition?explicit=false",
    }
}
