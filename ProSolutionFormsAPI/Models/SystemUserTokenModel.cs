using System.ComponentModel.DataAnnotations;

namespace ProSolutionFormsAPI.Models
{
    public class SystemUserTokenModel
    {
        [Key]
        public string? BearerToken { get; set; }
    }
}
