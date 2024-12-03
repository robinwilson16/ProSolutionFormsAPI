using System.ComponentModel.DataAnnotations;

namespace ProSolutionFormsAPI.Models
{
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
        public string? TeamCode { get; set; }
        public string? TeamName { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseTitle { get; set; }
        public string? CompletionStatusCode { get; set; }
        public string? CompletionStatusName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpEndDate { get; set; }
        public DateTime? ActEndDate { get; set; }
        public int? NumConvictions { get; set; }

    }
}
