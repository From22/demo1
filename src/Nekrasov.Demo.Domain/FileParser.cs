using System.Collections.Generic;
using System.Threading.Tasks;
using Nekrasov.Demo.Domain.Abstractions;

namespace Nekrasov.Demo.Domain
{
    public class FileParser : IFileParser
    {
        private readonly IReferenceRelationshipSelector _selector;
        private readonly IFileExtractor _extractor;

        public FileParser(IReferenceRelationshipSelector selector, IFileExtractor extractor)
        {
            _selector = selector;
            _extractor = extractor;
        }

        public async Task<IReadOnlyCollection<ExtractedFile>> ParseAsync(byte[] content)
        {
            var paths = await _selector.SelectReferenceRelationshipAsync(content);

            _extractor.EntryPaths = paths;

            var d = await _extractor.ProcessAsync(content);

            return d;
        }

        /// <inheritdoc />
        public async ValueTask DisposeAsync()
        {
            await _selector.DisposeAsync();
            await _extractor.DisposeAsync();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _selector.Dispose();
            _extractor.Dispose();
        }
    }
}
