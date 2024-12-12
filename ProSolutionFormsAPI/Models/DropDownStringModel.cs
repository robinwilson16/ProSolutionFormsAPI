using System.ComponentModel.DataAnnotations;

namespace ProSolutionFormsAPI.Models
{
    public class DropDownStringModel
    {
        [Key]
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
