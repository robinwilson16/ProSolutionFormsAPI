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
            CriminalConvictionModel? recordToUpdate = _context.CriminalConviction!
                .FirstOrDefault(c => c.CriminalConvictionID == criminalConviction!.CriminalConvictionID);

            if (_context.CriminalConviction == null)
            {
                return;
            }

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(criminalConviction!);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMany(int studentDetailID, List<CriminalConvictionModel>? criminalConvictions)
        {
            if (criminalConvictions is null)
                return;

            foreach (var criminalConviction in criminalConvictions)
            {
                CriminalConvictionModel? recordToUpdate = _context.CriminalConviction!
                    .FirstOrDefault(c => c.CriminalConvictionID == criminalConviction.CriminalConvictionID);
                if (_context.CriminalConviction == null)
                {
                    return;
                }
                else if (recordToUpdate?.StudentDetailID != studentDetailID)
                {
                    return;
                }
                _context.Entry(recordToUpdate!).CurrentValues.SetValues(criminalConviction);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int criminalConvictionID)
        {
            var recordToDelete = Get(criminalConvictionID);
            if (recordToDelete is null)
                return;

            _context.CriminalConviction!.Remove(recordToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(int studentDetailID, List<CriminalConvictionModel>? criminalConvictions)
        {
            if (criminalConvictions is null)
                return;

            //Check records belong to this student - extra security step
            foreach (var criminalConviction in criminalConvictions)
            {
                CriminalConvictionModel? recordToDelete = _context.CriminalConviction!
                    .FirstOrDefault(c => c.CriminalConvictionID == criminalConviction.CriminalConvictionID);
                if (_context.CriminalConviction == null)
                {
                    return;
                }
                else if (recordToDelete?.StudentDetailID != studentDetailID)
                {
                    return;
                }
            }

            _context.CriminalConviction!.RemoveRange(criminalConvictions);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAll(int studentDetailID)
        {
            var recordsToDelete = GetByStudentDetailID(studentDetailID);
            if (recordsToDelete is null)
                return;

            _context.CriminalConviction!.RemoveRange(recordsToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
