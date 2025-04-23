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
    public class OfferHEController : ControllerBase
    {
        private readonly OfferHEService _offerHEService;

        private ModelResultModel? _modelResult;

        public OfferHEController(OfferHEService offerHEService)
        {
            _offerHEService = offerHEService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<OfferHEModel>?> GetAll() =>
            _offerHEService.GetAll();

        [Authorize]
        [HttpGet("{offerHEID}")]
        public ActionResult<OfferHEModel> Get(int offerHEID)
        {
            var offerHE = _offerHEService.Get(offerHEID);

            if (offerHE == null)
                return NotFound();

            return offerHE;
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}/{studentGUID}")]
        public ActionResult<List<OfferHEModel>> Get(int? academicYearIDPart1, int? academicYearIDPart2, Guid studentGUID)
        {
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var offersHE = _offerHEService.GetByGUID(academicYearID, studentGUID);

            if (offersHE == null)
                return NotFound();

            return offersHE;
        }

        [HttpGet("ID/{studentGUID}/{offerHEID}")]
        public ActionResult<OfferHEModel> GetByID(Guid studentGUID, int offerHEID)
        {
            var offerHE = _offerHEService.GetByGUIDAndID(studentGUID, offerHEID);

            if (offerHE == null)
                return NotFound();

            return offerHE;
        }

        [HttpGet("ApplicationCourse/{studentGUID}/{applicationCourseID}")]
        public ActionResult<OfferHEModel> GetByApplicationCourse(Guid studentGUID, int applicationCourseID)
        {
            var offerHE = _offerHEService.GetByGUIDAndApplicationCourse(studentGUID, applicationCourseID);

            if (offerHE == null)
                return NotFound();

            return offerHE;
        }

        [HttpGet("ApplicationCourse/{academicYearIDPart1}/{academicYearIDPart2}/{studentGUID}/{applicationCourseID}")]
        public ActionResult<OfferHEModel> GetByApplicationCourse(int? academicYearIDPart1, int? academicYearIDPart2, Guid studentGUID, int applicationCourseID)
        {
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var offerHE = _offerHEService.GetByGUIDYearAndApplicationCourse(academicYearID, studentGUID, applicationCourseID);

            if (offerHE == null)
                return NotFound();

            return offerHE;
        }

        [Authorize]
        [HttpGet("StudentDetailID/{studentDetailID}")]
        public ActionResult<OfferHEModel> GetByStudentDetailID(int studentDetailID)
        {
            var offerHE = _offerHEService.GetByStudentDetailID(studentDetailID);

            if (offerHE == null)
                return NotFound();

            return offerHE;
        }

        [Authorize]
        [HttpGet("StudentRef/{academicYearID}/{studentRef}")]
        public ActionResult<OfferHEModel> GetByStudentRef(string academicYearID, string studentRef)
        {
            var offerHE = _offerHEService.GetByStudentRef(academicYearID, studentRef);

            if (offerHE == null)
                return NotFound();

            return offerHE;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OfferHEModel newOfferHE)
        {
            //Check this record does not already exist
            var existingRecord = _offerHEService.Get(newOfferHE.OfferHEID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            _modelResult = await _offerHEService.Add(newOfferHE);

            return CreatedAtAction(nameof(Create), new { newOfferHE.OfferHEID }, newOfferHE);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<OfferHEModel> newOfferHEs)
        {
            _modelResult = await _offerHEService.AddMany(newOfferHEs);

            var ids = string.Join(",", newOfferHEs.Select(t => t.OfferHEID));

            return CreatedAtAction(nameof(Create), new { ids }, newOfferHEs);
        }

        [Authorize]
        [HttpPut("{offerHEID}")]
        public async Task<IActionResult> Update(int offerHEID, OfferHEModel updatedOfferHE)
        {
            if (offerHEID != updatedOfferHE.OfferHEID)
                return BadRequest();

            var existingRecord = _offerHEService.Get(offerHEID);
            if (existingRecord is null)
                return NotFound();

            await _offerHEService.Update(updatedOfferHE, true);

            return AcceptedAtAction(nameof(Update), new { }, updatedOfferHE);
        }

        [Authorize]
        [HttpPut("Many/{studentDetailID}")]
        public async Task<IActionResult> UpdateMany(int studentDetailID, List<OfferHEModel> updatedOfferHEs)
        {
            if (updatedOfferHEs == null)
                return BadRequest();

            var existingRecords = _offerHEService.GetByStudentDetailID(studentDetailID);
            if (existingRecords is null)
                return NotFound();

            await _offerHEService.UpdateMany(studentDetailID, updatedOfferHEs);

            return AcceptedAtAction(nameof(Update), new { }, updatedOfferHEs);
        }

        [Authorize]
        [HttpDelete("{criminalConvictionID}")]
        public async Task<IActionResult> Delete(int offerHEID)
        {
            var recordToDelete = _offerHEService.Get(offerHEID);

            if (recordToDelete is null)
                return NotFound();

            await _offerHEService.Delete(offerHEID);

            return AcceptedAtAction(nameof(Delete), new { }, recordToDelete);
        }

        [Authorize]
        [HttpDelete("Many/{studentDetailID}")]
        public async Task<IActionResult> DeleteMany(int studentDetailID, List<OfferHEModel> offerHEsToDelete)
        {
            if (offerHEsToDelete == null)
                return BadRequest();

            //Make sure records exist
            var recordsToDelete = _offerHEService.GetByStudentDetailID(studentDetailID);

            if (recordsToDelete is null)
                return NotFound();

            await _offerHEService.DeleteMany(studentDetailID, offerHEsToDelete);

            return AcceptedAtAction(nameof(DeleteMany), new { }, offerHEsToDelete);
        }

        [Authorize]
        [HttpDelete("All/{studentDetailID}")]
        public async Task<IActionResult> DeleteAll(int? studentDetailID)
        {
            if (studentDetailID is null)
                return NotFound();

            await _offerHEService.DeleteAll((int)studentDetailID);

            return NoContent();
        }
    }
}
