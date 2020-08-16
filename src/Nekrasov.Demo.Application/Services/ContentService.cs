using System.Threading.Tasks;
using MimeKit;
using Nekrasov.Demo.Application.Services.Abstraction;
using Nekrasov.Demo.Storage.Repository;

namespace Nekrasov.Demo.Application.Services
{
    public class ContentService : IContentService
    {
        private readonly IFileRepository _repository;

        public ContentService(IFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<(byte[], string)> ReadVideoAsync(string videoId)
        {
            var (content, fileName) = await _repository.ReadVideoAsync(videoId);

            var contentType = MimeTypes.GetMimeType(fileName);

            return (content, contentType);
        }
    }
}