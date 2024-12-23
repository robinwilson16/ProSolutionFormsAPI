using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    [Keyless]
    public class GraphAPIEmailContentModel
    {
        public string? Subject { get; set; }
        public GraphAPIEmailContentBodyModel? Body { get; set; }
        public ICollection<GraphAPIEmailContentRecipientModel>? ToRecipients { get; set; }
        public ICollection<GraphAPIEmailContentRecipientModel>? CCRecipients { get; set; }
    }
}
