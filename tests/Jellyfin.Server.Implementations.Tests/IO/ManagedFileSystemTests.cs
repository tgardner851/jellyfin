using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using AutoFixture;
using AutoFixture.AutoMoq;
using Emby.Server.Implementations.IO;
using MediaBrowser.Model.System;
using Xunit;

namespace Jellyfin.Server.Implementations.Tests.IO
{
    public class ManagedFileSystemTests
    {
        private readonly IFixture _fixture;
        private readonly ManagedFileSystem _sut;

        public ManagedFileSystemTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });
            _sut = _fixture.Create<ManagedFileSystem>();
        }

        [Theory]
        [InlineData("/Volumes/Library/Sample/Music/Playlists/", "../Beethoven/Misc/Moonlight Sonata.mp3", "/Volumes/Library/Sample/Music/Beethoven/Misc/Moonlight Sonata.mp3")]
        [InlineData("/Volumes/Library/Sample/Music/Playlists/", "../../Beethoven/Misc/Moonlight Sonata.mp3", "/Volumes/Library/Sample/Beethoven/Misc/Moonlight Sonata.mp3")]
        [InlineData("/Volumes/Library/Sample/Music/Playlists/", "Beethoven/Misc/Moonlight Sonata.mp3", "/Volumes/Library/Sample/Music/Playlists/Beethoven/Misc/Moonlight Sonata.mp3")]
        public void MakeAbsolutePathCorrectlyHandlesRelativeFilePaths(
            string folderPath,
            string filePath,
            string expectedAbsolutePath)
        {
            var generatedPath = _sut.MakeAbsolutePath(folderPath, filePath);

            if (MediaBrowser.Common.System.OperatingSystem.Id == OperatingSystemId.Windows)
            {
                var expectedWindowsPath = expectedAbsolutePath.Replace('/', '\\');
                Assert.Equal(expectedWindowsPath, generatedPath.Split(':')[1]);
            }
            else
            {
                Assert.Equal(expectedAbsolutePath, generatedPath);
            }
        }

        [SkippableFact]
        public void GetFileInfo_DanglingSymlink_ExistsFalse()
        {
            Skip.If(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));

            string testFileDir = Path.Combine(Path.GetTempPath(), "jellyfin-test-data");
            string testFileName = Path.Combine(testFileDir, Path.GetRandomFileName() + "-danglingsym.link");

            Directory.CreateDirectory(testFileDir);
            Assert.Equal(0, symlink("thispathdoesntexist", testFileName));
            Assert.True(File.Exists(testFileName));

            var metadata = _sut.GetFileInfo(testFileName);
            Assert.False(metadata.Exists);
        }

        [SuppressMessage("Naming Rules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Have to")]
        [DllImport("libc", SetLastError = true, CharSet = CharSet.Ansi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern int symlink(string target, string linkpath);
    }
}
