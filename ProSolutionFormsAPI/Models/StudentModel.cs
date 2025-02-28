using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    public class StudentModel
    {
        [Key]
        public int StudentID { get; set; }
        public int? StudentDetailID { get; set; }
        public string? StudentRef { get; set; }
        public string? Surname { get; set; }
        public string? Forename { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public Guid? StudentGUID { get; set; }
        public string? AcademicYearID { get; set; }
        public string? CollegeCode { get; set; }
        public string? CollegeName { get; set; }
        public string? DirectorateCode { get; set; }
        public string? DirectorateName { get; set; }
        public string? CAMCode { get; set; }
        public string? CAMName { get; set; }
        public string? DeptCode { get; set; }
        public string? DeptName { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseTitle { get; set; }
        public string? CompletionStatusCode { get; set; }
        public string? CompletionStatusName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpEndDate { get; set; }
        public DateTime? ActEndDate { get; set; }

    }
}
