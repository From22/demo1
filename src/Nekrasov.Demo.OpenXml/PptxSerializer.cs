using System;
using System.IO;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;

namespace Nekrasov.Demo.OpenXml
{
    public class PptxSerializer : IDisposable
    {
        //Attention! Use only the default constructor! Otherwise, the buffer will be immutable
        private readonly MemoryStream _stream = new MemoryStream();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>")]
        public async Task<PresentationDocument> DeserializeAsync(byte[] bytes)
        {
            await _stream.WriteAsync(bytes, 0, bytes.Length);
            _stream.Seek(0, SeekOrigin.Begin);

            PresentationDocument document;
            try
            {
                document = PresentationDocument.Open(_stream, true);

                if (document.DocumentType != PresentationDocumentType.Presentation)
                    throw new Exception("The file is not .pptx");

            }
            catch (Exception)
            {
                document = null;
                throw;
            }

            return document;
        }

        #region IDisposable

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                _stream?.Dispose();
            }

            _isDisposed = true;
        }

        ~PptxSerializer()
        {
            Dispose(false);
        }

        #endregion IDisposable
    }
}