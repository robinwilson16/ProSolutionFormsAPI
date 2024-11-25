using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace ProSolutionFormsAPI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration _configuration) : DbContext(options)
    {
        public IConfiguration configuration { get; } = _configuration;

        public DbSet<ConfigModel>? Config { get; set; }
        public DbSet<CriminalConvictionModel>? CriminalConviction { get; set; }
        public DbSet<StudentModel>? Student { get; set; }
        public DbSet<StudentUniqueReferenceModel>? StudentUniqueReference { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentModel>().ToTable(t => t.ExcludeFromMigrations());

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