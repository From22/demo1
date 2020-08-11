using Nekrasov.Demo.Domain.Zip;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Nekrasov.Demo.Tests.Domain
{
    [TestFixture]
    public class FileExtractorTests
    {
        [TestCase(@"testData\fileWithVideo.pptx", "ppt/media/media1.mp4", "rld2")]
        public async Task ExtractFile_WhenFileIsPptxAndContainsVideo_Then(string filePath, string uri, string id)
        {
            //Arrange
            await using var sut = new FileExtractor
            {
                EntryPaths = new List<string>(new[] { uri })
            };
            //Act
            var d = await sut.ProcessAsync(await File.ReadAllBytesAsync(filePath));
            //Assert
            Assert.True(d?.Count > 0);
        }
    }
}