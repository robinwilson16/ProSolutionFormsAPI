using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProSolutionFormsAPI.Models
{
    public class MedicalInformationDifficultyDisabilityModel
    {
        [Key]
        public int MedicalInformationDifficultyDisabilityID { get; set; }

        [JsonIgnore]
        public MedicalInformationModel? MedicalInformation { get; set; }
        public int? DisabilityCategoryID { get; set; }
        public string? Notes { get; set; }
        public bool? IsPrimary { get; set; }
        
        //Created and Updated
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
