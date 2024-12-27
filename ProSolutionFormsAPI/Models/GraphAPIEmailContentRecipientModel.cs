using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    [Keyless]
    public class GraphAPIEmailContentRecipientModel
    {
        public virtual GraphAPIEmailContentRecipientEmailModel? EmailAddress { get; set; }
    }
}
