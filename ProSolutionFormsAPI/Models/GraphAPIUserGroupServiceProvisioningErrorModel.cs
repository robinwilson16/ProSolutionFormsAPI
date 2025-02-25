using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    [Keyless]
    public class GraphAPIUserGroupServiceProvisioningErrorModel
    {
        public string? CreatedDateTime { get; set; }
        public bool? IsResolved { get; set; }
        public string? ServiceInstance { get; set; }
        public string? ErrorDetail { get; set; }
    }
}
