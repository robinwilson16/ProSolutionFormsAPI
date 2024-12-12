using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class RelationshipService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public List<DropDownIntModel>? DropDownValues { get; }
        public string AcademicYear { get; }

        public RelationshipService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            string academicYear = (string?)configuration.GetSection("Settings")["DefaultAcademicYearID"] ?? "";
            AcademicYear = academicYear;

            DropDownValues = _context.DropDownInt!
                .FromSqlInterpolated($"EXEC SPR_GetRelationships @AcademicYear = {AcademicYear}")
                .ToList();
        }

        public List<DropDownIntModel>? GetAll() => DropDownValues;

        public DropDownIntModel? Get(int code) => DropDownValues?.FirstOrDefault(d => d.Code == code);
    }
}
