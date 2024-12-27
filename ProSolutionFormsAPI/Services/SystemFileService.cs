using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace ProSolutionFormsAPI.Services
{
    public class SystemFileService
    {
        private readonly ApplicationDbContext _context;


        public List<SystemFileModel>? SystemFiles { get; }

        public SystemFileService(ApplicationDbContext context)
        {
            _context = context;

            //SystemFiles = _context.SystemFile!
            //    .ToList();
            SystemFiles = new List<SystemFileModel>();
        }

        public List<SystemFileModel>? GetAll() => SystemFiles;

        public SystemFileModel? Get(int systemFileID) => SystemFiles?.FirstOrDefault(m => m.SystemFileID == systemFileID);

        public async Task<SystemFileModel> Add(SystemFileModel systemFile)
        {
            string currentFolder = Directory.GetCurrentDirectory();

            if (systemFile == null)
                return;

            //Create Directory if it does not exist
            try
            {
                if (!Directory.Exists(Path.Combine(currentFolder, systemFile.FilePath ?? "UploadedFiles/Unspecified")))
                {
                    Directory.CreateDirectory(Path.Combine(currentFolder, systemFile.FilePath ?? "UploadedFiles/Unspecified"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating directory: {ex.Message}");
            }

            string filePath = Path.Combine(currentFolder, systemFile.FilePath ?? "UploadedFiles/Unspecified", systemFile.FileName!);

            //Save File to File System
            using var stream = File.Create(filePath);
            if (systemFile.FileContent?.Length > 0)
            {
                await stream.WriteAsync(systemFile.FileContent, 0, systemFile.FileContent.Length);
            }
        }

        public async Task<List<SystemFileModel>> AddMany(List<SystemFileModel> systemFiles)
        {
            if (systemFiles == null) return;
            foreach (var systemFile in systemFiles)
            {
                await Add(systemFile);
            }
        }
    }
}
