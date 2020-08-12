using Microsoft.EntityFrameworkCore;
using Nekrasov.Demo.Storage.Model;

namespace Nekrasov.Demo.Storage
{
    public class FilesContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<VideoFIle> VideoFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=NekrasovDemo.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>().ToTable("PptxFiles");
            modelBuilder.Entity<VideoFIle>().ToTable("VideoFiles");
        }
    }
}
