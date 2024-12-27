using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalInformationController : ControllerBase
    {
        private readonly MedicalInformationService _medicalInformationService;

        private ModelResultModel? _modelResult;

        public MedicalInformationController(MedicalInformationService medicalInformationService)
        {
            _medicalInformationService = medicalInformationService;
        }

        [HttpGet]
        public ActionResult<List<MedicalInformationModel>?> GetAll() =>
            _medicalInformationService.GetAll();

        [HttpGet("{medicalInformationID}")]
        public ActionResult<MedicalInformationModel> Get(int medicalInformationID)
        {
            var medicalInformation = _medicalInformationService.Get(medicalInformationID);

            if (medicalInformation == null)
                return NotFound();

            return medicalInformation;
        }

        [HttpGet("StudentDetailID/{medicalInformationID}")]
        public ActionResult<List<MedicalInformationModel>> GetByStudentDetailID(int studentDetailID)
        {
            var medicalInformations = _medicalInformationService.GetByStudentDetailID(studentDetailID);

            if (medicalInformations == null)
                return NotFound();

            return medicalInformations;
        }

        [HttpGet("StudentRef/{academicYearID}/{studentRef}")]
        public ActionResult<List<MedicalInformationModel>> GetByStudentRef(string academicYearID, string studentRef)
        {
            var medicalInformations = _medicalInformationService.GetByStudentRef(academicYearID, studentRef);

            if (medicalInformations == null)
                return NotFound();

            return medicalInformations;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicalInformationModel newMedicalInformation)
        {
            //Check this record does not already exist
            var existingRecord = _medicalInformationService.Get(newMedicalInformation.MedicalInformationID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            await _medicalInformationService.Add(newMedicalInformation);

            return CreatedAtAction(nameof(Create), new { newMedicalInformation.MedicalInformationID }, newMedicalInformation);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<MedicalInformationModel> newMedicalInformations)
        {
            await _medicalInformationService.AddMany(newMedicalInformations);

            var ids = string.Join(",", newMedicalInformations.Select(t => t.MedicalInformationID));

            return CreatedAtAction(nameof(Create), new { ids }, newMedicalInformations);
        }

        [HttpPut("{medicalInformationID}")]
        public async Task<IActionResult> Update(int medicalInformationID, MedicalInformationModel updatedMedicalInformation)
        {
            if (medicalInformationID != updatedMedicalInformation.MedicalInformationID)
                return BadRequest();

            var existingRecord = _medicalInformationService.Get(medicalInformationID);
            if (existingRecord is null)
                return NotFound();

            await _medicalInformationService.Update(updatedMedicalInformation);

            return AcceptedAtAction(nameof(Update), new { }, updatedMedicalInformation);
        }

        [HttpPut("Many/{studentDetailID}")]
        public async Task<IActionResult> UpdateMany(int studentDetailID, List<MedicalInformationModel> updatedMedicalInformations)
        {
            if (updatedMedicalInformations == null)
                return BadRequest();

            var existingRecords = _medicalInformationService.GetByStudentDetailID(studentDetailID);
            if (existingRecords is null)
                return NotFound();

            await _medicalInformationService.UpdateMany(studentDetailID, updatedMedicalInformations);

            return AcceptedAtAction(nameof(Update), new { }, updatedMedicalInformations);
        }

        [HttpDelete("{medicalInformationID}")]
        public async Task<IActionResult> Delete(int medicalInformationID)
        {
            var recordToDelete = _medicalInformationService.Get(medicalInformationID);

            if (recordToDelete is null)
                return NotFound();

            await _medicalInformationService.Delete(medicalInformationID);

            return AcceptedAtAction(nameof(Delete), new { }, recordToDelete);
        }

        [HttpDelete("Many/{studentDetailID}")]
        public async Task<IActionResult> DeleteMany(int studentDetailID, List<MedicalInformationModel> medicalInformationsToDelete)
        {
            if (medicalInformationsToDelete == null)
                return BadRequest();

            //Make sure records exist
            var recordsToDelete = _medicalInformationService.GetByStudentDetailID(studentDetailID);

            if (recordsToDelete is null)
                return NotFound();

            await _medicalInformationService.DeleteMany(studentDetailID, medicalInformationsToDelete);

            return AcceptedAtAction(nameof(DeleteMany), new { }, medicalInformationsToDelete);
        }

        [HttpDelete("All/{studentDetailID}")]
        public async Task<IActionResult> DeleteAll(int? studentDetailID)
        {
            if (studentDetailID is null)
                return NotFound();

            await _medicalInformationService.DeleteAll((int)studentDetailID);

            return NoContent();
        }
    }
}
