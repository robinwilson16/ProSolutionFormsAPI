using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProSolutionFormsAPI.Models
{
    public class FundingEligibilityDeclarationEvidenceModel
    {
        [Key]
        public int FundingEligibilityDeclarationEvidenceID { get; set; }

        [JsonIgnore]
        public FundingEligibilityDeclarationModel? FundingEligibilityDeclaration { get; set; }
        public EvidenceType EvidenceTypeID { get; set; }
        public byte[]? EvidenceContent { get; set; }
        public byte[]? ImageThumbnail { get; set; }
        public string? EvidenceFileName { get; set; }
        public string? EvidenceFilePath { get; set; }
        public long? EvidenceFileSize { get; set; }
        public string? EvidenceFileExtension { get; set; }
        public string? EvidenceContentType { get; set; }
        public string? Notes { get; set; }

        //Created and Updated
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }

    public enum EvidenceType
    {
        Passport = 1,
        [Display(Name = "Birth Certificate")]
        Birth_Certificate = 2,
        [Display(Name = "Driving Licence")]
        Driving_Licence = 3,
        Other = 4
    }

    public class FundingEligibilityDeclarationEvidenceValidator : AbstractValidator<FundingEligibilityDeclarationEvidenceModel>
    {
        public FundingEligibilityDeclarationEvidenceValidator()
        {
            RuleFor(m => m.EvidenceTypeID).NotNull().WithMessage("Please confirm which type of evidence you are uploading");
            RuleFor(m => m.EvidenceContent).NotNull().WithMessage("Please ensure you upload a file containing the evidence which should be an image, PDF or Word file");
        }
    }
}
