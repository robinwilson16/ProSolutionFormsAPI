using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    [Keyless]
    public class GraphAPIEmailModel
    {
        public virtual GraphAPIEmailContentModel? Message { get; set; }
        public bool? SaveToSentItems { get; set; }
    }
}
