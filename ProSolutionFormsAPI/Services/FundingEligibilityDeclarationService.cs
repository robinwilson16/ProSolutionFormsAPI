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

        public async Task<ModelResultModel> Add(FundingEligibilityDeclarationModel newFundingEligibilityDeclaration)
        {
            _context.FundingEligibilityDeclaration?.Add(newFundingEligibilityDeclaration);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> AddMany(List<FundingEligibilityDeclarationModel> newFundingEligibilityDeclarations)
        {
            await _context.FundingEligibilityDeclaration?.AddRangeAsync(newFundingEligibilityDeclarations)!;
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> Update(FundingEligibilityDeclarationModel? changedFundingEligibilityDeclaration)
        {
            FundingEligibilityDeclarationModel? recordToUpdate = _context.FundingEligibilityDeclaration!
                .FirstOrDefault(m => m.FundingEligibilityDeclarationID == changedFundingEligibilityDeclaration!.FundingEligibilityDeclarationID);

            if (_context.FundingEligibilityDeclaration == null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(changedFundingEligibilityDeclaration!);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> UpdateMany(int studentDetailID, List<FundingEligibilityDeclarationModel>? changedFundingEligibilityDeclarations)
        {
            if (changedFundingEligibilityDeclarations is null)
                return new ModelResultModel() { IsSuccessful = false };

            foreach (var changedFundingEligibilityDeclaration in changedFundingEligibilityDeclarations)
            {
                FundingEligibilityDeclarationModel? recordToUpdate = _context.FundingEligibilityDeclaration!
                    .FirstOrDefault(c => c.FundingEligibilityDeclarationID == changedFundingEligibilityDeclaration.FundingEligibilityDeclarationID);
                if (_context.FundingEligibilityDeclaration == null)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                else if (recordToUpdate?.StudentDetailID != studentDetailID)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                _context.Entry(recordToUpdate!).CurrentValues.SetValues(changedFundingEligibilityDeclaration);

                return new ModelResultModel() { IsSuccessful = true };
            }

            await _context.SaveChangesAsync();
        }

        public async Task<ModelResultModel> Delete(int fundingEligibilityDeclarationID)
        {
            var recordToDelete = Get(fundingEligibilityDeclarationID);
            if (recordToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.FundingEligibilityDeclaration!.Remove(recordToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteMany(int studentDetailID, List<FundingEligibilityDeclarationModel>? fundingEligibilityDeclarationsToDelete)
        {
            if (fundingEligibilityDeclarationsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            //Check records belong to this student - extra security step
            foreach (var fundingEligibilityDeclarationToDelete in fundingEligibilityDeclarationsToDelete)
            {
                FundingEligibilityDeclarationModel? recordToDelete = _context.FundingEligibilityDeclaration!
                    .FirstOrDefault(c => c.FundingEligibilityDeclarationID == fundingEligibilityDeclarationToDelete.FundingEligibilityDeclarationID);
                if (_context.FundingEligibilityDeclaration == null)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
                else if (recordToDelete?.StudentDetailID != studentDetailID)
                {
                    return new ModelResultModel() { IsSuccessful = false };
                }
            }

            _context.FundingEligibilityDeclaration!.RemoveRange(fundingEligibilityDeclarationsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> DeleteAll(int studentDetailID)
        {
            var recordsToDelete = GetByStudentDetailID(studentDetailID);
            if (recordsToDelete is null)
                return new ModelResultModel() { IsSuccessful = false };

            _context.FundingEligibilityDeclaration!.RemoveRange(recordsToDelete);
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }
    }
}
