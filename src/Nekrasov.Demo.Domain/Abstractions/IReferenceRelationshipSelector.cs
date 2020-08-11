using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nekrasov.Demo.Domain.Abstractions
{
    public interface IReferenceRelationshipSelector: IAsyncDisposable, IDisposable
    {
        Task<IReadOnlyCollection<string>> SelectReferenceRelationshipAsync(byte[] pptx);
    }
}