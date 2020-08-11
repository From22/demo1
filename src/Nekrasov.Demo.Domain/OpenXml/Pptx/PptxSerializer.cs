using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Threading.Tasks;

namespace Nekrasov.Demo.Domain.OpenXml.Pptx
{
    public class PptxSerializer : FileInMemory<PresentationDocument>
    {
        /// <inheritdoc />
        public override async Task<PresentationDocument> ProcessAsync(byte[] bytes)
        {
            await LoadBytesAsync(bytes);

            var document = PresentationDocument.Open(Stream, true);

            if (document.DocumentType != PresentationDocumentType.Presentation)
                throw new Exception("The file is not .pptx");

            return document;

        }
    }
}