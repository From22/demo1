using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Nekrasov.Demo.Application.Mapping;
using Nekrasov.Demo.Domain;

namespace Nekrasov.Demo.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddDomainServices()
                .AddAutoMapper(typeof(MappingProfile))
                ;
            return services;
        }
    }
}
