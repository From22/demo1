using Nekrasov.Demo.Dto.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nekrasov.Demo.Application.Services.Abstraction
{
    public interface IFileService
    {
        Task UploadAsync(byte[] content, string fileName);

        Task<IEnumerable<FileViewModel>> GetListAsync(string hostValue);
    }
}