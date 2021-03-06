﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using Nekrasov.Demo.Domain.Abstractions;

namespace Nekrasov.Demo.Domain.OpenXml.Pptx
{
    public class ReferenceRelationshipSelector<T> : IReferenceRelationshipSelector
        where T : DataPartReferenceRelationship
    {
        private readonly IFileInMemory<PresentationDocument> _serializer;
        private static Type RefType => typeof(T);

        public ReferenceRelationshipSelector(IFileInMemory<PresentationDocument> serializer)
        {
            _serializer = serializer;
        }

        public async Task<IReadOnlyCollection<string>> SelectReferenceRelationshipAsync(byte[] pptx)
        {
            var document = await _serializer.ProcessAsync(pptx);

            return SelectEntries(document);
        }

        private IReadOnlyCollection<string> SelectEntries(PresentationDocument pptx)
        {
            var result = new List<string>();

            foreach (var slide in pptx.PresentationPart.SlideParts)
            {
                var uriList = slide.DataPartReferenceRelationships
                    .Where(r => r.GetType() == RefType)
                    .Select(r => r.Uri.ToString()).ToList();

                foreach (var uri in uriList)
                {
                    var entryPath = Regex.Replace(uri, "^/", string.Empty);
                    if (result.Contains(entryPath))
                    {
                        continue;
                    }

                    result.Add(entryPath);
                }
            }

            return result;
        }

        /// <inheritdoc />
        public async ValueTask DisposeAsync()
        {
            await _serializer.DisposeAsync();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _serializer.Dispose();
        }
    }
}