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

        public FundingEligibilityDeclarationModel? GetByGUID(string academicYear, Guid studentGUID) => FundingEligibilityDeclarations?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentGUID == studentGUID)
            .FirstOrDefault();

        public FundingEligibilityDeclarationModel? GetByStudentRef(string academicYear, string studentRef) => FundingEligibilityDeclarations?
            .Where(c => c.AcademicYearID == academicYear)
            .Where(c => c.StudentRef == studentRef)
            .FirstOrDefault();

        public FundingEligibilityDeclarationModel? GetByStudentDetailID(int studentDetailID) => FundingEligibilityDeclarations?
            .Where(c => c.StudentDetailID == studentDetailID)
            .FirstOrDefault();

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

        public async Task<ModelResultModel> Update(FundingEligibilityDeclarationModel? updatedFundingEligibilityDeclaration, bool? save)
        {
            //Include any related entities
            FundingEligibilityDeclarationModel? recordToUpdate = _context.FundingEligibilityDeclaration!
                .FirstOrDefault(m => m.FundingEligibilityDeclarationID == updatedFundingEligibilityDeclaration!.FundingEligibilityDeclarationID);

            if (recordToUpdate == null)
                return new ModelResultModel() { IsSuccessful = false };

            //Update IDs on related entities
            //Need to get full related entity as only the ID is set in the updated record so causes the rest of the fields to be wiped out
            //None

            _context.Entry(recordToUpdate!).CurrentValues.SetValues(updatedFundingEligibilityDeclaration!);

            //Update content of related entities
            //None

            //Ensures related entities are included in the save operation
            _context?.Update(recordToUpdate);

            if (save != false)
                await _context!.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
        }

        public async Task<ModelResultModel> UpdateMany(int studentDetailID, List<FundingEligibilityDeclarationModel>? updatedFundingEligibilityDeclarations)
        {
            if (updatedFundingEligibilityDeclarations is null)
                return new ModelResultModel() { IsSuccessful = false };

            foreach (var updatedFundingEligibilityDeclaration in updatedFundingEligibilityDeclarations)
            {
                await Update(updatedFundingEligibilityDeclaration, false);
            }

            //Save all changes at the end to avoid multiple save operations
            await _context.SaveChangesAsync();

            return new ModelResultModel() { IsSuccessful = true };
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
