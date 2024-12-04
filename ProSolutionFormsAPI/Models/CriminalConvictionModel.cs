using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ProSolutionFormsAPI.Models
{
    public class CriminalConvictionModel
    {
        [Key]
        public int CriminalConvictionID { get; set; }
        public DateTime? DateOfOffence { get; set; }

        [Required(ErrorMessage = "Please record details of the offence")]
        public string? Offence { get; set; }
        public string? Penalty { get; set; }
        public string? Comments { get; set; }
        public string? ContactName { get; set; }

        //Created and Updated
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        //Linking Data
        public int? StudentDetailID { get; set; }

        [MaxLength(5)]
        public string? AcademicYearID { get; set; }

        [MaxLength(12)]
        public string? StudentRef { get; set; }
    }

    public class CriminalConvictionValidator : AbstractValidator<CriminalConvictionModel>
    {
        public CriminalConvictionValidator()
        {
            RuleFor(c => c.DateOfOffence).NotNull().WithMessage("You must provide the date of the offence");
            RuleFor(c => c.DateOfOffence).LessThanOrEqualTo(DateTime.Today).WithMessage("The date of the offence must not be in the future");
            RuleFor(c => c.Offence).NotEmpty().WithMessage("You must provide details of the offence");
        }
    }
}
