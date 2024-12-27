using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProSolutionFormsAPI.Models
{
    public class MedicalInformationMedicalConditionModel
    {
        [Key]
        public int MedicalInformationMedicalConditionID { get; set; }

        [JsonIgnore]
        public virtual MedicalInformationModel? MedicalInformation { get; set; }
        public int? MedicalConditionTypeID { get; set; }
        public string? MedicationDetails { get; set; }
        public string? MedicationSchedule { get; set; }
        public string? Notes { get; set; }

        //Created and Updated
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
