using FluentValidation;
using ProSolutionFormsAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ProSolutionFormsAPI.Models
{
    public class FundingEligibilityDeclarationModel
    {
        [Key]
        public int FundingEligibilityDeclarationID { get; set; }
        public int? FeeExemptionReasonID { get; set; }
        public string? FeeExemptionReasonOther { get; set; }
        public ICollection<FundingEligibilityDeclarationEvidenceModel>? FundingEligibilityDeclarationEvidence { get; set; }
        public string? SignedStudent { get; set; }
        public DateTime? SignedStudentDate { get; set; }

        //Created and Updated
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        //Linking Data
        public int? StudentDetailID { get; set; }
        public string? AcademicYearID { get; set; }
        public string? StudentRef { get; set; }
    }

    public class FundingEligibilityDeclarationValidator : AbstractValidator<FundingEligibilityDeclarationModel>
    {
        public FundingEligibilityDeclarationValidator()
        {
            RuleFor(m => m.FeeExemptionReasonID)
                .NotNull().WithMessage("Please confirm why you are exempt from paying your course fees")
                .When(m => m.FeeExemptionReasonID == 3 && m.FeeExemptionReasonOther == null)
                .WithMessage("Please confirm which other benefit you are receiving that means you are exempt from paying your course fees");
            RuleFor(f => f.FundingEligibilityDeclarationEvidence).ForEach(x => x.SetValidator(new FundingEligibilityDeclarationEvidenceValidator()));
            RuleFor(m => m.SignedStudent)
                .NotNull()
                .WithMessage("Please type your name in the box to confirm the information entered is correct");
            RuleFor(m => m.SignedStudentDate)
                .NotNull()
                .WithMessage("Please enter the date you are confirming the information to be correct");
        }
    }
}
