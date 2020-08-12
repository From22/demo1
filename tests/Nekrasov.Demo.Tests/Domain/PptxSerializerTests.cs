using System;
using System.IO;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using Nekrasov.Demo.Domain.OpenXml.Pptx;
using NUnit.Framework;

namespace Nekrasov.Demo.Tests.Domain
{
    [TestFixture]
    public class PptxSerializerTests
    {
        [TestCase(@"testData\fileWithVideo - Copy.pptx", false)]
        [TestCase(@"testData\fileWithVideo.pptx", false)]
        [TestCase(@"testData\badFile.pptx", true)]
        [TestCase(@"testData\badFile.docx", true)]
        public async Task ReadFile_WhenFileIsPptxAndContainsVideo_Then(string filePath, bool exceptionExpected)
        {
            //Arange
            var content = await File.ReadAllBytesAsync(filePath);
            var sut = new PptxSerializer();
            Exception exception = null;
            PresentationDocument pptxDoc = null;

            //Act
            try
            {
                pptxDoc = await sut.ProcessAsync(content);
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                sut.Dispose();
            }

            //Assert
            Assert.IsTrue((exceptionExpected && exception != null && pptxDoc == null) || (!exceptionExpected && exception == null && pptxDoc != null));
        }

    }
}