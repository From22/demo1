using System;
using System.Threading.Tasks;

namespace Nekrasov.Demo.Domain.Abstractions
{
    public interface IFileInMemory<TResult> : IAsyncDisposable, IDisposable
    {
        Task<TResult> ProcessAsync(byte[] bytes);
    }
}