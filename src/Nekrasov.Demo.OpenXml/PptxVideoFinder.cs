using DocumentFormat.OpenXml.Packaging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nekrasov.Demo.OpenXml
{
    public class PptxVideoFinder
    {
        public async Task<IReadOnlyCollection<MediaEntry>> FindVideoEntriesASync(byte[] pptx)
        {
            using var pptxSerializer = new PptxSerializer();

            var document = await pptxSerializer.DeserializeAsync(pptx);

            return FindVideoEntries(document);
        }

        private IReadOnlyCollection<MediaEntry> FindVideoEntries(PresentationDocument pptx)
        {
            var result = new List<MediaEntry>();

            foreach (var slide in pptx.PresentationPart.SlideParts)
            {
                result.AddRange(slide.DataPartReferenceRelationships
                    .Where(r => r.GetType() == typeof(VideoReferenceRelationship))
                    .Select(r => new MediaEntry { Uri = r.Uri.ToString(), Id = r.Id }));
            }

            return result;
        }

    }
}