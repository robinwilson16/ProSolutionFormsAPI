using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    [Keyless]
    public class GraphAPIUserGroupsModel
    {
        public virtual ICollection<GraphAPIUserGroupModel>? Value { get; set; }
    }
}
