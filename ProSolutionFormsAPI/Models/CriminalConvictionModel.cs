using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ProSolutionFormsAPI.Models
{
    public class CriminalConvictionModel
    {
        [Key]
        public int CriminalConvictionID { get; set; }
        public ICollection<CriminalConvictionOffenceModel>? Offences { get; set; }
        public bool? NoOffencesToDeclare { get; set; }
        public bool? AgreeInfoIsCorrectStudent { get; set; }
        public string? SignedStudent { get; set; }
        public DateTime? SignedStudentDate { get; set; }
        
        //Created and Updated
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        //Linking Data
        public int? StudentDetailID { get; set; }

        [MaxLength(5)]
        public string? AcademicYearID { get; set; }

        [MaxLength(12)]
        public string? StudentRef { get; set; }
        public Guid? StudentGUID { get; set; }
        public string? CourseCode { get; set; }
    }

    public class CriminalConvictionsValidator : AbstractValidator<CriminalConvictionModel>
    {
        public CriminalConvictionsValidator()
        {
            When(m => m.NoOffencesToDeclare == true, () =>
            {
                RuleFor(m => m.Offences)
                .NotNull()
                .ForEach(x => x.SetValidator(new CriminalConvictionOffenceBlankValidator()));
            }).Otherwise(() =>
            {
                RuleFor(m => m.Offences)
                .NotNull()
                .ForEach(x => x.SetValidator(new CriminalConvictionOffenceValidator()));
            });
            RuleFor(m => m.AgreeInfoIsCorrectStudent).NotNull().WithMessage("Please state whether you agree the information above is correct");
            RuleFor(m => m.SignedStudent).NotNull().WithMessage("Please type your name in the box to confirm the information entered is correct");
            RuleFor(m => m.SignedStudentDate).NotNull().WithMessage("Please enter the date you are confirming the information to be correct");
        }
    }
}
