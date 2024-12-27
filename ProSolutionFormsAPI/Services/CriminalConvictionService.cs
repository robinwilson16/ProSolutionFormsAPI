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

        public async Task<ModelResultModel> Add(CriminalConvictionModel newCriminalConviction)
        {
            _context.CriminalConviction?.Add(newCriminalConviction);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> AddMany(List<CriminalConvictionModel> newCriminalConvictions)
        {
            await _context.CriminalConviction?.AddRangeAsync(newCriminalConvictions)!;
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Update(CriminalConvictionModel? changedCriminalConviction)
        {
            CriminalConvictionModel? recordToUpdate = _context.CriminalConviction!
                .FirstOrDefault(c => c.CriminalConvictionID == changedCriminalConviction!.CriminalConvictionID);

            if (_context.CriminalConviction == null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(changedCriminalConviction!);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> UpdateMany(int studentDetailID, List<CriminalConvictionModel>? changedCriminalConvictions)
        {
            if (changedCriminalConvictions is null)
                return new ModelResultModel() { IsSuccessful = false };

            foreach (var changedCriminalConviction in changedCriminalConvictions)
            {
                CriminalConvictionModel? recordToUpdate = _context.CriminalConviction!
                    .FirstOrDefault(c => c.CriminalConvictionID == changedCriminalConviction.CriminalConvictionID);
                if (_context.CriminalConviction == null)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                else if (recordToUpdate?.StudentDetailID != studentDetailID)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                _context.Entry(recordToUpdate!).CurrentValues.SetValues(changedCriminalConviction);
            }

            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Delete(int criminalConvictionID)
        {
            var recordToDelete = Get(criminalConvictionID);
            if (recordToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.CriminalConviction!.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteMany(int studentDetailID, List<CriminalConvictionModel>? criminalConvictionsToDelete)
        {
            if (criminalConvictionsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            //Check records belong to this student - extra security step
            foreach (var criminalConvictionToDelete in criminalConvictionsToDelete)
            {
                CriminalConvictionModel? recordToDelete = _context.CriminalConviction!
                    .FirstOrDefault(c => c.CriminalConvictionID == criminalConvictionToDelete.CriminalConvictionID);
                if (_context.CriminalConviction == null)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                else if (recordToDelete?.StudentDetailID != studentDetailID)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
            }

            _context.CriminalConviction!.RemoveRange(criminalConvictionsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteAll(int studentDetailID)
        {
            var recordsToDelete = GetByStudentDetailID(studentDetailID);
            if (recordsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.CriminalConviction!.RemoveRange(recordsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }
    }
}
