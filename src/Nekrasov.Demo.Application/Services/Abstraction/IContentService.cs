using System.Threading.Tasks;

namespace Nekrasov.Demo.Application.Services.Abstraction
{
    public interface IContentService
    {
        Task<(byte[], string)> ReadVideoAsync(string videoId);
    }
}