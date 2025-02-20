using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProSolutionFormsAPI.Services
{
    public class StudentDetailService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public List<StudentDetailModel>? StudentDetails { get; }
        public string AcademicYear { get; }

        public StudentDetailService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            string academicYear = (string?)configuration.GetSection("Settings")["DefaultAcademicYearID"] ?? "";
            AcademicYear = academicYear;

            StudentDetails = _context.StudentDetail!
                .FromSqlInterpolated($"EXEC SPR_StudentDetails @AcademicYear = {academicYear}, @StudentRef = {null}")
                .ToList();
        }

        public List<StudentDetailModel>? GetAll() => StudentDetails;

        //Moved to main function as generally want to return all records - can review if performance is bad
        //public List<StudentDetailModel>? GetAll() => _context.StudentDetail!
        //    .FromSqlInterpolated($"EXEC SPR_StudentDetails @AcademicYear = {AcademicYear}, @StudentRef = {null}")
        //    .ToList();
        public StudentDetailModel? Get(string studentRef)
        {
            string academicYear = (string?)_configuration.GetSection("Settings")["DefaultAcademicYearID"] ?? "";

            return (_context.StudentDetail!
            .FromSqlInterpolated($"EXEC SPR_StudentDetails @AcademicYear = {academicYear}, @StudentRef = {studentRef}").ToList())
            .FirstOrDefault();
        }

        public StudentDetailModel? Get(string academicYearID, string studentRef) => (_context.StudentDetail!
            .FromSqlInterpolated($"EXEC SPR_StudentDetails @AcademicYear = {academicYearID}, @StudentRef = {studentRef}").ToList())
            .FirstOrDefault();
    }
}
