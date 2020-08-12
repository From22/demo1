using Nekrasov.Demo.Application.Services.Abstraction;
using Nekrasov.Demo.Domain;
using Nekrasov.Demo.Domain.Abstractions;
using Nekrasov.Demo.Dto.ViewModel;
using Nekrasov.Demo.Storage.Model;
using Nekrasov.Demo.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StorageFile = Nekrasov.Demo.Storage.Model.File;

namespace Nekrasov.Demo.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFileParser _parser;
        private readonly IFileRepository _repository;

        public FileService(IFileParser parser, IFileRepository repository)
        {
            _parser = parser;
            _repository = repository;
        }
        public async Task UploadAsync(byte[] content, string fileName)
        {
            var storageFile = new StorageFile
            {
                Id = Guid.NewGuid(),
                Name = fileName,
                Content = content
            };

            IReadOnlyCollection<ExtractedFile> videoFiles = new List<ExtractedFile>();
            try
            {
                videoFiles = await _parser.ParseAsync(content);
                storageFile.IsPptx = true;
                storageFile.WithVideo = videoFiles.Count > 0;
                storageFile.Title = storageFile.WithVideo
                    ? $"The file {fileName} contains  {videoFiles.Count} videos"
                    : $"The file {fileName} does not contain video";
            }
            catch (FormatException)
            {
                storageFile.Title = $"The file {fileName} is not .pptx";
            }

            var counter = 1;
            var storageVideos = videoFiles.Select(v => new VideoFile
            {
                Id = Guid.NewGuid(),
                FileId = storageFile.Id,
                Content = v.Content,
                FullName = v.EntryPath,
                Size = v.Content.Length,
                Number = counter++
            }).ToList();

            await _repository.CreateFileAsync(storageFile, storageVideos);

        }

        public async Task<IEnumerable<FileViewModel>> GetListAsync()
        {
            await Task.CompletedTask;

            var storageFiles = _repository.ReadFiles();

            var result = new List<FileViewModel>();

            if (storageFiles != null && storageFiles.Any())
            {

                foreach (var storageFile in storageFiles)
                {
                    var fileViewModel = new FileViewModel
                    {
                        Title = new Title
                        {
                            Text = storageFile.Title,
                            IsWarning = !storageFile.IsPptx || !storageFile.WithVideo
                        }
                    };


                    var storageVideos = _repository.ReadVideosByFileId(storageFile.Id);

                    if (storageVideos != null && storageVideos.Any())
                    {

                        fileViewModel.Movies = storageVideos.Select(s => new Movie
                        {
                            Name = s.FullName,
                            Number = s.Number.ToString(),
                            SizeInMb = $"{s.Size / 1024}"
                        }).OrderBy(m => m.Number).ToArray();
                    }
                    else
                        fileViewModel.Movies = new Movie[] { };

                    result.Add(fileViewModel);
                }
            }

            return result;
        }
    }
}
