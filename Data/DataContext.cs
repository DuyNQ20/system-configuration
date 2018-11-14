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
        

        public DbSet<Configuration.Models.SystemSetting> SystemSetting { get; set; }
        

        public DbSet<Configuration.Models.SystemSettingGroup> SystemSettingGroup { get; set; }
        

        public DbSet<Configuration.Models.PersonalSettingGroup> PersonalSettingGroup { get; set; }
        

        public DbSet<Configuration.Models.PersonalSettingGroupDescription> PersonalSettingGroupDescription { get; set; }
        

        public DbSet<Configuration.Models.PersonalSetting> PersonalSetting { get; set; }
        

        public DbSet<Configuration.Models.PersonalSettingDescription> PersonalSettingDescription { get; set; }
        

        public DbSet<Configuration.Models.UserSetting> UserSetting { get; set; }
    }
}
