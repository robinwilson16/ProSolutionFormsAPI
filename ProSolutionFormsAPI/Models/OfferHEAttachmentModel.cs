using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProSolutionFormsAPI.Models
{
    public class OfferHEAttachmentModel
    {
        [Key]
        public int OfferHEAttachmentID { get; set; }

        [JsonIgnore]
        public OfferHEModel? OfferHE { get; set; }
        public AttachmentType AttachmentTypeID { get; set; }
        public byte[]? AttachmentContent { get; set; }
        public byte[]? ImageThumbnail { get; set; }
        public string? AttachmentFileName { get; set; }
        public string? AttachmentFilePath { get; set; }
        public long? AttachmentFileSize { get; set; }
        public string? AttachmentFileExtension { get; set; }
        public string? AttachmentContentType { get; set; }
        public string? Notes { get; set; }

        //Created and Updated
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }

    public enum AttachmentType
    {
        [Display(Name = "Passport")]
        Passport = 1,
        [Display(Name = "Driving License")]
        DrivingLicense = 2,
        [Display(Name = "UK Residency Permit")]
        UKResidencyPermit = 3,
        [Display(Name = "Birth Certificate")]
        BirthCertificate = 4
    }

    public class OfferHEAttachmentValidator : AbstractValidator<OfferHEAttachmentModel>
    {
        public OfferHEAttachmentValidator()
        {
            RuleFor(m => m.AttachmentTypeID).NotEmpty().WithMessage("Please confirm which type of attachment you are uploading");
            RuleFor(m => m.AttachmentContent).NotNull().WithMessage("Please ensure you upload a file which should be an image, PDF or Word file. If you have nothing to upload then please remove the attachment using the button underneath the box.");
        }
    }
}
