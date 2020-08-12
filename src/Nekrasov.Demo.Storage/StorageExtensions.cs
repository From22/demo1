using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nekrasov.Demo.Storage.Repository;

namespace Nekrasov.Demo.Storage
{
    public static class StorageExtensions
    {
        public static IServiceCollection AddStorageServices(this IServiceCollection services)
        {
            services
                .AddDbContext<FilesContext>(o=>o.UseSqlite(@"Data Source=NekrasovDemo.db;"))
                .AddScoped<IFileRepository, FileRepository>()
                ;
            return services;
        }
    }
}
