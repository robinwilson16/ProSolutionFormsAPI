using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    public class SystemUserModel
    {
        [Key]
        [Required]
        public string? UserID { get; set; }
        
        [Required]
        public string? Email { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public byte[]? Photo { get; set; }
        public byte[]? PhotoThumbnail { get; set; }
        public string? AccessToken { get; set; }
        public string? CodeToken { get; set; }
        public string? BearerToken { get; set; }
        public ICollection<SystemUserGroupModel>? Groups { get; set; }
    }

    public class SystemUserValidator : AbstractValidator<SystemUserModel>
    {
        public SystemUserValidator()
        {
            

        }
    }
}
