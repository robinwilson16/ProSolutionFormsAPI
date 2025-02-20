using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class MedicalLearningSupportAndTripConsentService
    {
        private readonly ApplicationDbContext _context;


        public List<MedicalLearningSupportAndTripConsentModel>? MedicalLearningSupportAndTripConsents { get; }

        public MedicalLearningSupportAndTripConsentService(ApplicationDbContext context)
        {
            _context = context;

            MedicalLearningSupportAndTripConsents = _context.MedicalLearningSupportAndTripConsent!
                .Include(m => m.EmergencyContacts)
                .Include(m => m.LearningDifficultiesDisabilities)
                .Include(m => m.MedicalConditions)
                .ToList();
        }

        public List<MedicalLearningSupportAndTripConsentModel>? GetAll() => MedicalLearningSupportAndTripConsents;

        public MedicalLearningSupportAndTripConsentModel? Get(int medicalLearningSupportAndTripConsentID) => MedicalLearningSupportAndTripConsents?.FirstOrDefault(m => m.MedicalLearningSupportAndTripConsentID == medicalLearningSupportAndTripConsentID);

        public MedicalLearningSupportAndTripConsentModel? GetByGUID(string academicYear, Guid studentGUID) => MedicalLearningSupportAndTripConsents?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentGUID == studentGUID)
            .FirstOrDefault();

        public MedicalLearningSupportAndTripConsentModel? GetByGUIDAndID(Guid studentGUID, int medicalLearningSupportAndTripConsentID) => MedicalLearningSupportAndTripConsents?
            .Where(c => c.StudentGUID == studentGUID)
            .Where(c => c.MedicalLearningSupportAndTripConsentID == medicalLearningSupportAndTripConsentID)
            .FirstOrDefault();

        public MedicalLearningSupportAndTripConsentModel? GetByStudentRef(string academicYear, string studentRef) => MedicalLearningSupportAndTripConsents?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentRef == studentRef)
            .FirstOrDefault();

        public MedicalLearningSupportAndTripConsentModel? GetByStudentDetailID(int studentDetailID) => MedicalLearningSupportAndTripConsents?
            .Where(c => c.StudentDetailID == studentDetailID)
            .FirstOrDefault();

        public async Task<ModelResultModel> Add(MedicalLearningSupportAndTripConsentModel newMedicalLearningSupportAndTripConsent)
        {
            _context.MedicalLearningSupportAndTripConsent?.Add(newMedicalLearningSupportAndTripConsent);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> AddMany(List<MedicalLearningSupportAndTripConsentModel> newMedicalLearningSupportAndTripConsents)
        {
            await _context.MedicalLearningSupportAndTripConsent?.AddRangeAsync(newMedicalLearningSupportAndTripConsents)!;
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Update(MedicalLearningSupportAndTripConsentModel? updatedMedicalLearningSupportAndTripConsent, bool? save)
        {
            //Include any related entities
            MedicalLearningSupportAndTripConsentModel? recordToUpdate = _context.MedicalLearningSupportAndTripConsent!
                .FirstOrDefault(m => m.MedicalLearningSupportAndTripConsentID == updatedMedicalLearningSupportAndTripConsent!.MedicalLearningSupportAndTripConsentID);

            if (recordToUpdate == null)
                return new ModelResultModel() { IsSuccessful = false };

            //Update IDs on related entities
            //Need to get full related entity as only the ID is set in the updated record so causes the rest of the fields to be wiped out
            //None

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(updatedMedicalLearningSupportAndTripConsent!);

            //Update content of related entities
            //None

            //Ensures related entities are included in the save operation
            _context?.Update(recordToUpdate);

            if (save != false)
                await _context!.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> UpdateMany(int studentDetailID, List<MedicalLearningSupportAndTripConsentModel>? updatedMedicalLearningSupportAndTripConsents)
        {
            if (updatedMedicalLearningSupportAndTripConsents is null)
                return new ModelResultModel() { IsSuccessful = false };

            foreach (var updatedMedicalLearningSupportAndTripConsent in updatedMedicalLearningSupportAndTripConsents)
            {
                await Update(updatedMedicalLearningSupportAndTripConsent, false);
            }

            //Save all changes at the end to avoid multiple save operations
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Delete(int medicalLearningSupportAndTripConsentID)
        {
            var recordToDelete = Get(medicalLearningSupportAndTripConsentID);
            if (recordToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.MedicalLearningSupportAndTripConsent!.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteMany(int studentDetailID, List<MedicalLearningSupportAndTripConsentModel>? medicalLearningSupportAndTripConsentsToDelete)
        {
            if (medicalLearningSupportAndTripConsentsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            //Check records belong to this student - extra security step
            foreach (var medicalLearningSupportAndTripConsentToDelete in medicalLearningSupportAndTripConsentsToDelete)
            {
                MedicalLearningSupportAndTripConsentModel? recordToDelete = _context.MedicalLearningSupportAndTripConsent!
                    .FirstOrDefault(c => c.MedicalLearningSupportAndTripConsentID == medicalLearningSupportAndTripConsentToDelete.MedicalLearningSupportAndTripConsentID);
                if (_context.MedicalLearningSupportAndTripConsent == null)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                else if (recordToDelete?.StudentDetailID != studentDetailID)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
            }

            _context.MedicalLearningSupportAndTripConsent!.RemoveRange(medicalLearningSupportAndTripConsentsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteAll(int studentDetailID)
        {
            var recordsToDelete = GetByStudentDetailID(studentDetailID);
            if (recordsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.MedicalLearningSupportAndTripConsent!.RemoveRange(recordsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }
    }
}
