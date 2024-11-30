using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CriminalConvictionController : ControllerBase
    {
        private readonly CriminalConvictionService _criminalConvictionService;

        public CriminalConvictionController(CriminalConvictionService criminalConvictionService)
        {
            _criminalConvictionService = criminalConvictionService;
        }

        [HttpGet]
        public ActionResult<List<CriminalConvictionModel>?> GetAll() =>
            _criminalConvictionService.GetAll();

        [HttpGet("{criminalConvictionID}")]
        public ActionResult<CriminalConvictionModel> Get(int criminalConvictionID)
        {
            var criminalConviction = _criminalConvictionService.Get(criminalConvictionID);

            if (criminalConviction == null)
                return NotFound();

            return criminalConviction;
        }

        [HttpGet("StudentDetailID/{criminalConvictionID}")]
        public ActionResult<List<CriminalConvictionModel>> GetByStudentDetailID(int studentDetailID)
        {
            var criminalConvictions = _criminalConvictionService.GetByStudentDetailID(studentDetailID);

            if (criminalConvictions == null)
                return NotFound();

            return criminalConvictions;
        }

        [HttpGet("StudentRef/{academicYearID}/{studentRef}")]
        public ActionResult<List<CriminalConvictionModel>> GetByStudentRef(string academicYearID, string studentRef)
        {
            var criminalConvictions = _criminalConvictionService.GetByStudentRef(academicYearID, studentRef);

            if (criminalConvictions == null)
                return NotFound();

            return criminalConvictions;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CriminalConvictionModel criminalConviction)
        {
            //Check this record is not already existing
            var existingRecord = _criminalConvictionService.Get(criminalConviction.CriminalConvictionID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            await _criminalConvictionService.Add(criminalConviction);

            return CreatedAtAction(nameof(Create), new { criminalConvictionID = criminalConviction.CriminalConvictionID }, criminalConviction);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<CriminalConvictionModel> criminalConvictions)
        {
            await _criminalConvictionService.AddMany(criminalConvictions);

            return CreatedAtAction(nameof(Create), new { criminalConvictionID = criminalConvictions[0].CriminalConvictionID }, criminalConvictions);
        }

        [HttpPut("{criminalConvictionID}")]
        public async Task<IActionResult> Update(int criminalConvictionID, CriminalConvictionModel criminalConviction)
        {
            if (criminalConvictionID != criminalConviction.CriminalConvictionID)
                return BadRequest();

            var existingRecord = _criminalConvictionService.Get(criminalConvictionID);
            if (existingRecord is null)
                return NotFound();

            await _criminalConvictionService.Update(criminalConviction);

            return NoContent();
        }

        [HttpDelete("{criminalConvictionID}")]
        public async Task<IActionResult> Delete(int criminalConvictionID)
        {
            var criminalConviction = _criminalConvictionService.Get(criminalConvictionID);

            if (criminalConviction is null)
                return NotFound();

            await _criminalConvictionService.Delete(criminalConvictionID);

            return NoContent();
        }
    }
}
