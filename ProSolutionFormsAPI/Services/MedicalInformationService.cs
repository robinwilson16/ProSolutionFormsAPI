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

        public async Task Add(MedicalInformationModel studentDetailID)
        {
            _context.MedicalInformation?.Add(studentDetailID);
            await _context.SaveChangesAsync();
        }

        public async Task AddMany(List<MedicalInformationModel> studentDetailID)
        {
            await _context.MedicalInformation?.AddRangeAsync(studentDetailID)!;
            await _context.SaveChangesAsync();
        }

        public async Task Update(MedicalInformationModel? medicalInformation)
        {
            MedicalInformationModel? recordToUpdate = _context.MedicalInformation!
                .FirstOrDefault(m => m.MedicalInformationID == medicalInformation!.MedicalInformationID);

            if (_context.MedicalInformation == null)
            {
                return;
            }

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(medicalInformation!);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMany(int studentDetailID, List<MedicalInformationModel>? medicalInformations)
        {
            if (medicalInformations is null)
                return;

            foreach (var medicalInformation in medicalInformations)
            {
                MedicalInformationModel? recordToUpdate = _context.MedicalInformation!
                    .FirstOrDefault(c => c.MedicalInformationID == medicalInformation.MedicalInformationID);
                if (_context.MedicalInformation == null)
                {
                    return;
                }
                else if (recordToUpdate?.StudentDetailID != studentDetailID)
                {
                    return;
                }
                _context.Entry(recordToUpdate!).CurrentValues.SetValues(medicalInformation);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int medicalInformationID)
        {
            var recordToDelete = Get(medicalInformationID);
            if (recordToDelete is null)
                return;

            _context.MedicalInformation!.Remove(recordToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(int studentDetailID, List<MedicalInformationModel>? medicalInformations)
        {
            if (medicalInformations is null)
                return;

            //Check records belong to this student - extra security step
            foreach (var medicalInformation in medicalInformations)
            {
                MedicalInformationModel? recordToDelete = _context.MedicalInformation!
                    .FirstOrDefault(c => c.MedicalInformationID == medicalInformation.MedicalInformationID);
                if (_context.MedicalInformation == null)
                {
                    return;
                }
                else if (recordToDelete?.StudentDetailID != studentDetailID)
                {
                    return;
                }
            }

            _context.MedicalInformation!.RemoveRange(medicalInformations);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAll(int studentDetailID)
        {
            var recordsToDelete = GetByStudentDetailID(studentDetailID);
            if (recordsToDelete is null)
                return;

            _context.MedicalInformation!.RemoveRange(recordsToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
