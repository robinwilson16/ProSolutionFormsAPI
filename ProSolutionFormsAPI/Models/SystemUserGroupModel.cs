using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    public class SystemUserGroupModel
    {
        [Key]
        public string? GroupID { get; set; }
        public string? GroupName { get; set; }

        [JsonIgnore]
        public virtual SystemUserModel? SystemUser { get; set; }
    }
}
