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
    public class InterviewHEController : ControllerBase
    {
        private readonly InterviewHEService _interviewHEService;

        private ModelResultModel? _modelResult;

        public InterviewHEController(InterviewHEService interviewHEService)
        {
            _interviewHEService = interviewHEService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<InterviewHEModel>?> GetAll() =>
            _interviewHEService.GetAll();

        [Authorize]
        [HttpGet("{interviewHEID}")]
        public ActionResult<InterviewHEModel> Get(int interviewHEID)
        {
            var interviewHE = _interviewHEService.Get(interviewHEID);

            if (interviewHE == null)
                return NotFound();

            return interviewHE;
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}/{studentGUID}")]
        public ActionResult<List<InterviewHEModel>> Get(int? academicYearIDPart1, int? academicYearIDPart2, Guid studentGUID)
        {
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var interviewsHE = _interviewHEService.GetByGUID(academicYearID, studentGUID);

            if (interviewsHE == null)
                return NotFound();

            return interviewsHE;
        }

        [HttpGet("ID/{studentGUID}/{interviewHEID}")]
        public ActionResult<InterviewHEModel> GetByID(Guid studentGUID, int interviewHEID)
        {
            var interviewHE = _interviewHEService.GetByGUIDAndID(studentGUID, interviewHEID);

            if (interviewHE == null)
                return NotFound();

            return interviewHE;
        }

        [Authorize]
        [HttpGet("StudentDetailID/{studentDetailID}")]
        public ActionResult<InterviewHEModel> GetByStudentDetailID(int studentDetailID)
        {
            var interviewHE = _interviewHEService.GetByStudentDetailID(studentDetailID);

            if (interviewHE == null)
                return NotFound();

            return interviewHE;
        }

        [Authorize]
        [HttpGet("StudentRef/{academicYearID}/{studentRef}")]
        public ActionResult<InterviewHEModel> GetByStudentRef(string academicYearID, string studentRef)
        {
            var interviewHE = _interviewHEService.GetByStudentRef(academicYearID, studentRef);

            if (interviewHE == null)
                return NotFound();

            return interviewHE;
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewHEModel newInterviewHE)
        {
            //Check this record does not already exist
            var existingRecord = _interviewHEService.Get(newInterviewHE.InterviewHEID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            _modelResult = await _interviewHEService.Add(newInterviewHE);

            return CreatedAtAction(nameof(Create), new { newInterviewHE.InterviewHEID }, newInterviewHE);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<InterviewHEModel> newInterviewHEs)
        {
            _modelResult = await _interviewHEService.AddMany(newInterviewHEs);

            var ids = string.Join(",", newInterviewHEs.Select(t => t.InterviewHEID));

            return CreatedAtAction(nameof(Create), new { ids }, newInterviewHEs);
        }

        [Authorize]
        [HttpPut("{interviewHEID}")]
        public async Task<IActionResult> Update(int interviewHEID, InterviewHEModel updatedInterviewHE)
        {
            if (interviewHEID != updatedInterviewHE.InterviewHEID)
                return BadRequest();

            var existingRecord = _interviewHEService.Get(interviewHEID);
            if (existingRecord is null)
                return NotFound();

            await _interviewHEService.Update(updatedInterviewHE, true);

            return AcceptedAtAction(nameof(Update), new { }, updatedInterviewHE);
        }

        [Authorize]
        [HttpPut("Many/{studentDetailID}")]
        public async Task<IActionResult> UpdateMany(int studentDetailID, List<InterviewHEModel> updatedInterviewHEs)
        {
            if (updatedInterviewHEs == null)
                return BadRequest();

            var existingRecords = _interviewHEService.GetByStudentDetailID(studentDetailID);
            if (existingRecords is null)
                return NotFound();

            await _interviewHEService.UpdateMany(studentDetailID, updatedInterviewHEs);

            return AcceptedAtAction(nameof(Update), new { }, updatedInterviewHEs);
        }

        [Authorize]
        [HttpDelete("{criminalConvictionID}")]
        public async Task<IActionResult> Delete(int interviewHEID)
        {
            var recordToDelete = _interviewHEService.Get(interviewHEID);

            if (recordToDelete is null)
                return NotFound();

            await _interviewHEService.Delete(interviewHEID);

            return AcceptedAtAction(nameof(Delete), new { }, recordToDelete);
        }

        [Authorize]
        [HttpDelete("Many/{studentDetailID}")]
        public async Task<IActionResult> DeleteMany(int studentDetailID, List<InterviewHEModel> interviewHEsToDelete)
        {
            if (interviewHEsToDelete == null)
                return BadRequest();

            //Make sure records exist
            var recordsToDelete = _interviewHEService.GetByStudentDetailID(studentDetailID);

            if (recordsToDelete is null)
                return NotFound();

            await _interviewHEService.DeleteMany(studentDetailID, interviewHEsToDelete);

            return AcceptedAtAction(nameof(DeleteMany), new { }, interviewHEsToDelete);
        }

        [Authorize]
        [HttpDelete("All/{studentDetailID}")]
        public async Task<IActionResult> DeleteAll(int? studentDetailID)
        {
            if (studentDetailID is null)
                return NotFound();

            await _interviewHEService.DeleteAll((int)studentDetailID);

            return NoContent();
        }
    }
}
