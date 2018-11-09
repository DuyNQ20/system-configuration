using Configuration.Models;
using Microsoft.EntityFrameworkCore;

namespace Configuration.Data
{
    public class DataContext : DbContext
    {
        public DbContextOptions<DataContext> Options { get; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>().ToTable("Files");
        }
        

        public DbSet<Configuration.Models.File> Files { get; set; }
    }
}
