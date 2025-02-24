using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.AspNetCore.Authorization;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CriminalConvictionController : ControllerBase
    {
        private readonly CriminalConvictionService _criminalConvictionService;

        private ModelResultModel? _modelResult;

        public CriminalConvictionController(CriminalConvictionService criminalConvictionService)
        {
            _criminalConvictionService = criminalConvictionService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<CriminalConvictionModel>?> GetAll() =>
            _criminalConvictionService.GetAll();

        [Authorize]
        [HttpGet("{criminalConvictionID}")]
        public ActionResult<CriminalConvictionModel> Get(int criminalConvictionID)
        {
            var criminalConviction = _criminalConvictionService.Get(criminalConvictionID);

            if (criminalConviction == null)
                return NotFound();

            return criminalConviction;
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}/{studentGUID}")]
        public ActionResult<CriminalConvictionModel> Get(int? academicYearIDPart1, int? academicYearIDPart2, Guid studentGUID)
        {
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var criminalConviction = _criminalConvictionService.GetByGUID(academicYearID, studentGUID);

            if (criminalConviction == null)
                return NotFound();

            return criminalConviction;
        }

        [HttpGet("ID/{studentGUID}/{criminalConvictionID}")]
        public ActionResult<CriminalConvictionModel> GetByID(Guid studentGUID, int criminalConvictionID)
        {
            var criminalConviction = _criminalConvictionService.GetByGUIDAndID(studentGUID, criminalConvictionID);

            if (criminalConviction == null)
                return NotFound();

            return criminalConviction;
        }

        [Authorize]
        [HttpGet("StudentDetailID/{studentDetailID}")]
        public ActionResult<CriminalConvictionModel> GetByStudentDetailID(int studentDetailID)
        {
            var criminalConviction = _criminalConvictionService.GetByStudentDetailID(studentDetailID);

            if (criminalConviction == null)
                return NotFound();

            return criminalConviction;
        }

        [Authorize]
        [HttpGet("StudentRef/{academicYearID}/{studentRef}")]
        public ActionResult<CriminalConvictionModel> GetByStudentRef(string academicYearID, string studentRef)
        {
            var criminalConviction = _criminalConvictionService.GetByStudentRef(academicYearID, studentRef);

            if (criminalConviction == null)
                return NotFound();

            return criminalConviction;
        }

        [Authorize]
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

        [Authorize]
        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<CriminalConvictionModel> newcriminalConvictions)
        {
            _modelResult = await _criminalConvictionService.AddMany(newcriminalConvictions);

            var ids = string.Join(",", newcriminalConvictions.Select(t => t.CriminalConvictionID));

            return CreatedAtAction(nameof(Create), new { ids }, newcriminalConvictions);
        }

        [Authorize]
        [HttpPut("{criminalConvictionID}")]
        public async Task<IActionResult> Update(int criminalConvictionID, CriminalConvictionModel updatedCriminalConviction)
        {
            if (criminalConvictionID != updatedCriminalConviction.CriminalConvictionID)
                return BadRequest();

            var existingRecord = _criminalConvictionService.Get(criminalConvictionID);
            if (existingRecord is null)
                return NotFound();

            await _criminalConvictionService.Update(updatedCriminalConviction, true);

            return AcceptedAtAction(nameof(Update), new { }, updatedCriminalConviction);
        }

        [Authorize]
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

        [Authorize]
        [HttpDelete("{criminalConvictionID}")]
        public async Task<IActionResult> Delete(int criminalConvictionID)
        {
            var recordToDelete = _criminalConvictionService.Get(criminalConvictionID);

            if (recordToDelete is null)
                return NotFound();

            await _criminalConvictionService.Delete(criminalConvictionID);

            return AcceptedAtAction(nameof(Delete), new { }, recordToDelete);
        }

        [Authorize]
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

        [Authorize]
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
