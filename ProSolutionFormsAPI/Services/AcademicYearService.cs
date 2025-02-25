using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class AcademicYearService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public List<DropDownStringModel>? DropDownValues { get; }

        public AcademicYearService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            DropDownValues = _context.DropDownString!
                .FromSqlInterpolated($"EXEC SPR_GetAcademicYears")
                .ToList();
        }

        public List<DropDownStringModel>? GetAll() => DropDownValues;

        public DropDownStringModel? Get(string code) => DropDownValues?.FirstOrDefault(d => d.Code == code);
    }
}
