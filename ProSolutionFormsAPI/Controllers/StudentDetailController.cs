using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentDetailController : ControllerBase
    {
        private readonly StudentDetailService _studentDetailService;

        public StudentDetailController(StudentDetailService studentDetailService)
        {
            _studentDetailService = studentDetailService;
        }

        [HttpGet]
        public ActionResult<List<StudentDetailModel>?> GetAll() =>
            _studentDetailService.GetAll();

        [HttpGet("{studentRef}")]
        public ActionResult<StudentDetailModel> Get(string studentRef)
        {
            var studentDetail = _studentDetailService.Get(studentRef);

            if (studentDetail == null)
                return NotFound();

            return studentDetail;
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}/{studentRef}")]
        public ActionResult<StudentDetailModel> Get(int? academicYearIDPart1, int? academicYearIDPart2, string studentRef)
        {
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var studentDetail = _studentDetailService.Get(academicYearID, studentRef);

            if (studentDetail == null)
                return NotFound();

            return studentDetail;
        }
    }
}
