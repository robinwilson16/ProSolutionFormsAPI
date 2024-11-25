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

        [HttpGet("{academicYearID}/{studentGUID}")]
        public ActionResult<StudentModel> Get(string academicYearID, Guid studentGUID)
        {
            var student = _studentService.Get(academicYearID, studentGUID);

            if (student == null)
                return NotFound();

            return student;
        }
    }
}
