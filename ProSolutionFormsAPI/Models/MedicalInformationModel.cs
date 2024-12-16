using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProSolutionFormsAPI.Models
{
    public class MedicalInformationModel
    {
        [Key]
        public int MedicalInformationID { get; set; }
        public ICollection<MedicalInformationEmergencyContactModel>? EmergencyContacts { get; set; }
        public bool? HasMedicalCondition { get; set; }
        public ICollection<MedicalInformationMedicalConditionModel>? MedicalConditions { get; set; }
        public bool? HasDifficultyDisability { get; set; }
        public ICollection<MedicalInformationDifficultyDisabilityModel>? DifficultiesDisabilities { get; set; }
        public bool? RequiresRiskAssesment { get; set; }
        public bool? HasBeenHospitalisedInLastYear { get; set; }
        public string? HospitalisationNotes { get; set; }
        public bool? RequiresLearningSupport { get; set; }
        public bool? HasEHCP { get; set; }
        public bool? IsLAC { get; set; }
        public bool? IsCareLeaver { get; set; }
        public bool? HasFSM { get; set; }
        public bool? IsFromMilitaryServiceFamily { get; set; }
        public bool? HasAccessArrangements { get; set; }
        public string? AccessRequirementDetails { get; set; }
        public string? SupportInPlaceAtPriorSchoolOrCollege { get; set; }
        public bool? CanContactPriorSchoolOrCollege { get; set; }
        public bool? HasCriminalConvictions { get; set; }
        public string? CriminalConvictionDetails { get; set; }
        public bool? CanShareInformationWithPotentialEmployers { get; set; }
        public bool? AgreeInfoIsCorrect { get; set; }
        public string? SignedStudent { get; set; }
        public DateTime? SignedStudentDate { get; set; }
        public string? SignedParentCarer { get; set; }
        public DateTime? SignedParentCarerDate { get; set; }
        public bool? HasGivenTripConsentStudent { get; set; }
        public bool? HasGivenTripConsentParentCarer { get; set; }
        public bool? HasGivenPhotographicImagesConsent { get; set; }
        
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

    public class MedicalInformationValidator : AbstractValidator<MedicalInformationModel>
    {
        public MedicalInformationValidator()
        {
            RuleFor(m => m.EmergencyContacts).ForEach(x => x.SetValidator(new MedicalInformationEmergencyContactValidator()));
            RuleFor(m => m.RequiresRiskAssesment).NotNull().WithMessage("Please state whether you require a risk assessment");
            RuleFor(m => m.HasBeenHospitalisedInLastYear).NotNull().WithMessage("Please state whether you have been hospitalised in the last year");
            RuleFor(m => m.RequiresLearningSupport).NotNull().WithMessage("Please state whether you require learning support");
            RuleFor(m => m.HasEHCP).NotNull().WithMessage("Please state whether you have an Educational Health Care Plan");
            RuleFor(m => m.IsLAC).NotNull().WithMessage("Please state whether you are a looked after child");
            RuleFor(m => m.IsCareLeaver).NotNull().WithMessage("Please state whether you are a care leaver");
            RuleFor(m => m.HasFSM).NotNull().WithMessage("Please state whether you recieve free school meals");
            RuleFor(m => m.IsFromMilitaryServiceFamily).NotNull().WithMessage("Please state whether you are from a military service family");
            RuleFor(m => m.HasCriminalConvictions).NotNull().WithMessage("Please state whether you have any criminal convictions");
            RuleFor(m => m.CanShareInformationWithPotentialEmployers).NotNull().WithMessage("Please state whether we may share your information with potential employers");
            RuleFor(m => m.AgreeInfoIsCorrect).NotNull().WithMessage("Please state whether you agree the information above is correct");
            RuleFor(m => m.HasGivenTripConsentStudent)
                .NotNull()
                .When(m => m.HasGivenTripConsentParentCarer != null)
                .WithMessage("Please confirm whether you provide your consent for trips and visits either as a student or parent/carer");
            RuleFor(m => m.HasGivenTripConsentParentCarer)
                .NotNull()
                .When(m => m.HasGivenTripConsentStudent != null)
                .WithMessage("Please confirm whether you provide your consent for trips and visits either as a student or parent/carer");
            RuleFor(m => m.HasGivenPhotographicImagesConsent).NotNull().WithMessage("Please state whether you provide consent for the use of any photographic images");
        }
    }
}
