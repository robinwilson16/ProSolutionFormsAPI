using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ProSolutionForms.Models
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }
        
        [Required]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }

        [JsonPropertyName("isActive")]
        public int? IsActive { get; set; }

        [JsonIgnore]
        [Display(Name = "Is Active")]
        public bool? isActive
        {
            get { return Convert.ToBoolean(IsActive); }
        }

        public string? Token { get; set; }

        [JsonPropertyName("lastLoginTime")]
        public string? LastLoginTime { get; set; }

        [JsonIgnore]
        [Display(Name = "Last Login Time")]
        public DateTime? lastLoginTime
        {
            get { return DateTime.Parse(LastLoginTime ?? "", new CultureInfo("en-GB")); }
        }
    }

    public class LoginValidator : AbstractValidator<UserModel>
    {
        public LoginValidator()
        {
            When(l => l.Token == null, () =>
            {
                RuleFor(l => l.Email).EmailAddress().NotEmpty().WithMessage("Please enter your email address");
                RuleFor(l => l.Password).NotEmpty().WithMessage("Please enter your password");
            }).Otherwise(() =>
            {
                RuleFor(l => l.Token).NotEmpty().WithMessage("A token or email and password are required");
            });

        }
    }
}
