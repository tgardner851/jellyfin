#nullable disable
#pragma warning disable CS1591

using System;
using MediaBrowser.Model.Dto;

namespace MediaBrowser.Model.Session
{
    public class QueueItem
    {
        public Guid Id { get; set; }

        public string PlaylistItemId { get; set; }
    }
}
