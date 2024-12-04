using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProSolutionFormsAPI.Models
{
    public class MedicalInformationModel
    {
        [Key]
        public int MedicalInformationID { get; set; }
        public ICollection<MedicalInformationEmergencyContactModel>? EmergencyContacts { get; set; }
        public ICollection<MedicalInformationMedicalConditionModel>? MedicalConditions { get; set; }
        public ICollection<MedicalInformationDisabilityDifficultyModel>? DisabilitiesDifficulties { get; set; }
        public bool? RequiresRiskAssesment { get; set; }
        public bool? HasBeenHospitalisedInLastYear { get; set; }
        public string? HospitalisationNotes { get; set; }
        public bool? RequiresLearningSupport { get; set; }
        public bool? HasEHCP { get; set; }
        public bool? IsLAC { get; set; }
        public bool? IsCareLeaver { get; set; }
        public bool? HasFSM { get; set; }
        public bool? IsFromMilitaryServiceFamily { get; set; }
        public bool? HasAccessArrangements { get; set; }
        public string? AccessRequirementDetails { get; set; }
        public string? SupportInPlaceAtPriorSchoolOrCollege { get; set; }
        public bool? CanContactPriorSchoolOrCollege { get; set; }
        public bool? HasCriminalConvictions { get; set; }
        public string? CriminalConvictionDetails { get; set; }
        public bool? CanShareInformationWithPotentialEmployers { get; set; }
        public bool? AgreeInfoIsCorrect { get; set; }
        public string? SignedStudent { get; set; }
        public DateTime? SignedStudentDate { get; set; }
        public string? SignedParentCarer { get; set; }
        public DateTime? SignedParentCarerDate { get; set; }
        public bool? HasGivenTripConsentStudent { get; set; }
        public bool? HasGivenTripConsentParentCarer { get; set; }
        public bool? HasGivenPhotographicImagesConsent { get; set; }
        
        //Created and Updated
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        //Linking Data
        public int? StudentDetailID { get; set; }

        [MaxLength(5)]
        public string? AcademicYearID { get; set; }

        [MaxLength(12)]
        public string? StudentRef { get; set; }
    }
}
