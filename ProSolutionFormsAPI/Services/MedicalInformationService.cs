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
            MedicalInformationModel? medicalInformationDB = _context.MedicalInformation!
                .FirstOrDefault(m => m.MedicalInformationID == medicalInformation!.MedicalInformationID);

            if (_context.MedicalInformation == null)
            {
                return;
            }

            _context.Entry(medicalInformationDB!).CurrentValues.SetValues(medicalInformation!);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int medicalInformationID)
        {
            var medicalInformation = Get(medicalInformationID);
            if (medicalInformation is null)
                return;

            _context.MedicalInformation!.Remove(medicalInformation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteForStudent(int studentDetailID)
        {
            var medicalInformation = GetByStudentDetailID(studentDetailID);
            if (medicalInformation is null)
                return;

            _context.MedicalInformation!.RemoveRange(medicalInformation);
            await _context.SaveChangesAsync();
        }
    }
}
