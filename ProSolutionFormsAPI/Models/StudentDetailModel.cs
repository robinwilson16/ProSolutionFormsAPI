using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    public class StudentDetailModel
    {
        [Key]
        public int? StudentDetailID { get; set; }
        public int StudentID { get; set; }

        [Display(Name = "Stu Ref")]
        public string? StudentRef { get; set; }
        public string? Surname { get; set; }
        public string? Forename { get; set; }
        public Guid? StudentGUID { get; set; }

        [Display(Name = "Col")]
        public string? CollegeCode { get; set; }
        public string? CollegeName { get; set; }

        [Display(Name = "Dir")]
        public string? DirectorateCode { get; set; }
        public string? DirectorateName { get; set; }

        [Display(Name = "CAM")]
        public string? CAMCode { get; set; }
        public string? CAMName { get; set; }

        [Display(Name = "Dept")]
        public string? DeptCode { get; set; }
        public string? DeptName { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseTitle { get; set; }

        [Display(Name = "App Date")]
        public DateTime? ApplicationDate { get; set; }

        public int? ApplicationSourceID { get; set; }

        [Display(Name = "Stage")]
        public string? ApplicationSourceCode { get; set; }
        public string? ApplicationSourceName { get; set; }

        [Display(Name = "Med Form")]
        public bool? MedicalFormCompleted { get; set; }
        public int? MedicalFormLatestSubmissionID { get; set; }

        [Display(Name = "Med Latest")]
        public DateTime? MedicalFormLatestSubmissionDate { get; set; }

        [Display(Name = "Med Forms")]
        public int? MedicalFormNumberOfSubmissions { get; set; }

        [Display(Name = "Med Course")]
        public string? MedicalFormCourseCode { get; set; }

        [Display(Name = "Crim Form")]
        public bool? CriminalConvictionFormCompleted { get; set; }
        public int? CriminalConvictionFormLatestSubmissionID { get; set; }

        [Display(Name = "Crim Latest")]
        public DateTime? CriminalConvictionFormLatestSubmissionDate { get; set; }

        [Display(Name = "Crim Forms")]
        public int? CriminalConvictionFormNumberOfSubmissions { get; set; }

        [Display(Name = "Fund Form")]
        public bool? FundingEligibilityFormCompleted { get; set; }

        public int? FundingEligibilityFormLatestSubmissionID { get; set; }

        [Display(Name = "Fund Latest")]
        public DateTime? FundingEligibilityFormLatestSubmissionDate { get; set; }

        [Display(Name = "Fund Forms")]
        public int? FundingEligibilityFormNumberOfSubmissions { get; set; }

        public string? MedicalConsentFormReceivedCode { get; set; }

        [Display(Name = "Med Approved")]
        public string? MedicalConsentFormReceivedName { get; set; }
        public string? TripPhotographicCosentObtainedCode { get; set; }

        [Display(Name = "Trip Approved")]
        public string? TripPhotographicCosentObtainedName { get; set; }
    }
}
