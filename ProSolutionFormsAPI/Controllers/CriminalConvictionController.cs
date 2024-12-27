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

        private ModelResultModel? _modelResult;

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
        public async Task<IActionResult> Create(CriminalConvictionModel newCriminalConviction)
        {
            //Check this record does not already exist
            var existingRecord = _criminalConvictionService.Get(newCriminalConviction.CriminalConvictionID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            _modelResult = await _criminalConvictionService.Add(newCriminalConviction);

            return CreatedAtAction(nameof(Create), new { newCriminalConviction.CriminalConvictionID }, newCriminalConviction);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<CriminalConvictionModel> newcriminalConvictions)
        {
            _modelResult = await _criminalConvictionService.AddMany(newcriminalConvictions);

            var ids = string.Join(",", newcriminalConvictions.Select(t => t.CriminalConvictionID));

            return CreatedAtAction(nameof(Create), new { ids }, newcriminalConvictions);
        }

        [HttpPut("{criminalConvictionID}")]
        public async Task<IActionResult> Update(int criminalConvictionID, CriminalConvictionModel updatedCriminalConviction)
        {
            if (criminalConvictionID != updatedCriminalConviction.CriminalConvictionID)
                return BadRequest();

            var existingRecord = _criminalConvictionService.Get(criminalConvictionID);
            if (existingRecord is null)
                return NotFound();

            await _criminalConvictionService.Update(updatedCriminalConviction);

            return AcceptedAtAction(nameof(Update), new { }, updatedCriminalConviction);
        }

        [HttpPut("Many/{studentDetailID}")]
        public async Task<IActionResult> UpdateMany(int studentDetailID, List<CriminalConvictionModel> updatedCriminalConvictions)
        {
            if (updatedCriminalConvictions == null)
                return BadRequest();

            var existingRecords = _criminalConvictionService.GetByStudentDetailID(studentDetailID);
            if (existingRecords is null)
                return NotFound();

            await _criminalConvictionService.UpdateMany(studentDetailID, updatedCriminalConvictions);

            return AcceptedAtAction(nameof(Update), new { }, updatedCriminalConvictions);
        }

        [HttpDelete("{criminalConvictionID}")]
        public async Task<IActionResult> Delete(int criminalConvictionID)
        {
            var recordToDelete = _criminalConvictionService.Get(criminalConvictionID);

            if (recordToDelete is null)
                return NotFound();

            await _criminalConvictionService.Delete(criminalConvictionID);

            return AcceptedAtAction(nameof(Delete), new { }, recordToDelete);
        }

        [HttpDelete("Many/{studentDetailID}")]
        public async Task<IActionResult> DeleteMany(int studentDetailID, List<CriminalConvictionModel> criminalConvictionsToDelete)
        {
            if (criminalConvictionsToDelete == null)
                return BadRequest();

            //Make sure records exist
            var recordsToDelete = _criminalConvictionService.GetByStudentDetailID(studentDetailID);

            if (recordsToDelete is null)
                return NotFound();

            await _criminalConvictionService.DeleteMany(studentDetailID, criminalConvictionsToDelete);

            return AcceptedAtAction(nameof(DeleteMany), new { }, criminalConvictionsToDelete);
        }

        [HttpDelete("All/{studentDetailID}")]
        public async Task<IActionResult> DeleteAll(int? studentDetailID)
        {
            if (studentDetailID is null)
                return NotFound();

            await _criminalConvictionService.DeleteAll((int)studentDetailID);

            return NoContent();
        }
    }
}
