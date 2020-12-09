#nullable disable
#pragma warning disable CS1591
#pragma warning disable SA1300 // ElementMustBeginWithUpperCaseLetter

using System;

namespace MediaBrowser.Model.Entities
{
    public class PackageReviewInfo
    {
        /// <summary>
        /// Gets or sets the package id (database key) for this review.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the rating value.
        /// </summary>
        public int rating { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not this review recommends this item.
        /// </summary>
        public bool recommend { get; set; }

        /// <summary>
        /// Gets or sets a short description of the review.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Gets or sets the full review.
        /// </summary>
        public string review { get; set; }

        /// <summary>
        /// Gets or sets the time of review.
        /// </summary>
        public DateTime timestamp { get; set; }
    }
}
