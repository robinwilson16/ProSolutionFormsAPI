using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    public class InterviewHEModel
    {
        [Key]
        public int InterviewHEID { get; set; }

        public string? MotivationForStudyingCourseAndIntendedNextSteps { get; set; }
        public string? SuitabilityAndRelevantQualificationsAndExperience { get; set; }
        public HighestQualOnEntryLevel? HighestQualOnEntryLevel { get; set; }
        public string? HighestQualOnEntryDetail { get; set; }
        public bool? HasDifficultiesAndOrDisabilities { get; set; }
        public string? DifficultiesAndOrDisabilitiesFurtherDetails { get; set; }
        public bool? UnderstandsStructureOfCourse { get; set; }
        public MethodOfFunding? MethodOfFunding { get; set; }
        public bool? IsAwareOfTuitionFee { get; set; }

        [Column(TypeName = "decimal(19,4)")]
        [DataType(DataType.Currency)]
        public decimal? TuitionFeeAgreedTo { get; set; }
        public bool? InEmployment { get; set; }
        public LastEducationalEstablishmentAttended? LastEducationalEstablishmentAttended { get; set; }
        public string? LastEducationalEstablishmentAttendedOtherDetail { get; set; }
        public string? FinanciallySupportSelfDuringCourse { get; set; }
        public string? ManageDemandsOfStudyAroundJobAndFamily { get; set; }
        public HeardAboutCourse? HeardAboutCourse { get; set; }
        public string? HeardAboutCourseOther { get; set; }
        public string? QuestionsAskedAndAdviceGiven { get; set; }
        public InterviewOutcome? InterviewOutcome { get; set; }
        public string? OfferConditions { get; set; }

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
        public int? ApplicationCourseID { get; set; }
    }

    public enum HighestQualOnEntryLevel
    {
        [Display(Name = "Level 1")]
        Level1 = 1,
        [Display(Name = "Level 2")]
        Level2 = 2,
        [Display(Name = "Level 3")]
        Level3 = 3,
        [Display(Name = "Level 4")]
        Level4 = 4,
        [Display(Name = "Level 5")]
        Level5 = 5,
        [Display(Name = "Level 6")]
        Level6 = 6,
        [Display(Name = "Level 7")]
        Level7 = 7,
        [Display(Name = "Other / None")]
        OtherNone = 99
    }

    public enum MethodOfFunding
    {
        [Display(Name = "Self Financing (No Loan)")]
        Student = 1,
        [Display(Name = "Employer Paying")]
        Employer = 2,
        [Display(Name = "Student Loans Company (SLC) Loan")]
        Loan = 3
    }

    public enum LastEducationalEstablishmentAttended
    {
        [Display(Name = "Further Education College")]
        College = 1,
        [Display(Name = "Sixth Form")]
        SixthForm = 2,
        University = 3,
        School = 4,
        Other = 99
    }

    public enum HeardAboutCourse
    {
        [Display(Name = "Been Here Before")]
        BeenHereBefore = 1,
        [Display(Name = "College Website")]
        CollegeWebsite = 2,
        [Display(Name = "Social Media")]
        SocialMedia = 3,
        [Display(Name = "Word Of Mouth")]
        WordOfMouth = 3,
        [Display(Name = "Bus Advert")]
        BusAdvert = 4,
        [Display(Name = "Referral from Partner University")]
        ReferralFromPartnerUni = 5,
        [Display(Name = "Referral from Other University")]
        ReferralFromOtherUni = 6,
        [Display(Name = "Other, Please Specify...")]
        OtherPleaseSpecify = 99
    }

    public enum InterviewOutcome
    {
        [Display(Name = "Make Offer")]
        MakeOffer = 1,
        [Display(Name = "Futher Interview/IAG")]
        FurtherInterview = 2,
        [Display(Name = "Declined by College")]
        DeclinedCollege = 3,
        [Display(Name = "Student Has Withdrawn Application")]
        DeclinedStudent = 4
    }

    public class InterviewHEValidator : AbstractValidator<InterviewHEModel>
    {
        public InterviewHEValidator()
        {
            RuleFor(m => m.MotivationForStudyingCourseAndIntendedNextSteps).NotNull().WithMessage("Please record the applicant's Motivation for Studying the Course and Intended Next Steps");
            RuleFor(m => m.SuitabilityAndRelevantQualificationsAndExperience).NotNull().WithMessage("Please record the applicant's suitability for this course and what relevant qualifications and experience they have");
            RuleFor(m => m.HighestQualOnEntryLevel).NotNull().WithMessage("Please enter the Highest Prior Qualification Level");
            When(m => (int?)m.HighestQualOnEntryLevel == 99, () =>
            {
                RuleFor(m => m.HighestQualOnEntryDetail).NotNull().WithMessage("When selecting Other / None please still enter the Highest Prior Qualification Detail");
            }).Otherwise(() => {
                RuleFor(m => m.HighestQualOnEntryDetail).NotNull().WithMessage("Please enter the Highest Prior Qualification Detail including the Level, Type and Title");
            });
            RuleFor(m => m.HasDifficultiesAndOrDisabilities).NotNull().WithMessage("Please state whether the applicant has any learning difficulties and/or disabilities");
            When(m => m.HasDifficultiesAndOrDisabilities == true, () =>
            {
                RuleFor(m => m.DifficultiesAndOrDisabilitiesFurtherDetails).NotNull().WithMessage("As you have selected the applicant has Learning Difficulties and/or Disabilities please enter the details including how it will impact their course");
            });
            RuleFor(m => m.UnderstandsStructureOfCourse).NotNull().WithMessage("Please confirm you have explained the structure of the course to the applicant, including modules covered and how they will be assessed");
            RuleFor(m => m.UnderstandsStructureOfCourse).NotNull().WithMessage("Please confirm the Method of Funding");
            RuleFor(m => m.IsAwareOfTuitionFee).NotNull().WithMessage("Please confirm you have made the applicant aware of the correct tuition fee for this course");
            RuleFor(m => m.InEmployment).NotNull().WithMessage("Please confirm whether the applicant is In Employment");
            RuleFor(m => m.LastEducationalEstablishmentAttended).NotNull().WithMessage("Please confirm the Last Educational Establishment Type attended");
            When(m => (int?)m.LastEducationalEstablishmentAttended == 99, () =>
            {
                RuleFor(m => m.LastEducationalEstablishmentAttendedOtherDetail).NotNull().WithMessage("When selecting Other please enter details of the Last Educational Establishment Type attended");
            });
            RuleFor(m => m.FinanciallySupportSelfDuringCourse).NotNull().WithMessage("Please record details of how the applicant will be able to support themselves financially during the course");
            RuleFor(m => m.ManageDemandsOfStudyAroundJobAndFamily).NotNull().WithMessage("Please record details of how the applicant will manage the demands of study, especially if they are studying part tiime around a job, family and other commitements");
            RuleFor(m => m.HeardAboutCourse).NotNull().WithMessage("Please confirm how the applicant heard about the course/opportunity");
            When(m => (int?)m.HeardAboutCourse == 99, () =>
            {
                RuleFor(m => m.HeardAboutCourseOther).NotNull().WithMessage("When selecting Other please enter details of how the applicant found out about the course/opportunity");
            });
            RuleFor(m => m.InterviewOutcome).NotNull().WithMessage("Please confirm the outcome for this interview");
        }
    }
}
