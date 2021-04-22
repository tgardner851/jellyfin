﻿using System;
using Emby.Naming.Common;
using Emby.Naming.Video;
using Xunit;

namespace Jellyfin.Naming.Tests.Video
{
    public sealed class CleanStringTests
    {
        private readonly VideoResolver _videoResolver = new VideoResolver(new NamingOptions());

        [Theory]
        [InlineData("Super movie 480p.mp4", "Super movie")]
        [InlineData("Super movie 480p 2001.mp4", "Super movie")]
        [InlineData("Super movie [480p].mp4", "Super movie")]
        [InlineData("480 Super movie [tmdbid=12345].mp4", "480 Super movie")]
        [InlineData("Crouching.Tiger.Hidden.Dragon.4k.mkv", "Crouching.Tiger.Hidden.Dragon")]
        [InlineData("Crouching.Tiger.Hidden.Dragon.UltraHD.mkv", "Crouching.Tiger.Hidden.Dragon")]
        [InlineData("Crouching.Tiger.Hidden.Dragon.UHD.mkv", "Crouching.Tiger.Hidden.Dragon")]
        [InlineData("Crouching.Tiger.Hidden.Dragon.HDR.mkv", "Crouching.Tiger.Hidden.Dragon")]
        [InlineData("Crouching.Tiger.Hidden.Dragon.HDC.mkv", "Crouching.Tiger.Hidden.Dragon")]
        [InlineData("Crouching.Tiger.Hidden.Dragon-HDC.mkv", "Crouching.Tiger.Hidden.Dragon")]
        [InlineData("Crouching.Tiger.Hidden.Dragon.BDrip.mkv", "Crouching.Tiger.Hidden.Dragon")]
        [InlineData("Crouching.Tiger.Hidden.Dragon.BDrip-HDC.mkv", "Crouching.Tiger.Hidden.Dragon")]
        [InlineData("Crouching.Tiger.Hidden.Dragon.4K.UltraHD.HDR.BDrip-HDC.mkv", "Crouching.Tiger.Hidden.Dragon")]
        // FIXME: [InlineData("After The Sunset - [0004].mkv", "After The Sunset")]
        public void CleanStringTest_NeedsCleaning_Success(string input, string expectedName)
        {
            Assert.True(_videoResolver.TryCleanString(input, out ReadOnlySpan<char> newName));
            // TODO: compare spans when XUnit supports it
            Assert.Equal(expectedName, newName.ToString());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Super movie(2009).mp4")]
        [InlineData("[rec].mkv")]
        [InlineData("American.Psycho.mkv")]
        [InlineData("American Psycho.mkv")]
        [InlineData("Run lola run (lola rennt) (2009).mp4")]
        public void CleanStringTest_DoesntNeedCleaning_False(string? input)
        {
            Assert.False(_videoResolver.TryCleanString(input, out ReadOnlySpan<char> newName));
            Assert.True(newName.IsEmpty);
        }
    }
}
