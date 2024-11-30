using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class CriminalConvictionService
    {
        private readonly ApplicationDbContext _context;


        public List<CriminalConvictionModel>? CriminalConvictions { get; }

        public CriminalConvictionService(ApplicationDbContext context)
        {
            _context = context;

            CriminalConvictions = _context.CriminalConviction!
                .ToList();
        }

        public List<CriminalConvictionModel>? GetAll() => CriminalConvictions;

        public CriminalConvictionModel? Get(int criminalConvictionID) => CriminalConvictions?.FirstOrDefault(c => c.CriminalConvictionID == criminalConvictionID);

        public List<CriminalConvictionModel>? GetByStudentRef(string academicYear, string studentRef) => CriminalConvictions?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentRef == studentRef)
            .ToList();

        public List<CriminalConvictionModel>? GetByStudentDetailID(int studentDetailID) => CriminalConvictions?
            .Where(c => c.StudentDetailID == studentDetailID)
            .ToList();

        public async Task Add(CriminalConvictionModel studentDetailID)
        {
            _context.CriminalConviction?.Add(studentDetailID);
            await _context.SaveChangesAsync();
        }

        public async Task AddMany(List<CriminalConvictionModel> studentDetailID)
        {
            await _context.CriminalConviction?.AddRangeAsync(studentDetailID)!;
            await _context.SaveChangesAsync();
        }

        public async Task Update(CriminalConvictionModel? criminalConviction)
        {
            CriminalConvictionModel? criminalConvictionDB = _context.CriminalConviction!
                .FirstOrDefault(c => c.CriminalConvictionID == criminalConviction!.CriminalConvictionID);

            if (_context.CriminalConviction == null)
            {
                return;
            }

            _context.Entry(criminalConvictionDB!).CurrentValues.SetValues(criminalConviction!);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int criminalConvictionID)
        {
            var criminalConviction = Get(criminalConvictionID);
            if (criminalConviction is null)
                return;

            _context.CriminalConviction!.Remove(criminalConviction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteForStudent(int studentDetailID)
        {
            var criminalConviction = GetByStudentDetailID(studentDetailID);
            if (criminalConviction is null)
                return;

            _context.CriminalConviction!.RemoveRange(criminalConviction);
            await _context.SaveChangesAsync();
        }
    }
}
