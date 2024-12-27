using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class MedicalInformationService
    {
        private readonly ApplicationDbContext _context;


        public List<MedicalInformationModel>? MedicalInformations { get; }

        public MedicalInformationService(ApplicationDbContext context)
        {
            _context = context;

            MedicalInformations = _context.MedicalInformation!
                .ToList();
        }

        public List<MedicalInformationModel>? GetAll() => MedicalInformations;

        public MedicalInformationModel? Get(int medicalInformationID) => MedicalInformations?.FirstOrDefault(m => m.MedicalInformationID == medicalInformationID);

        public List<MedicalInformationModel>? GetByStudentRef(string academicYear, string studentRef) => MedicalInformations?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentRef == studentRef)
            .ToList();

        public List<MedicalInformationModel>? GetByStudentDetailID(int studentDetailID) => MedicalInformations?
            .Where(c => c.StudentDetailID == studentDetailID)
            .ToList();

        public async Task<ModelResultModel> Add(MedicalInformationModel newMedicalInformation)
        {
            _context.MedicalInformation?.Add(newMedicalInformation);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> AddMany(List<MedicalInformationModel> newMedicalInformations)
        {
            await _context.MedicalInformation?.AddRangeAsync(newMedicalInformations)!;
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Update(MedicalInformationModel? changedMedicalInformation)
        {
            MedicalInformationModel? recordToUpdate = _context.MedicalInformation!
                .FirstOrDefault(m => m.MedicalInformationID == changedMedicalInformation!.MedicalInformationID);

            if (_context.MedicalInformation == null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(changedMedicalInformation!);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> UpdateMany(int studentDetailID, List<MedicalInformationModel>? changedMedicalInformations)
        {
            if (changedMedicalInformations is null)
                return new ModelResultModel() { IsSuccessful = false };

            foreach (var changedMedicalInformation in changedMedicalInformations)
            {
                MedicalInformationModel? recordToUpdate = _context.MedicalInformation!
                    .FirstOrDefault(c => c.MedicalInformationID == changedMedicalInformation.MedicalInformationID);
                if (_context.MedicalInformation == null)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                else if (recordToUpdate?.StudentDetailID != studentDetailID)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                _context.Entry(recordToUpdate!).CurrentValues.SetValues(changedMedicalInformation);
            }

            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Delete(int medicalInformationID)
        {
            var recordToDelete = Get(medicalInformationID);
            if (recordToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.MedicalInformation!.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteMany(int studentDetailID, List<MedicalInformationModel>? medicalInformationsToDelete)
        {
            if (medicalInformationsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            //Check records belong to this student - extra security step
            foreach (var medicalInformationToDelete in medicalInformationsToDelete)
            {
                MedicalInformationModel? recordToDelete = _context.MedicalInformation!
                    .FirstOrDefault(c => c.MedicalInformationID == medicalInformationToDelete.MedicalInformationID);
                if (_context.MedicalInformation == null)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                else if (recordToDelete?.StudentDetailID != studentDetailID)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
            }

            _context.MedicalInformation!.RemoveRange(medicalInformationsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteAll(int studentDetailID)
        {
            var recordsToDelete = GetByStudentDetailID(studentDetailID);
            if (recordsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.MedicalInformation!.RemoveRange(recordsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }
    }
}
