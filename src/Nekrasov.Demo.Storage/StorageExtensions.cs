using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nekrasov.Demo.Storage.Repository;

namespace Nekrasov.Demo.Storage
{
    public static class StorageExtensions
    {
        public static IServiceCollection AddStorageServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddDbContext<FilesContext>(o=>o.UseSqlServer(configuration.GetConnectionString("OwnDatabase")))
                .AddScoped<IFileRepository, FileRepository>()
                ;
            return services;
        }
    }
}
