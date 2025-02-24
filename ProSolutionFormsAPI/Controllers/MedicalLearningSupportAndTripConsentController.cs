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
    public class MedicalLearningSupportAndTripConsentController : ControllerBase
    {
        private readonly MedicalLearningSupportAndTripConsentService _medicalLearningSupportAndTripConsentService;

        private ModelResultModel? _modelResult;

        public MedicalLearningSupportAndTripConsentController(MedicalLearningSupportAndTripConsentService medicalLearningSupportAndTripConsentService)
        {
            _medicalLearningSupportAndTripConsentService = medicalLearningSupportAndTripConsentService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<MedicalLearningSupportAndTripConsentModel>?> GetAll() =>
            _medicalLearningSupportAndTripConsentService.GetAll();

        [Authorize]
        [HttpGet("{medicalLearningSupportAndTripConsentID}")]
        public ActionResult<MedicalLearningSupportAndTripConsentModel> Get(int medicalLearningSupportAndTripConsentID)
        {
            var medicalLearningSupportAndTripConsent = _medicalLearningSupportAndTripConsentService.Get(medicalLearningSupportAndTripConsentID);

            if (medicalLearningSupportAndTripConsent == null)
                return NotFound();

            return medicalLearningSupportAndTripConsent;
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}/{studentGUID}")]
        public ActionResult<MedicalLearningSupportAndTripConsentModel> Get(int? academicYearIDPart1, int? academicYearIDPart2, Guid studentGUID)
        {
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var medicalLearningSupportAndTripConsents = _medicalLearningSupportAndTripConsentService.GetByGUID(academicYearID, studentGUID);

            if (medicalLearningSupportAndTripConsents == null)
                return NotFound();

            return medicalLearningSupportAndTripConsents;
        }

        [HttpGet("ID/{studentGUID}/{medicalLearningSupportAndTripConsentID}")]
        public ActionResult<MedicalLearningSupportAndTripConsentModel> GetByID(Guid studentGUID, int medicalLearningSupportAndTripConsentID)
        {
            var medicalLearningSupportAndTripConsents = _medicalLearningSupportAndTripConsentService.GetByGUIDAndID(studentGUID, medicalLearningSupportAndTripConsentID);

            if (medicalLearningSupportAndTripConsents == null)
                return NotFound();

            return medicalLearningSupportAndTripConsents;
        }

        [Authorize]
        [HttpGet("StudentDetailID/{studentDetailID}")]
        public ActionResult<MedicalLearningSupportAndTripConsentModel> GetByStudentDetailID(int studentDetailID)
        {
            var medicalLearningSupportAndTripConsent = _medicalLearningSupportAndTripConsentService.GetByStudentDetailID(studentDetailID);

            if (medicalLearningSupportAndTripConsent == null)
                return NotFound();

            return medicalLearningSupportAndTripConsent;
        }

        [Authorize]
        [HttpGet("StudentRef/{academicYearIDPart1}/{academicYearIDPart2}/{studentRef}")]
        public ActionResult<MedicalLearningSupportAndTripConsentModel> GetByStudentRef(int? academicYearIDPart1, int? academicYearIDPart2, string studentRef)
        {
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var medicalLearningSupportAndTripConsent = _medicalLearningSupportAndTripConsentService.GetByStudentRef(academicYearID, studentRef);

            if (medicalLearningSupportAndTripConsent == null)
                return NotFound();

            return medicalLearningSupportAndTripConsent;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(MedicalLearningSupportAndTripConsentModel newMedicalLearningSupportAndTripConsent)
        {
            //Check this record does not already exist
            var existingRecord = _medicalLearningSupportAndTripConsentService.Get(newMedicalLearningSupportAndTripConsent.MedicalLearningSupportAndTripConsentID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            _modelResult = await _medicalLearningSupportAndTripConsentService.Add(newMedicalLearningSupportAndTripConsent);

            return CreatedAtAction(nameof(Create), new { newMedicalLearningSupportAndTripConsent.MedicalLearningSupportAndTripConsentID }, newMedicalLearningSupportAndTripConsent);
        }

        [Authorize]
        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<MedicalLearningSupportAndTripConsentModel> newMedicalLearningSupportAndTripConsents)
        {
            _modelResult = await _medicalLearningSupportAndTripConsentService.AddMany(newMedicalLearningSupportAndTripConsents);

            var ids = string.Join(",", newMedicalLearningSupportAndTripConsents.Select(t => t.MedicalLearningSupportAndTripConsentID));

            return CreatedAtAction(nameof(Create), new { ids }, newMedicalLearningSupportAndTripConsents);
        }

        [Authorize]
        [HttpPut("{medicalLearningSupportAndTripConsentID}")]
        public async Task<IActionResult> Update(int medicalLearningSupportAndTripConsentID, MedicalLearningSupportAndTripConsentModel updatedMedicalLearningSupportAndTripConsent)
        {
            if (medicalLearningSupportAndTripConsentID != updatedMedicalLearningSupportAndTripConsent.MedicalLearningSupportAndTripConsentID)
                return BadRequest();

            var existingRecord = _medicalLearningSupportAndTripConsentService.Get(medicalLearningSupportAndTripConsentID);
            if (existingRecord is null)
                return NotFound();

            await _medicalLearningSupportAndTripConsentService.Update(updatedMedicalLearningSupportAndTripConsent, true);

            return AcceptedAtAction(nameof(Update), new { }, updatedMedicalLearningSupportAndTripConsent);
        }

        [Authorize]
        [HttpPut("Many/{studentDetailID}")]
        public async Task<IActionResult> UpdateMany(int studentDetailID, List<MedicalLearningSupportAndTripConsentModel> updatedMedicalLearningSupportAndTripConsents)
        {
            if (updatedMedicalLearningSupportAndTripConsents == null)
                return BadRequest();

            var existingRecords = _medicalLearningSupportAndTripConsentService.GetByStudentDetailID(studentDetailID);
            if (existingRecords is null)
                return NotFound();

            await _medicalLearningSupportAndTripConsentService.UpdateMany(studentDetailID, updatedMedicalLearningSupportAndTripConsents);

            return AcceptedAtAction(nameof(Update), new { }, updatedMedicalLearningSupportAndTripConsents);
        }

        [Authorize]
        [HttpDelete("{medicalLearningSupportAndTripConsentID}")]
        public async Task<IActionResult> Delete(int medicalLearningSupportAndTripConsentID)
        {
            var recordToDelete = _medicalLearningSupportAndTripConsentService.Get(medicalLearningSupportAndTripConsentID);

            if (recordToDelete is null)
                return NotFound();

            await _medicalLearningSupportAndTripConsentService.Delete(medicalLearningSupportAndTripConsentID);

            return AcceptedAtAction(nameof(Delete), new { }, recordToDelete);
        }

        [Authorize]
        [HttpDelete("Many/{studentDetailID}")]
        public async Task<IActionResult> DeleteMany(int studentDetailID, List<MedicalLearningSupportAndTripConsentModel> medicalLearningSupportAndTripConsentsToDelete)
        {
            if (medicalLearningSupportAndTripConsentsToDelete == null)
                return BadRequest();

            //Make sure records exist
            var recordsToDelete = _medicalLearningSupportAndTripConsentService.GetByStudentDetailID(studentDetailID);

            if (recordsToDelete is null)
                return NotFound();

            await _medicalLearningSupportAndTripConsentService.DeleteMany(studentDetailID, medicalLearningSupportAndTripConsentsToDelete);

            return AcceptedAtAction(nameof(DeleteMany), new { }, medicalLearningSupportAndTripConsentsToDelete);
        }

        [Authorize]
        [HttpDelete("All/{studentDetailID}")]
        public async Task<IActionResult> DeleteAll(int? studentDetailID)
        {
            if (studentDetailID is null)
                return NotFound();

            await _medicalLearningSupportAndTripConsentService.DeleteAll((int)studentDetailID);

            return NoContent();
        }
    }
}
