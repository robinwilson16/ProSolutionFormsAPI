using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class TitleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public List<DropDownStringModel>? DropDownValues { get; }
        public string AcademicYear { get; }

        public TitleService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            string academicYear = (string?)configuration.GetSection("Settings")["DefaultAcademicYearID"] ?? "";
            AcademicYear = academicYear;

            DropDownValues = _context.DropDownString!
                .FromSqlInterpolated($"EXEC SPR_GetTitles @AcademicYear = {AcademicYear}")
                .ToList();
        }

        public List<DropDownStringModel>? GetAll() => DropDownValues;

        public DropDownStringModel? Get(string code) => DropDownValues?.FirstOrDefault(d => d.Code == code);
    }
}
