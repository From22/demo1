using System.IO;
using System.IO.Compression;
using Nekrasov.Demo.OpenXml.Model;
using System.Threading.Tasks;

namespace Nekrasov.Demo.OpenXml
{
    public class PresentationDocumentParser : IPresentationDocumentParser
    {
        private readonly PptxVideoFinder _videoFinder;

        public PresentationDocumentParser(PptxVideoFinder videoFinder)
        {
            _videoFinder = videoFinder;
        }

        public async Task<PptxFIle> ParseAsync(byte[] fileContent, string fileName)
        {
            await Task.CompletedTask;
            PptxFIle file = null;

            var videoEntries = await _videoFinder.FindVideoEntriesASync(fileContent);

            using (var m = new MemoryStream())
            {
                await m.WriteAsync(fileContent, 0, fileContent.Length);
                m.Seek(0, SeekOrigin.Begin);

                var archive = new ZipArchive(m, ZipArchiveMode.Read);
            }

            return file;
        }
    }
}