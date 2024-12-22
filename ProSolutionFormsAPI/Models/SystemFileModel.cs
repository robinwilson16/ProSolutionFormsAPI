using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    public class SystemFileModel
    {
        [Key]
        public int SystemFileID { get; set; }
        public byte[]? FileContent { get; set; }
        public byte[]? ImageThumbnail { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public long? FileSize { get; set; }
        public string? FileExtension { get; set; }
        public string? FileContentType { get; set; }
    }
}
