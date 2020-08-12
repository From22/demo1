using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Nekrasov.Demo.Dto.ViewModel;

namespace Nekrasov.Demo.Application.Services.Abstraction
{
    public interface IFileService
    {
        Task UploadAsync(byte[] content, string fileName);

        Task<IEnumerable<FileViewModel>> GetListAsync();
    }
}