using System.Collections.Generic;
using Nekrasov.Demo.Domain.Model;

namespace Nekrasov.Demo.Domain.Abstractions
{
    public interface IFileExtractor : IFileInMemory<IReadOnlyCollection<ExtractedFile>>
    {
        IReadOnlyCollection<string> EntryPaths { get; set; }
    }
}