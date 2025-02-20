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
        public DbSet<CriminalConvictionOffenceModel>? CriminalConvictionOffence { get; set; }
        public DbSet<DropDownIntModel>? DropDownInt { get; set; }
        public DbSet<DropDownStringModel>? DropDownString { get; set; }
        public DbSet<FundingEligibilityDeclarationEvidenceModel>? FundingEligibilityDeclarationEvidence { get; set; }
        public DbSet<FundingEligibilityDeclarationModel>? FundingEligibilityDeclaration { get; set; }
        public DbSet<GraphAPIAuthorisationModel>? GraphAPIAuthorisation { get; set; }
        public DbSet<GraphAPITokenModel>? GraphAPIToken { get; set; }
        public DbSet<MedicalLearningSupportAndTripConsentModel>? MedicalLearningSupportAndTripConsent { get; set; }
        public DbSet<MedicalLearningSupportAndTripConsentLearningDifficultyDisabilityModel>? MedicalLearningSupportAndTripConsentLearningDifficultyDisability { get; set; }
        public DbSet<MedicalLearningSupportAndTripConsentEmergencyContactModel>? MedicalLearningSupportAndTripConsentEmergencyContact { get; set; }
        public DbSet<MedicalLearningSupportAndTripConsentMedicalConditionModel>? MedicalLearningSupportAndTripConsentMedicalCondition { get; set; }
        public DbSet<StudentModel>? Student { get; set; }
        public DbSet<StudentDetailModel>? StudentDetail { get; set; }
        public DbSet<StudentUniqueReferenceModel>? StudentUniqueReference { get; set; }
        public DbSet<SystemFileModel>? SystemFile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DropDownIntModel>().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<DropDownStringModel>().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<StudentModel>().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<StudentDetailModel>().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<SystemFileModel>().ToTable(t => t.ExcludeFromMigrations());

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