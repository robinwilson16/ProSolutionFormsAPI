using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProSolutionFormsAPI.Models
{
    public class CriminalConvictionOffenceModel
    {
        [Key]
        public int CriminalConvictionOffenceID { get; set; }
        public DateTime? DateOfOffence { get; set; }

        [Required(ErrorMessage = "Please record details of the offence")]
        public string? Offence { get; set; }
        public string? Penalty { get; set; }
        public string? Comments { get; set; }
        public string? ContactName { get; set; }
    }

    public class CriminalConvictionOffenceValidator : AbstractValidator<CriminalConvictionOffenceModel>
    {
        public CriminalConvictionOffenceValidator()
        {
            RuleFor(c => c.DateOfOffence).NotNull().WithMessage("You must provide the date of the offence");
            RuleFor(c => c.DateOfOffence).LessThanOrEqualTo(DateTime.Today).WithMessage("The date of the offence must not be in the future");
            RuleFor(c => c.Offence).NotEmpty().WithMessage("You must provide details of the offence");
        }
    }

    public class CriminalConvictionOffenceBlankValidator : AbstractValidator<CriminalConvictionOffenceModel>
    {
        public CriminalConvictionOffenceBlankValidator()
        {
            RuleFor(c => c.DateOfOffence).Null().WithMessage("As you have ticked to say you have no offences above, no details of an offence should be provided. If you do have an offence please untick the box");
            RuleFor(c => c.Offence).Empty().WithMessage("As you have ticked to say you have no offences above, no details of an offence should be provided. If you do have an offence please untick the box");
            RuleFor(c => c.Penalty).Empty().WithMessage("As you have ticked to say you have no offences above, no details of an offence should be provided. If you do have an offence please untick the box");
            RuleFor(c => c.Comments).Empty().WithMessage("As you have ticked to say you have no offences above, no details of an offence should be provided. If you do have an offence please untick the box");
            RuleFor(c => c.ContactName).Empty().WithMessage("As you have ticked to say you have no offences above, no details of an offence should be provided. If you do have an offence please untick the box");
        }
    }
}
