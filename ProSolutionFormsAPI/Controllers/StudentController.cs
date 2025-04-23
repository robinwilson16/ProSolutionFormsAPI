using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<List<StudentModel>?> GetAll() =>
            _studentService.GetAll();

        [HttpGet("{studentGUID}")]
        public ActionResult<StudentModel> Get(Guid studentGUID)
        {
            var student = _studentService.Get(studentGUID);

            if (student == null)
                return NotFound();

            return student;
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}/{studentGUID}")]
        public ActionResult<StudentModel> Get(int? academicYearIDPart1, int? academicYearIDPart2, Guid studentGUID)
        {
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var student = _studentService.Get(academicYearID, studentGUID);

            if (student == null)
                return NotFound();

            return student;
        }

        [HttpGet("Ref/{academicYearIDPart1}/{academicYearIDPart2}/{studentRef}")]
        public ActionResult<StudentModel> Get(int? academicYearIDPart1, int? academicYearIDPart2, string studentRef)
        {
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var student = _studentService.Get(academicYearID, studentRef);

            if (student == null)
                return NotFound();

            return student;
        }
    }
}
