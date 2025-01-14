using FluentValidation;
using ProSolutionFormsAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProSolutionFormsAPI.Models
{
    public class MedicalLearningSupportAndTripConsentMedicalConditionModel
    {
        [Key]
        public int MedicalLearningSupportAndTripConsentMedicalConditionID { get; set; }

        [JsonIgnore]
        public MedicalLearningSupportAndTripConsentModel? MedicalLearningSupportAndTripConsent { get; set; }
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

    public class MedicalInformationMedicalConditionValidator : AbstractValidator<MedicalLearningSupportAndTripConsentMedicalConditionModel>
    {
        //Drop-down options
        public List<DropDownIntModel>? MedicalConditions = new List<DropDownIntModel>();

        public MedicalInformationMedicalConditionValidator()
        {
            //Get lists of drop-down options to be checked
            //MedicalConditions = MedicalInformation.GetMedicalConditionTypes();

            RuleFor(m => m.MedicalConditionTypeID)
                .Must(f => MedicalConditions.Any(c => c.Code == f))
                .WithMessage(e => $"The value you entered '{e.MedicalConditionTypeID}' is not valid. Please enter or select a valid option from the list");
        }
    }
}
