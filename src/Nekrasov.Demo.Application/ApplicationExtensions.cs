using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nekrasov.Demo.Application.Mapping;
using Nekrasov.Demo.Application.Services;
using Nekrasov.Demo.Application.Services.Abstraction;
using Nekrasov.Demo.Domain;
using Nekrasov.Demo.Storage;

namespace Nekrasov.Demo.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddStorageServices(configuration)
                .AddDomainServices()
                .AddScoped<IFileService, FileService>()
                .AddAutoMapper(typeof(MappingProfile))
                ;
            return services;
        }
    }
}
