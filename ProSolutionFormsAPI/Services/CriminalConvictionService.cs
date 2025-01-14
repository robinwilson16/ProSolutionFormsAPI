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
                .Include(c => c.Offences)
                .ToList();
        }

        public List<CriminalConvictionModel>? GetAll() => CriminalConvictions;

        public CriminalConvictionModel? Get(int criminalConvictionID) => CriminalConvictions?.FirstOrDefault(c => c.CriminalConvictionID == criminalConvictionID);

        public CriminalConvictionModel? GetByGUID(string academicYear, Guid studentGUID) => CriminalConvictions?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentGUID == studentGUID)
            .FirstOrDefault();

        public CriminalConvictionModel? GetByStudentRef(string academicYear, string studentRef) => CriminalConvictions?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentRef == studentRef)
            .FirstOrDefault();

        public CriminalConvictionModel? GetByStudentDetailID(int studentDetailID) => CriminalConvictions?
            .Where(c => c.StudentDetailID == studentDetailID)
            .FirstOrDefault();

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

        public async Task<ModelResultModel> Update(CriminalConvictionModel? updatedCriminalConviction, bool? save)
        {
            //Include any related entities
            CriminalConvictionModel? recordToUpdate = _context.CriminalConviction!
                .FirstOrDefault(m => m.CriminalConvictionID == updatedCriminalConviction!.CriminalConvictionID);

            if (recordToUpdate == null)
                return new ModelResultModel() { IsSuccessful = false };

            //Update IDs on related entities
            //Need to get full related entity as only the ID is set in the updated record so causes the rest of the fields to be wiped out
            //None

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(updatedCriminalConviction!);

            //Update content of related entities
            //None

            //Ensures related entities are included in the save operation
            _context?.Update(recordToUpdate);

            if (save != false)
                await _context!.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> UpdateMany(int studentDetailID, List<CriminalConvictionModel>? updatedCriminalConvictions)
        {
            if (updatedCriminalConvictions is null)
                return new ModelResultModel() { IsSuccessful = false };

            foreach (var updatedCriminalConviction in updatedCriminalConvictions)
            {
                await Update(updatedCriminalConviction, false);
            }

            //Save all changes at the end to avoid multiple save operations
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
