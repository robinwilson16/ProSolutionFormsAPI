using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class StudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public List<StudentModel>? Students { get; }
        public string AcademicYear { get; }

        public StudentService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            string academicYear = (string?)configuration.GetSection("Settings")["DefaultAcademicYearID"] ?? "";
            AcademicYear = academicYear;
            //Moved out of main method so does not run for all students
            //Students = _context.Student!
            //    .FromSqlInterpolated($"EXEC SPR_GetStudentByGUID @AcademicYear = {academicYear}, @StudentGUID = {null}")
            //    .ToList();
        }

        //public List<Student>? GetAll() => Students;
        public List<StudentModel>? GetAll() => _context.Student!
            .FromSqlInterpolated($"EXEC SPR_GetStudentByGUID @AcademicYear = {AcademicYear}, @StudentGUID = {null}")
            .ToList();
        public StudentModel? Get(Guid studentGUID) => (_context.Student!
            .FromSqlInterpolated($"EXEC SPR_GetStudentByGUID @AcademicYear = {AcademicYear}, @StudentGUID = {studentGUID}").ToList())
            .FirstOrDefault();
        public StudentModel? Get(string academicYearID, Guid studentGUID) => (_context.Student!
            .FromSqlInterpolated($"EXEC SPR_GetStudentByGUID @AcademicYear = {academicYearID}, @StudentGUID = {studentGUID}").ToList())
            .FirstOrDefault();
    }
}
