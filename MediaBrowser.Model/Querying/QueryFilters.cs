#nullable disable
#pragma warning disable CS1591

using System;
using MediaBrowser.Model.Dto;

namespace MediaBrowser.Model.Querying
{
    public class QueryFilters
    {
        public NameGuidPair[] Genres { get; set; }

        public string[] Tags { get; set; }

        public QueryFilters()
        {
            Tags = Array.Empty<string>();
            Genres = Array.Empty<NameGuidPair>();
        }
    }
}
