using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Nekrasov.Demo.Domain.Abstractions;

namespace Nekrasov.Demo.Domain.Zip
{
    public class FileExtractor : FileInMemory<IReadOnlyCollection<ExtractedFile>>, IFileExtractor
    {
        public IReadOnlyCollection<string> EntryPaths { get; set; }

        public override async Task<IReadOnlyCollection<ExtractedFile>> ProcessAsync(byte[] bytes)
        {
            if (EntryPaths == null)
                throw new NullReferenceException($"Before calling the method, you must set the '{nameof(EntryPaths)}' property");

            await LoadBytesAsync(bytes);

            var result = await ExtractFilesASync();

            return result;
        }

        private async Task<IReadOnlyCollection<ExtractedFile>> ExtractFilesASync()
        {
            var archive = new ZipArchive(Stream, ZipArchiveMode.Read);

            var result = new List<ExtractedFile>();

            foreach (var entryPath in EntryPaths)
            {
                var zipEntry = archive.GetEntry(entryPath);

                var extractedFile = new ExtractedFile { EntryPath = entryPath };

                result.Add(extractedFile);

                if (zipEntry == null)
                    continue;

                await using var r = zipEntry.Open();

                await using var newStream = new MemoryStream();

                await r.CopyToAsync(newStream);

                extractedFile.Content = newStream.ToArray();
            }

            return result;
        }
    }
}
