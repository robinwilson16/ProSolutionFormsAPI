using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ProSolutionFormsAPI.Services
{
    public class StudentApplicationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public List<StudentApplicationModel>? StudentApplications { get; }
        public string AcademicYear { get; }

        public StudentApplicationService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            string academicYear = (string?)configuration.GetSection("Settings")["DefaultAcademicYearID"] ?? "";
            AcademicYear = academicYear;

            //StudentApplications = _context.StudentApplication!
            //    .FromSqlInterpolated($"EXEC SPR_StudentApplications @AcademicYear = {academicYear}, @StudentRef = {null}")
            //    .ToList();
        }

        //public List<StudentApplicationModel>? GetAll() => StudentApplications;

        //Moved to main function as generally want to return all records - can review if performance is bad
        public List<StudentApplicationModel>? GetAll() => _context.StudentApplication!
            .FromSqlInterpolated($"EXEC SPR_GetStudentApplications @AcademicYear = {AcademicYear}, @StudentRef = {null}, @ApplicationCourseID = {null}")
            .ToList();
        public List<StudentApplicationModel>? GetByStudent(string studentRef)
        {
            string academicYear = (string?)_configuration.GetSection("Settings")["DefaultAcademicYearID"] ?? "";

            return _context.StudentApplication!
            .FromSqlInterpolated($"EXEC SPR_GetStudentApplications @AcademicYear = {academicYear}, @StudentRef = {studentRef}, @ApplicationCourseID = {null}").ToList();
        }

        public List<StudentApplicationModel>? Get(string academicYearID) => _context.StudentApplication!
            .FromSqlInterpolated($"EXEC SPR_GetStudentApplications @AcademicYear = {academicYearID}, @StudentRef = {null}, @ApplicationCourseID = {null}").ToList();

        public List<StudentApplicationModel>? Get(string academicYearID, string studentRef) => _context.StudentApplication!
            .FromSqlInterpolated($"EXEC SPR_GetStudentApplications @AcademicYear = {academicYearID}, @StudentRef = {studentRef}, @ApplicationCourseID = {null}").ToList();

        public StudentApplicationModel? Get(string academicYearID, string studentRef, int? applicationCourseID) => (_context.StudentApplication!
            .FromSqlInterpolated($"EXEC SPR_GetStudentApplications @AcademicYear = {academicYearID}, @StudentRef = {studentRef}, @ApplicationCourseID = {applicationCourseID}").ToList())
            .FirstOrDefault();
    }
}
