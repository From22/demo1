using System.IO;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using Nekrasov.Demo.Domain.OpenXml.Pptx;
using NUnit.Framework;

namespace Nekrasov.Demo.Tests.Domain
{
    [TestFixture]
    public class ReferenceRelationshipSelectorTests
    {
        [TestCase(@"testData\fileWithVideo.pptx")]
        public async Task ReadFile_WhenFileIsPptxAndContainsVideo_Then(string filePath)
        {
            //Arrange
            var content = await File.ReadAllBytesAsync(filePath);
            var sut = new ReferenceRelationshipSelector<VideoReferenceRelationship>(new PptxSerializer());
            //Act
            var d = await sut.SelectReferenceRelationshipAsync(content);
            //Assert
            Assert.True(d?.Count > 0);
        }

    }
}