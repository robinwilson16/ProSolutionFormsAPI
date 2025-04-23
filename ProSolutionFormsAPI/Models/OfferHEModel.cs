using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ProSolutionFormsAPI.Models
{
    public class OfferHEModel
    {
        [Key]
        public int OfferHEID { get; set; }

        [Column(TypeName = "decimal(19,4)")]
        [DataType(DataType.Currency)]
        public decimal? TuitionFee { get; set; }
        public MethodOfFunding? MethodOfFundingID { get; set; }
        public string? EmployerName { get; set; }
        public string? EmployerAddress1 { get; set; }
        public string? EmployerAddress2 { get; set; }
        public string? EmployerAddress3 { get; set; }
        public string? EmployerPostCode { get; set; }
        public string? EmployerTel { get; set; }
        public string? EmployerEmail { get; set; }
        public int? UCASNumber { get; set; }
        public string? Occupation { get; set; }
        public TermTimeAccomodation? TermTimeAccomodationID { get; set; }
        public string? TermTimeAccomodationOtherDetail { get; set; }
        public HighestQualOnEntryLevel? HighestQualOnEntryLevelID { get; set; }
        public LastEducationalEstablishmentAttendedOffer? LastEducationalEstablishmentAttendedOfferID { get; set; }
        public ICollection<OfferHEAttachmentModel>? Attachments { get; set; }
        public bool? ConfirmInformationAndAttachmentsAreAccurate { get; set; }
        public bool? HaveReadHEOfferTermsAndConditions { get; set; }
        public bool? UnderstandTermsAndConditionsBasedOnFundingMethodSpecified { get; set; }

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
        public int? OfferingID { get; set; }
        public string? CourseCode { get; set; }
        public int? ApplicationID { get; set; }
        public int? ApplicationCourseID { get; set; }
    }

    public enum TermTimeAccomodation
    {
        [Display(Name = "Own Residence")]
        OwnResidence = 1,
        [Display(Name = "Parental or Guardian Home")]
        ParentalResidence = 2,
        [Display(Name = "Other Rented Accommodation")]
        RentedAccomodation = 3,
        [Display(Name = "Other (Please State)")]
        Other = 99
    }

    public enum LastEducationalEstablishmentAttendedOffer
    {
        [Display(Name = "UK State School")]
        StateSchool = 1,
        [Display(Name = "UK Independent School")]
        IndependentSchool = 2,
        [Display(Name = "UK Further Education College")]
        College = 3,
        [Display(Name = "UK Higher Education Institution")]
        University = 4,
        [Display(Name = "Any Non-UK Institution")]
        NonUKInstitution = 5
    }

    public class OfferHEValidator : AbstractValidator<OfferHEModel>
    {
        public OfferHEValidator()
        {
            RuleFor(o => o.MethodOfFundingID).NotNull().WithMessage("Please confirm the Method of Funding");
            When(o => o.MethodOfFundingID == MethodOfFunding.Employer, () =>
            {
                RuleFor(o => o.EmployerName).NotNull().WithMessage("When selecting Employer as the Method of Funding, please enter the Employer Name");
                RuleFor(o => o.EmployerAddress1).NotNull().WithMessage("When selecting Employer as the Method of Funding, please enter the Employer Address 1");
                RuleFor(o => o.EmployerPostCode).NotNull().WithMessage("When selecting Employer as the Method of Funding, please enter the Employer Post Code");
                RuleFor(o => o.EmployerTel).NotNull().WithMessage("When selecting Employer as the Method of Funding, please enter the Employer Telephone Number");
                RuleFor(o => o.EmployerEmail).NotNull().WithMessage("When selecting Employer as the Method of Funding, please enter the Employer Email Address")
                    .EmailAddress().WithMessage("The Employer Email Address is not valid");
            });
            When(o => o.UCASNumber != null, () =>
            {
                RuleFor(o => o.UCASNumber).Must(w => w?.ToString().Length == 10).WithMessage("Please enter a valid UCAS Number which should be 10 digits");
            });
            RuleFor(o => o.TermTimeAccomodationID).NotNull().WithMessage("Please confirm the Term Time Accomodation");
            RuleFor(o => o.HighestQualOnEntryLevelID).NotNull().WithMessage("Please confirm the Highest Level of Qualification Previously Attained");
            RuleFor(o => o.LastEducationalEstablishmentAttendedOfferID).NotNull().WithMessage("Please confirm the type of Educational Establishment you last attended");
            RuleFor(o => o.Attachments).ForEach(x => x.SetValidator(new OfferHEAttachmentValidator()));
            RuleFor(o => o.ConfirmInformationAndAttachmentsAreAccurate).NotNull().WithMessage("Please confirm the information provided on this form is correct and that any attached images are of genuine documents");
            RuleFor(o => o.HaveReadHEOfferTermsAndConditions).NotNull().WithMessage("Please confirm you have read the terms and conditions from the SHCG website");
            RuleFor(o => o.UnderstandTermsAndConditionsBasedOnFundingMethodSpecified).NotNull().WithMessage("Please confirm you understand the terms and conditions based on the funding model you specified above");
        }
    }
}
