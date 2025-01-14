using FluentValidation;
using ProSolutionFormsAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ProSolutionFormsAPI.Models
{
    public class MedicalLearningSupportAndTripConsentEmergencyContactModel
    {
        [Key]
        public int MedicalLearningSupportAndTripConsentEmergencyContactID { get; set; }

        [JsonIgnore]
        public MedicalLearningSupportAndTripConsentModel? MedicalLearningSupportAndTripConsent { get; set; }
        public int? ContactOrder { get; set; }
        public string? Surname { get; set; }
        public string? Forename { get; set; }
        public string? Title { get; set; }
        public int? RelationshipToStudent { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Address4 { get; set; }

        [MaxLength(4)]
        public string? PostCodeOut { get; set; }

        [MaxLength(3)]
        public string? PostCodeIn { get; set; }

        public string? PostCode
        {
            get
            {
                return PostCodeOut + " " + PostCodeIn;
            }
        }
        public string? TelHome { get; set; }
        public string? TelMobile { get; set; }
        public string? TelWork { get; set; }
        public string? Email { get; set; }

        //Created and Updated
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }

    public class MedicalInformationEmergencyContactValidator : AbstractValidator<MedicalLearningSupportAndTripConsentEmergencyContactModel>
    {
        //Drop-down options
        public List<DropDownStringModel>? Titles = new List<DropDownStringModel>();
        public List<DropDownIntModel>? Relationships = new List<DropDownIntModel>();

        public MedicalInformationEmergencyContactValidator()
        {
            //Get lists of drop-down options to be checked
            //Titles = MedicalInformation.GetTitles();
            //Relationships = MedicalInformation.GetRelationships();

            RuleFor(e => e.Surname)
                .NotNull()
                .WithMessage("Please specify the contact surname");
            RuleFor(e => e.Forename)
                    .NotNull()
                    .WithMessage("Please specify the contact forename");
            RuleFor(e => e.Title)
                .Must(f => Titles.Any(t => t.Description == f))
                .WithMessage(e => $"The value you entered '{e.Title}' is not valid. Please enter or select a valid option from the list");
            RuleFor(e => e.RelationshipToStudent)
                .Must(f => Relationships.Any(t => t.Code == f))
                .WithMessage(e => $"The value you entered '{e.RelationshipToStudent}' is not valid. Please enter or select a valid option from the list");
            RuleFor(e => e.TelMobile)
                .NotNull()
                .When(e => e.TelWork == null)
                .When(e => e.TelHome == null)
                .WithMessage("Please specify at least one telephone number");
            RuleFor(e => e.TelHome)
                .NotNull()
                .When(e => e.TelMobile == null)
                .When(e => e.TelWork == null)
                .WithMessage("Please specify at least one telephone number");
            RuleFor(e => e.TelWork)
                .NotNull()
                .When(e => e.TelMobile == null)
                .When(e => e.TelHome == null)
                .WithMessage("Please specify at least one telephone number");
            RuleFor(e => e.Email)
                .NotNull()
                .WithMessage("Please specify the contact email address");
            RuleFor(e => e.TelMobile)
                .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
                .Matches(new Regex(@"([0-9 +])")).WithMessage("Phone number is not valid");
            RuleFor(e => e.TelHome)
                .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
                .Matches(new Regex(@"([0-9 +])")).WithMessage("Phone number is not valid");
            RuleFor(e => e.TelWork)
                .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
                .Matches(new Regex(@"([0-9 +])")).WithMessage("Phone number is not valid");
            RuleFor(e => e.Email)
                .EmailAddress()
                .WithMessage("Please specify a valid contact email address");
        }
    }
}
