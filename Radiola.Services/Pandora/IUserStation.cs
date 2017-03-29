using System;
using System.Collections;
using System.Collections.Generic;

namespace Radiola.Services.Pandora
{
    public interface IUserStation
    {
        bool AllowAddMusic { get; }
        bool AllowDelete { get; }
        bool AllowEditDescription { get; }
        bool AllowRename { get; }
        string ArtUrl { get; }

        DateTime DateCreated { get; }

        IStationFeedback Feedback { get; }

        IEnumerable<string> Genre { get; }

        bool IsGenreStation { get; }
        bool IsQuickMix { get; }
        bool IsShared { get; }

        IStationMusic Music { get; }

        bool RequiresCleanAds { get; }

        string StationDetailUrl { get; }
        string StationId { get; }
        string StationName { get; }
        string StationSharingUrl { get; }
        string StationToken { get; }

        bool SuppressVideoAds { get; }
    }
}