using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class CriminalConvictionService
    {
        private readonly ApplicationDbContext _context;


        public List<CriminalConviction>? CriminalConvictions { get; }

        public CriminalConvictionService(ApplicationDbContext context)
        {
            _context = context;

            CriminalConvictions = _context.CriminalConviction!
                .ToList();
        }

        public List<CriminalConviction>? GetAll() => CriminalConvictions;

        public CriminalConviction? Get(int criminalConvictionID) => CriminalConvictions?.FirstOrDefault(c => c.CriminalConvictionID == criminalConvictionID);

        public List<CriminalConviction>? GetByStudentRef(string academicYear, string studentRef) => CriminalConvictions?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentRef == studentRef)
            .ToList();

        public List<CriminalConviction>? GetByStudentDetailID(int studentDetailID) => CriminalConvictions?
            .Where(c => c.StudentDetailID == studentDetailID)
            .ToList();

        public async Task Add(CriminalConviction studentDetailID)
        {
            _context.CriminalConviction?.Add(studentDetailID);
            await _context.SaveChangesAsync();
        }

        public async Task Update(CriminalConviction? criminalConviction)
        {
            CriminalConviction? criminalConvictionDB = _context.CriminalConviction!
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
