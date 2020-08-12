using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nekrasov.Demo.Storage.Model;

namespace Nekrasov.Demo.Storage.Repository
{
    public interface IFileRepository
    {
        Task CreateFileAsync(File file, IReadOnlyCollection<VideoFile> videos);
        IEnumerable<File> ReadFiles();
        IEnumerable<VideoFile> ReadVideosByFileId(Guid fileId);
    }

    public class FileRepository : IFileRepository
    {
        readonly FilesContext _dbContext;
        public FileRepository(FilesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateFileAsync(File file, IReadOnlyCollection<VideoFile> videos)
        {
            await _dbContext.Files.AddAsync(file);

            if (videos != null && videos.Count > 0) 
                await _dbContext.VideoFiles.AddRangeAsync(videos);

            await _dbContext.SaveChangesAsync();

        }

        public IEnumerable<File> ReadFiles()
        {
            return _dbContext.Files.ToList();
        }

        /// <inheritdoc />
        public IEnumerable<VideoFile> ReadVideosByFileId(Guid fileId)
        {
            return _dbContext.VideoFiles.Where(v=>v.FileId == fileId).ToList();
        }
    }
}