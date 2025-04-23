using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    public class StudentApplicationModel
    {
        [Key]
        public int ApplicationCourseID { get; set; }
        public int? ApplicationID { get; set; }
        public int? StudentDetailID { get; set; }
        public int StudentID { get; set; }
        public string? StudentRef { get; set; }
        public string? Surname { get; set; }
        public string? Forename { get; set; }
        public string? CollegeCode { get; set; }
        public string? CollegeName { get; set; }
        public string? DirectorateCode { get; set; }
        public string? DirectorateName { get; set; }
        public string? CAMCode { get; set; }
        public string? CAMName { get; set; }
        public string? DeptCode { get; set; }
        public string? DeptName { get; set; }
        public int? CourseID { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseTitle { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "decimal(19,4)")]
        [DataType(DataType.Currency)]
        public decimal? YearlyCourseFee { get; set; }
        public string? ApplicationStatusCode { get; set; }
        public string? ApplicationStatusName { get; set; }
    }
}
