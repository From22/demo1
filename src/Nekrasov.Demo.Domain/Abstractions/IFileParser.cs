using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nekrasov.Demo.Domain.Model;

namespace Nekrasov.Demo.Domain.Abstractions
{
    public interface IFileParser: IAsyncDisposable, IDisposable
    {
        Task<IReadOnlyCollection<ExtractedFile>> ParseAsync(byte[] content);
    }
}