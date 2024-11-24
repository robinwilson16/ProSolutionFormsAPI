using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace ProSolutionFormsAPI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration _configuration) : DbContext(options)
    {
        public IConfiguration configuration { get; } = _configuration;

        public DbSet<Config>? Config { get; set; }
        public DbSet<CriminalConviction>? CriminalConviction { get; set; }
        public DbSet<Student>? Student { get; set; }
        public DbSet<StudentUniqueReference>? StudentUniqueReference { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable(t => t.ExcludeFromMigrations());

            //Unique value
            //modelBuilder.Entity<StudentUniqueReference>().HasIndex(s => s.StudentRef).IsUnique();
        }

        //Rename migration history table
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer(
        //        configuration.GetConnectionString("DefaultConnection"),
        //        x => x.MigrationsHistoryTable("__CRI_EFMigrationsHistory", "dbo"));

        //Rename migration history table
    }
}