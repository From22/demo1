using System.Collections.Generic;

namespace Nekrasov.Demo.Domain.Abstractions
{
    public interface IFileExtractor : IFileInMemory<IReadOnlyCollection<ExtractedFile>>
    {
        IReadOnlyCollection<string> EntryPaths { get; set; }
    }
}