using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class InterviewHEService
    {
        private readonly ApplicationDbContext _context;


        public List<InterviewHEModel>? InterviewHEs { get; }

        public InterviewHEService(ApplicationDbContext context)
        {
            _context = context;

            InterviewHEs = _context.InterviewHE!
                .ToList();
        }

        public List<InterviewHEModel>? GetAll() => InterviewHEs;

        public InterviewHEModel? Get(int interviewHEID) => InterviewHEs?.FirstOrDefault(c => c.InterviewHEID == interviewHEID);

        public List<InterviewHEModel>? GetByGUID(string academicYear, Guid studentGUID) => InterviewHEs?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentGUID == studentGUID)
            .ToList();

        public InterviewHEModel? GetByGUIDAndID(Guid studentGUID, int interviewHEID) => InterviewHEs?
            .Where(c => c.StudentGUID == studentGUID)
            .Where(c => c.InterviewHEID == interviewHEID)
            .FirstOrDefault();

        public InterviewHEModel? GetByStudentRef(string academicYear, string studentRef) => InterviewHEs?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentRef == studentRef)
            .FirstOrDefault();

        public InterviewHEModel? GetByStudentDetailID(int studentDetailID) => InterviewHEs?
            .Where(c => c.StudentDetailID == studentDetailID)
            .FirstOrDefault();

        public async Task<ModelResultModel> Add(InterviewHEModel newInterviewHE)
        {
            _context.InterviewHE?.Add(newInterviewHE);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> AddMany(List<InterviewHEModel> newInterviewHEs)
        {
            await _context.InterviewHE?.AddRangeAsync(newInterviewHEs)!;
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Update(InterviewHEModel? updatedInterviewHE, bool? save)
        {
            //Include any related entities
            InterviewHEModel? recordToUpdate = _context.InterviewHE!
                .FirstOrDefault(m => m.InterviewHEID == updatedInterviewHE!.InterviewHEID);

            if (recordToUpdate == null)
                return new ModelResultModel() { IsSuccessful = false };

            //Update IDs on related entities
            //Need to get full related entity as only the ID is set in the updated record so causes the rest of the fields to be wiped out
            //None

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(updatedInterviewHE!);

            //Update content of related entities
            //None

            //Ensures related entities are included in the save operation
            _context?.Update(recordToUpdate);

            if (save != false)
                await _context!.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> UpdateMany(int studentDetailID, List<InterviewHEModel>? updatedInterviewHEs)
        {
            if (updatedInterviewHEs is null)
                return new ModelResultModel() { IsSuccessful = false };

            foreach (var updatedInterviewHE in updatedInterviewHEs)
            {
                await Update(updatedInterviewHE, false);
            }

            //Save all changes at the end to avoid multiple save operations
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Delete(int interviewHEID)
        {
            var recordToDelete = Get(interviewHEID);
            if (recordToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.InterviewHE!.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteMany(int studentDetailID, List<InterviewHEModel>? interviewHEsToDelete)
        {
            if (interviewHEsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            //Check records belong to this student - extra security step
            foreach (var interviewHEToDelete in interviewHEsToDelete)
            {
                InterviewHEModel? recordToDelete = _context.InterviewHE!
                    .FirstOrDefault(c => c.InterviewHEID == interviewHEToDelete.InterviewHEID);
                if (_context.InterviewHE == null)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                else if (recordToDelete?.StudentDetailID != studentDetailID)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
            }

            _context.InterviewHE!.RemoveRange(interviewHEsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteAll(int studentDetailID)
        {
            var recordsToDelete = GetByStudentDetailID(studentDetailID);
            if (recordsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.InterviewHE!.RemoveRange(recordsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }
    }
}
