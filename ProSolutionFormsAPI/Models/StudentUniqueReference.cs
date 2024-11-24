using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace ProSolutionFormsAPI.Models
{
    //[PrimaryKey("StudentUniqueReferenceID")]
    [Index(nameof(StudentRef), IsUnique = true)]
    public class StudentUniqueReference
    {
        public Guid StudentUniqueReferenceID { get; set; }

        [MaxLength(12)]
        [Required]
        public string? StudentRef { get; set; }
    }
}
