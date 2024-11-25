using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentUniqueReferenceController : ControllerBase
    {
        private readonly StudentUniqueReferenceService _studentUniqueReferenceService;

        public StudentUniqueReferenceController(StudentUniqueReferenceService studentUniqueReferenceService)
        {
            _studentUniqueReferenceService = studentUniqueReferenceService;
        }

        [HttpGet]
        public ActionResult<List<StudentUniqueReferenceModel>?> GetAll() =>
            _studentUniqueReferenceService.GetAll();

        [HttpGet("{studentRef}")]
        public ActionResult<StudentUniqueReferenceModel> Get(string studentRef)
        {
            var studentUniqueReference = _studentUniqueReferenceService.Get(studentRef);

            if (studentUniqueReference == null)
                return NotFound();

            return studentUniqueReference;
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentUniqueReferenceModel studentUniqueReference)
        {
            //Check this record is not already existing
            var studentUniqueReferenceExisting = _studentUniqueReferenceService.Get(studentUniqueReference.StudentRef ?? "");

            if (studentUniqueReferenceExisting is not null)
                return BadRequest("Student Exists");

            await _studentUniqueReferenceService.Add(studentUniqueReference);

            return CreatedAtAction(nameof(Create), new { studentUniqueReference = studentUniqueReference.StudentRef }, studentUniqueReference);
        }

        [HttpPut("{studentUniqueReferenceID}")]
        public async Task<IActionResult> Update(Guid studentUniqueReferenceID, StudentUniqueReferenceModel studentUniqueReference)
        {
            if (studentUniqueReferenceID != studentUniqueReference.StudentUniqueReferenceID)
                return BadRequest();

            var existingStudentUniqueReference = _studentUniqueReferenceService.GetByID(studentUniqueReferenceID);
            if (existingStudentUniqueReference is null)
                return NotFound();

            await _studentUniqueReferenceService.Update(studentUniqueReference);

            return NoContent();
        }

        [HttpDelete("{studentRef}")]
        public async Task<IActionResult> Delete(string studentRef)
        {
            var studentUniqueReference = _studentUniqueReferenceService.Get(studentRef);

            if (studentUniqueReference is null)
                return NotFound();

            await _studentUniqueReferenceService.Delete(studentRef);

            return NoContent();
        }
    }
}
