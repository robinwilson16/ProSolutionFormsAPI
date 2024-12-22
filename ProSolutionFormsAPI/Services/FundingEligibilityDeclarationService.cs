using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class FundingEligibilityDeclarationService
    {
        private readonly ApplicationDbContext _context;


        public List<FundingEligibilityDeclarationModel>? FundingEligibilityDeclarations { get; }

        public FundingEligibilityDeclarationService(ApplicationDbContext context)
        {
            _context = context;

            FundingEligibilityDeclarations = _context.FundingEligibilityDeclaration!
                .ToList();
        }

        public List<FundingEligibilityDeclarationModel>? GetAll() => FundingEligibilityDeclarations;

        public FundingEligibilityDeclarationModel? Get(int fundingEligibilityDeclarationID) => FundingEligibilityDeclarations?.FirstOrDefault(m => m.FundingEligibilityDeclarationID == fundingEligibilityDeclarationID);

        public List<FundingEligibilityDeclarationModel>? GetByStudentRef(string academicYear, string studentRef) => FundingEligibilityDeclarations?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentRef == studentRef)
            .ToList();

        public List<FundingEligibilityDeclarationModel>? GetByStudentDetailID(int studentDetailID) => FundingEligibilityDeclarations?
            .Where(c => c.StudentDetailID == studentDetailID)
            .ToList();

        public async Task Add(FundingEligibilityDeclarationModel studentDetailID)
        {
            _context.FundingEligibilityDeclaration?.Add(studentDetailID);
            await _context.SaveChangesAsync();
        }

        public async Task AddMany(List<FundingEligibilityDeclarationModel> studentDetailID)
        {
            await _context.FundingEligibilityDeclaration?.AddRangeAsync(studentDetailID)!;
            await _context.SaveChangesAsync();
        }

        public async Task Update(FundingEligibilityDeclarationModel? fundingEligibilityDeclaration)
        {
            FundingEligibilityDeclarationModel? recordToUpdate = _context.FundingEligibilityDeclaration!
                .FirstOrDefault(m => m.FundingEligibilityDeclarationID == fundingEligibilityDeclaration!.FundingEligibilityDeclarationID);

            if (_context.FundingEligibilityDeclaration == null)
            {
                return;
            }

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(fundingEligibilityDeclaration!);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMany(int studentDetailID, List<FundingEligibilityDeclarationModel>? fundingEligibilityDeclarations)
        {
            if (fundingEligibilityDeclarations is null)
                return;

            foreach (var fundingEligibilityDeclaration in fundingEligibilityDeclarations)
            {
                FundingEligibilityDeclarationModel? recordToUpdate = _context.FundingEligibilityDeclaration!
                    .FirstOrDefault(c => c.FundingEligibilityDeclarationID == fundingEligibilityDeclaration.FundingEligibilityDeclarationID);
                if (_context.FundingEligibilityDeclaration == null)
                {
                    return;
                }
                else if (recordToUpdate?.StudentDetailID != studentDetailID)
                {
                    return;
                }
                _context.Entry(recordToUpdate!).CurrentValues.SetValues(fundingEligibilityDeclaration);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int fundingEligibilityDeclarationID)
        {
            var recordToDelete = Get(fundingEligibilityDeclarationID);
            if (recordToDelete is null)
                return;

            _context.FundingEligibilityDeclaration!.Remove(recordToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(int studentDetailID, List<FundingEligibilityDeclarationModel>? fundingEligibilityDeclarations)
        {
            if (fundingEligibilityDeclarations is null)
                return;

            //Check records belong to this student - extra security step
            foreach (var fundingEligibilityDeclaration in fundingEligibilityDeclarations)
            {
                FundingEligibilityDeclarationModel? recordToDelete = _context.FundingEligibilityDeclaration!
                    .FirstOrDefault(c => c.FundingEligibilityDeclarationID == fundingEligibilityDeclaration.FundingEligibilityDeclarationID);
                if (_context.FundingEligibilityDeclaration == null)
                {
                    return;
                }
                else if (recordToDelete?.StudentDetailID != studentDetailID)
                {
                    return;
                }
            }

            _context.FundingEligibilityDeclaration!.RemoveRange(fundingEligibilityDeclarations);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAll(int studentDetailID)
        {
            var recordsToDelete = GetByStudentDetailID(studentDetailID);
            if (recordsToDelete is null)
                return;

            _context.FundingEligibilityDeclaration!.RemoveRange(recordsToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
