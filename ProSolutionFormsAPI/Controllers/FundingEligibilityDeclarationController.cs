using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FundingEligibilityDeclarationController : ControllerBase
    {
        private readonly FundingEligibilityDeclarationService _fundingEligibilityDeclarationService;

        private ModelResultModel? _modelResult;

        public FundingEligibilityDeclarationController(FundingEligibilityDeclarationService fundingEligibilityDeclarationService)
        {
            _fundingEligibilityDeclarationService = fundingEligibilityDeclarationService;
        }

        [HttpGet]
        public ActionResult<List<FundingEligibilityDeclarationModel>?> GetAll() =>
            _fundingEligibilityDeclarationService.GetAll();

        [HttpGet("{fundingEligibilityDeclarationID}")]
        public ActionResult<FundingEligibilityDeclarationModel> Get(int fundingEligibilityDeclarationID)
        {
            var fundingEligibilityDeclaration = _fundingEligibilityDeclarationService.Get(fundingEligibilityDeclarationID);

            if (fundingEligibilityDeclaration == null)
                return NotFound();

            return fundingEligibilityDeclaration;
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}/{studentGUID}")]
        public ActionResult<FundingEligibilityDeclarationModel> Get(int? academicYearIDPart1, int? academicYearIDPart2, Guid studentGUID)
        {
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var fundingEligibilityDeclaration = _fundingEligibilityDeclarationService.GetByGUID(academicYearID, studentGUID);

            if (fundingEligibilityDeclaration == null)
                return NotFound();

            return fundingEligibilityDeclaration;
        }

        [HttpGet("ID/{studentGUID}/{fundingEligibilityDeclarationID}")]
        public ActionResult<FundingEligibilityDeclarationModel> GetByID(Guid studentGUID, int fundingEligibilityDeclarationID)
        {
            var fundingEligibilityDeclaration = _fundingEligibilityDeclarationService.GetByGUIDAndID(studentGUID, fundingEligibilityDeclarationID);

            if (fundingEligibilityDeclaration == null)
                return NotFound();

            return fundingEligibilityDeclaration;
        }

        [HttpGet("StudentDetailID/{studentDetailID}")]
        public ActionResult<FundingEligibilityDeclarationModel> GetByStudentDetailID(int studentDetailID)
        {
            var fundingEligibilityDeclaration = _fundingEligibilityDeclarationService.GetByStudentDetailID(studentDetailID);

            if (fundingEligibilityDeclaration == null)
                return NotFound();

            return fundingEligibilityDeclaration;
        }

        [HttpGet("StudentRef/{academicYearID}/{studentRef}")]
        public ActionResult<FundingEligibilityDeclarationModel> GetByStudentRef(string academicYearID, string studentRef)
        {
            var fundingEligibilityDeclaration = _fundingEligibilityDeclarationService.GetByStudentRef(academicYearID, studentRef);

            if (fundingEligibilityDeclaration == null)
                return NotFound();

            return fundingEligibilityDeclaration;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FundingEligibilityDeclarationModel newFundingEligibilityDeclaration)
        {
            //Check this record does not already exist
            var existingRecord = _fundingEligibilityDeclarationService.Get(newFundingEligibilityDeclaration.FundingEligibilityDeclarationID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            _modelResult = await _fundingEligibilityDeclarationService.Add(newFundingEligibilityDeclaration);

            return CreatedAtAction(nameof(Create), new { newFundingEligibilityDeclaration.FundingEligibilityDeclarationID }, newFundingEligibilityDeclaration);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<FundingEligibilityDeclarationModel> newFundingEligibilityDeclarations)
        {
            _modelResult = await _fundingEligibilityDeclarationService.AddMany(newFundingEligibilityDeclarations);

            var ids = string.Join(",", newFundingEligibilityDeclarations.Select(t => t.FundingEligibilityDeclarationID));

            return CreatedAtAction(nameof(Create), new { ids }, newFundingEligibilityDeclarations);
        }

        [HttpPut("{fundingEligibilityDeclarationID}")]
        public async Task<IActionResult> Update(int fundingEligibilityDeclarationID, FundingEligibilityDeclarationModel updatedFundingEligibilityDeclaration)
        {
            if (fundingEligibilityDeclarationID != updatedFundingEligibilityDeclaration.FundingEligibilityDeclarationID)
                return BadRequest();

            var existingRecord = _fundingEligibilityDeclarationService.Get(fundingEligibilityDeclarationID);
            if (existingRecord is null)
                return NotFound();

            await _fundingEligibilityDeclarationService.Update(updatedFundingEligibilityDeclaration, true);

            return AcceptedAtAction(nameof(Update), new { }, updatedFundingEligibilityDeclaration);
        }

        [HttpPut("Many/{studentDetailID}")]
        public async Task<IActionResult> UpdateMany(int studentDetailID, List<FundingEligibilityDeclarationModel> updatedFundingEligibilityDeclarations)
        {
            if (updatedFundingEligibilityDeclarations == null)
                return BadRequest();

            var existingRecords = _fundingEligibilityDeclarationService.GetByStudentDetailID(studentDetailID);
            if (existingRecords is null)
                return NotFound();

            await _fundingEligibilityDeclarationService.UpdateMany(studentDetailID, updatedFundingEligibilityDeclarations);

            return AcceptedAtAction(nameof(Update), new { }, updatedFundingEligibilityDeclarations);
        }

        [HttpDelete("{fundingEligibilityDeclarationID}")]
        public async Task<IActionResult> Delete(int fundingEligibilityDeclarationID)
        {
            var recordToDelete = _fundingEligibilityDeclarationService.Get(fundingEligibilityDeclarationID);

            if (recordToDelete is null)
                return NotFound();

            await _fundingEligibilityDeclarationService.Delete(fundingEligibilityDeclarationID);

            return AcceptedAtAction(nameof(Delete), new { }, recordToDelete);
        }

        [HttpDelete("Many/{studentDetailID}")]
        public async Task<IActionResult> DeleteMany(int studentDetailID, List<FundingEligibilityDeclarationModel> fundingEligibilityDeclarationsToDelete)
        {
            if (fundingEligibilityDeclarationsToDelete == null)
                return BadRequest();

            var recordsToDelete = _fundingEligibilityDeclarationService.GetByStudentDetailID(studentDetailID);

            if (recordsToDelete is null)
                return NotFound();

            await _fundingEligibilityDeclarationService.DeleteMany(studentDetailID, fundingEligibilityDeclarationsToDelete);

            return AcceptedAtAction(nameof(DeleteMany), new { }, fundingEligibilityDeclarationsToDelete);
        }

        [HttpDelete("All/{studentDetailID}")]
        public async Task<IActionResult> DeleteAll(int? studentDetailID)
        {
            if (studentDetailID is null)
                return NotFound();

            await _fundingEligibilityDeclarationService.DeleteAll((int)studentDetailID);

            return NoContent();
        }
    }
}
