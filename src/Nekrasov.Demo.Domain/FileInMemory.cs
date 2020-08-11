using System.IO;
using System.Threading.Tasks;
using Nekrasov.Demo.Domain.Abstractions;

namespace Nekrasov.Demo.Domain
{
    public abstract class FileInMemory<TResult> : IFileInMemory<TResult>
    {
        //Attention! Use only the default constructor! Otherwise, the buffer will be immutable
        protected readonly MemoryStream Stream = new MemoryStream();

        protected async Task LoadBytesAsync(byte[] bytes)
        {
            await Stream.WriteAsync(bytes, 0, bytes.Length);
            Stream.Seek(0, SeekOrigin.Begin);
        }

        public abstract Task<TResult> ProcessAsync(byte[] bytes);


        public virtual void Dispose()
        {
            Stream?.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await Stream.DisposeAsync();
        }
    }
}
