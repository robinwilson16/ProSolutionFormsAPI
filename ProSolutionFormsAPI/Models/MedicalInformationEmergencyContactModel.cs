using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProSolutionFormsAPI.Models
{
    public class MedicalInformationEmergencyContactModel
    {
        [Key]
        public int MedicalInformationEmergencyContactID { get; set; }

        [JsonIgnore]
        public MedicalInformationModel? MedicalInformation { get; set; }
        public int? ContactOrder { get; set; }
        public string? Surname { get; set; }
        public string? Forename { get; set; }
        public string? Title { get; set; }
        public int? RelationshipToStudent { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Address4 { get; set; }
        public string? PostCodeOut { get; set; }
        public string? PostCodeIn { get; set; }
        public string? PostCode
        {
            get
            {
                return PostCodeOut + " " + PostCodeIn;
            }
        }
        public string? TelHome { get; set; }
        public string? TelMobile { get; set; }
        public string? TelWork { get; set; }
        public string? Email { get; set; }
        
        //Created and Updated
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
