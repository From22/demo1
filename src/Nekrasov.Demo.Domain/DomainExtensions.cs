using DocumentFormat.OpenXml.Packaging;
using Microsoft.Extensions.DependencyInjection;
using Nekrasov.Demo.Domain.Abstractions;
using Nekrasov.Demo.Domain.OpenXml.Pptx;
using Nekrasov.Demo.Domain.Zip;

namespace Nekrasov.Demo.Domain
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services
                .AddTransient<IFileInMemory<PresentationDocument>, PptxSerializer>()
                .AddTransient<IReferenceRelationshipSelector, ReferenceRelationshipSelector<VideoReferenceRelationship>>()
                .AddTransient<IFileExtractor, FileExtractor>()
                .AddTransient<IFileParser, FileParser>();

            return services;
        }
    }
}
