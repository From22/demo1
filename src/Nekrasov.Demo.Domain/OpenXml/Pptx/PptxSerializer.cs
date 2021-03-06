﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Threading.Tasks;
using Nekrasov.Demo.Domain.Abstractions;

namespace Nekrasov.Demo.Domain.OpenXml.Pptx
{
    public class PptxSerializer : FileInMemory<PresentationDocument>
    {

        /// <inheritdoc />
        public override async Task<PresentationDocument> ProcessAsync(byte[] bytes)
        {

            await LoadBytesAsync(bytes);
            //await Task.CompletedTask;

            PresentationDocument document;
            try
            {
                document = PresentationDocument.Open(Stream, true);

                if (document == null || document.DocumentType != PresentationDocumentType.Presentation)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new FormatException("The file is not .pptx");
            }

            return document;

        }
    }
}