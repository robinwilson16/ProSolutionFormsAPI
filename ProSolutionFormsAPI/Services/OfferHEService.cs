using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class OfferHEService
    {
        private readonly ApplicationDbContext _context;


        public List<OfferHEModel>? OfferHEs { get; }

        public OfferHEService(ApplicationDbContext context)
        {
            _context = context;

            OfferHEs = _context.OfferHE!
                .Include(o => o.Attachments)
                .ToList();
        }

        public List<OfferHEModel>? GetAll() => OfferHEs;

        public OfferHEModel? Get(int offerHEID) => OfferHEs?.FirstOrDefault(c => c.OfferHEID == offerHEID);

        public List<OfferHEModel>? GetByGUID(string academicYear, Guid studentGUID) => OfferHEs?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentGUID == studentGUID)
            .ToList();

        public OfferHEModel? GetByGUIDAndID(Guid studentGUID, int offerHEID) => OfferHEs?
            .Where(c => c.StudentGUID == studentGUID)
            .Where(c => c.OfferHEID == offerHEID)
            .FirstOrDefault();

        public OfferHEModel? GetByGUIDAndApplicationCourse(Guid studentGUID, int applicationCourseID) => OfferHEs?
            .Where(c => c.StudentGUID == studentGUID)
            .Where(c => c.ApplicationCourseID == applicationCourseID)
            .FirstOrDefault();

        public OfferHEModel? GetByGUIDYearAndApplicationCourse(string academicYear, Guid studentGUID, int applicationCourseID) => OfferHEs?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentGUID == studentGUID)
            .Where(c => c.ApplicationCourseID == applicationCourseID)
            .FirstOrDefault();

        public OfferHEModel? GetByStudentRef(string academicYear, string studentRef) => OfferHEs?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentRef == studentRef)
            .FirstOrDefault();

        public OfferHEModel? GetByStudentDetailID(int studentDetailID) => OfferHEs?
            .Where(c => c.StudentDetailID == studentDetailID)
            .FirstOrDefault();

        public async Task<ModelResultModel> Add(OfferHEModel newOfferHE)
        {
            _context.OfferHE?.Add(newOfferHE);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> AddMany(List<OfferHEModel> newOfferHEs)
        {
            await _context.OfferHE?.AddRangeAsync(newOfferHEs)!;
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Update(OfferHEModel? updatedOfferHE, bool? save)
        {
            //Include any related entities
            OfferHEModel? recordToUpdate = _context.OfferHE!
                .FirstOrDefault(m => m.OfferHEID == updatedOfferHE!.OfferHEID);

            if (recordToUpdate == null)
                return new ModelResultModel() { IsSuccessful = false };

            //Update IDs on related entities
            //Need to get full related entity as only the ID is set in the updated record so causes the rest of the fields to be wiped out
            //None

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(updatedOfferHE!);

            //Update content of related entities
            //None

            //Ensures related entities are included in the save operation
            _context?.Update(recordToUpdate);

            if (save != false)
                await _context!.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> UpdateMany(int studentDetailID, List<OfferHEModel>? updatedOfferHEs)
        {
            if (updatedOfferHEs is null)
                return new ModelResultModel() { IsSuccessful = false };

            foreach (var updatedOfferHE in updatedOfferHEs)
            {
                await Update(updatedOfferHE, false);
            }

            //Save all changes at the end to avoid multiple save operations
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Delete(int offerHEID)
        {
            var recordToDelete = Get(offerHEID);
            if (recordToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.OfferHE!.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteMany(int studentDetailID, List<OfferHEModel>? offerHEsToDelete)
        {
            if (offerHEsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            //Check records belong to this student - extra security step
            foreach (var offerHEToDelete in offerHEsToDelete)
            {
                OfferHEModel? recordToDelete = _context.OfferHE!
                    .FirstOrDefault(c => c.OfferHEID == offerHEToDelete.OfferHEID);
                if (_context.OfferHE == null)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                else if (recordToDelete?.StudentDetailID != studentDetailID)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
            }

            _context.OfferHE!.RemoveRange(offerHEsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteAll(int studentDetailID)
        {
            var recordsToDelete = GetByStudentDetailID(studentDetailID);
            if (recordsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.OfferHE!.RemoveRange(recordsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }
    }
}
