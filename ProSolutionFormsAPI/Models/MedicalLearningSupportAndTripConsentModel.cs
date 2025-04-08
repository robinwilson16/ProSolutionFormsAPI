using FluentValidation;
using ProSolutionFormsAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProSolutionFormsAPI.Models
{
    public class MedicalLearningSupportAndTripConsentModel
    {
        [Key]
        public int MedicalLearningSupportAndTripConsentID { get; set; }
        public bool? HasLearningDifficultyDisability { get; set; }
        public ICollection<MedicalLearningSupportAndTripConsentLearningDifficultyDisabilityModel>? LearningDifficultiesDisabilities { get; set; }
        public bool? AgreeToKeepCollegeInformed { get; set; }
        public bool? HasBeenHospitalisedInLastYear { get; set; }
        public string? HospitalisationNotes { get; set; }
        public bool? RequiresLearningSupport { get; set; }
        public bool? HasEHCP { get; set; }
        public string? NameOfDoctor { get; set; }
        public string? NameOfDoctorsPractice { get; set; }
        public ICollection<MedicalLearningSupportAndTripConsentEmergencyContactModel>? EmergencyContacts { get; set; }
        public bool? HasMedicalCondition { get; set; }
        public ICollection<MedicalLearningSupportAndTripConsentMedicalConditionModel>? MedicalConditions { get; set; }
        public bool? IsLAC { get; set; }
        public bool? IsCareLeaver { get; set; }
        public bool? IsYoungCarer { get; set; }
        public bool? HasFSM { get; set; }
        public bool? IsFromMilitaryServiceFamily { get; set; }
        public bool? HasAccessArrangements { get; set; }
        public bool? HadFurtherSupportAtSchoolOrCollege { get; set; }
        public string? FurtherSupportAtSchoolOrCollegeDetails { get; set; }
        public bool? HasGivenTripConsentStudent { get; set; }
        public bool? HasGivenTripConsentParentCarer { get; set; }
        public bool? HasGivenPhotographicImagesConsent { get; set; }
        public bool? CanContactPriorSchoolOrCollege { get; set; }
        public bool? CanContactStudent18PlusNOK { get; set; }
        public bool? HasCriminalConvictions { get; set; }
        public string? CriminalConvictionDetails { get; set; }
        public bool? CanShareInformationWithPotentialEmployers { get; set; }
        public bool? AgreeInfoIsCorrectParentCarer { get; set; }
        public string? SignedParentCarer { get; set; }
        public DateTime? SignedParentCarerDate { get; set; }
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

    public class MedicalInformationValidator : AbstractValidator<MedicalLearningSupportAndTripConsentModel>
    {
        public MedicalInformationValidator()
        {
            RuleFor(m => m.HasMedicalCondition).NotNull().WithMessage("Please state whether you have any medical conditions");
            When(m => m.MedicalConditions != null, () =>
            {
                RuleFor(m => m.MedicalConditions).ForEach(x => x.SetValidator(new MedicalInformationMedicalConditionValidator()));
            });
            RuleFor(m => m.AgreeToKeepCollegeInformed).NotNull().WithMessage("Please state whether you agree to keep the college informed of any changes in medical conditions or emergency contact details");
            RuleFor(m => m.HasBeenHospitalisedInLastYear).NotNull().WithMessage("Please state whether you have been hospitalised in the last year");
            RuleFor(m => m.RequiresLearningSupport).NotNull().WithMessage("Please state whether you require learning support");
            RuleFor(m => m.HasEHCP).NotNull().WithMessage("Please state whether you have an Educational Health Care Plan");
            RuleFor(m => m.EmergencyContacts).ForEach(x => x.SetValidator(new MedicalInformationEmergencyContactValidator()));
            RuleFor(m => m.HasLearningDifficultyDisability).NotNull().WithMessage("Please state whether you have any difficulties and/or disabilities");
            When(m => m.LearningDifficultiesDisabilities != null, () =>
            {
                RuleFor(m => m.LearningDifficultiesDisabilities)
                .ForEach(x => x.SetValidator(new MedicalInformationDifficultyDisabilityValidator()));
                RuleFor(m => m.LearningDifficultiesDisabilities)
               .Must(d => d?.Where(d => d.IsPrimary == true).Count() == 1)
               .WithMessage("Please ensure only one learning difficulty/disability is set as the primary");
            });
            RuleForEach(m => m.LearningDifficultiesDisabilities).SetValidator(x => new MedicalInformationDifficultyDisabilityIsPrimaryErrorValidator(x?.LearningDifficultiesDisabilities?.Where(d => d.IsPrimary == true)?.Count()));
            RuleFor(m => m.IsLAC).NotNull().WithMessage("Please state whether you are a looked after child");
            RuleFor(m => m.IsCareLeaver).NotNull().WithMessage("Please state whether you are a care leaver");
            RuleFor(m => m.IsYoungCarer).NotNull().WithMessage("Please state whether you are a young carer");
            RuleFor(m => m.HasFSM).NotNull().WithMessage("Please state whether you recieve free school meals");
            RuleFor(m => m.IsFromMilitaryServiceFamily).NotNull().WithMessage("Please state whether you are from a military service family");
            RuleFor(m => m.HasAccessArrangements).NotNull().WithMessage("Please state whether you have any access arrangements");
            RuleFor(m => m.HadFurtherSupportAtSchoolOrCollege).NotNull().WithMessage("Please state whether you had any further support at school/college");
            RuleFor(m => m.CanContactPriorSchoolOrCollege).NotNull().WithMessage("Please confirm if we may contact your school/college/other institution/employer for details of your learning difficulties/disabilities");
            RuleFor(m => m.CanContactStudent18PlusNOK).NotNull().WithMessage("Please confirm if we may contact your next of kin where you are aged over 18. If you are aged under 18 then please select Yes.");
            RuleFor(m => m.HasGivenTripConsentStudent)
                .NotNull()
                .When(m => m.HasGivenTripConsentParentCarer == null)
                .WithMessage("Please confirm whether you provide your consent for trips and visits either as a student or parent/carer");
            RuleFor(m => m.HasGivenTripConsentParentCarer)
                .NotNull()
                .When(m => m.HasGivenTripConsentStudent == null)
                .WithMessage("Please confirm whether you provide your consent for trips and visits either as a student or parent/carer");
            RuleFor(m => m.HasGivenPhotographicImagesConsent).NotNull().WithMessage("Please state whether you provide consent for the use of any photographic images");
            RuleFor(m => m.HasCriminalConvictions).NotNull().WithMessage("Please state whether you have any criminal convictions");
            RuleFor(m => m.CanShareInformationWithPotentialEmployers).NotNull().WithMessage("Please state whether we may share your information with potential employers");
            RuleFor(m => m.AgreeInfoIsCorrectParentCarer)
                .NotNull()
                .When(m => m.AgreeInfoIsCorrectStudent == null)
                .WithMessage("Please state whether you agree the information above is correct either as a student or parent/carer");
            RuleFor(m => m.AgreeInfoIsCorrectStudent)
                .NotNull()
                .When(m => m.AgreeInfoIsCorrectParentCarer == null)
                .WithMessage("Please state whether you agree the information above is correct either as a student or parent/carer");
            RuleFor(m => m.SignedParentCarer)
                .NotNull()
                .When(m => m.AgreeInfoIsCorrectParentCarer == true)
                .WithMessage("Please type your name in the box to confirm the information entered is correct as a parent/carer");
            RuleFor(m => m.SignedStudent)
                .NotNull()
                .When(m => m.AgreeInfoIsCorrectStudent == true)
                .WithMessage("Please type your name in the box to confirm the information entered is correct as a student");
            RuleFor(m => m.SignedParentCarerDate)
                .NotNull()
                .When(m => m.SignedParentCarer != null)
                .WithMessage("Please enter the date you are confirming the information to be correct");
            RuleFor(m => m.SignedStudentDate)
                .NotNull()
                .When(m => m.SignedStudent != null)
                .WithMessage("Please enter the date you are confirming the information to be correct");
        }
    }
}