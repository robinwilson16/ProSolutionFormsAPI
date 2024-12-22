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

        public FundingEligibilityDeclarationController(FundingEligibilityDeclarationService fundingEligibilityDeclarationService)
        {
            _fundingEligibilityDeclarationService = fundingEligibilityDeclarationService;
        }

        [HttpGet]
        public ActionResult<List<FundingEligibilityDeclarationModel>?> GetAll() =>
            _fundingEligibilityDeclarationService.GetAll();

        [HttpGet("{criminalConvictionID}")]
        public ActionResult<FundingEligibilityDeclarationModel> Get(int fundingEligibilityDeclarationID)
        {
            var fundingEligibilityDeclaration = _fundingEligibilityDeclarationService.Get(fundingEligibilityDeclarationID);

            if (fundingEligibilityDeclaration == null)
                return NotFound();

            return fundingEligibilityDeclaration;
        }

        [HttpGet("StudentDetailID/{fundingEligibilityDeclarationID}")]
        public ActionResult<List<FundingEligibilityDeclarationModel>> GetByStudentDetailID(int studentDetailID)
        {
            var fundingEligibilityDeclarations = _fundingEligibilityDeclarationService.GetByStudentDetailID(studentDetailID);

            if (fundingEligibilityDeclarations == null)
                return NotFound();

            return fundingEligibilityDeclarations;
        }

        [HttpGet("StudentRef/{academicYearID}/{studentRef}")]
        public ActionResult<List<FundingEligibilityDeclarationModel>> GetByStudentRef(string academicYearID, string studentRef)
        {
            var fundingEligibilityDeclarations = _fundingEligibilityDeclarationService.GetByStudentRef(academicYearID, studentRef);

            if (fundingEligibilityDeclarations == null)
                return NotFound();

            return fundingEligibilityDeclarations;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FundingEligibilityDeclarationModel fundingEligibilityDeclaration)
        {
            //Check this record does not already exist
            var existingRecord = _fundingEligibilityDeclarationService.Get(fundingEligibilityDeclaration.FundingEligibilityDeclarationID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            await _fundingEligibilityDeclarationService.Add(fundingEligibilityDeclaration);

            return CreatedAtAction(nameof(Create), new { fundingEligibilityDeclarationID = fundingEligibilityDeclaration.FundingEligibilityDeclarationID }, fundingEligibilityDeclaration);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<FundingEligibilityDeclarationModel> fundingEligibilityDeclarations)
        {
            await _fundingEligibilityDeclarationService.AddMany(fundingEligibilityDeclarations);

            return CreatedAtAction(nameof(Create), new { criminalConvictionID = fundingEligibilityDeclarations[0].FundingEligibilityDeclarationID }, fundingEligibilityDeclarations);
        }

        [HttpPut("{criminalConvictionID}")]
        public async Task<IActionResult> Update(int fundingEligibilityDeclarationID, FundingEligibilityDeclarationModel fundingEligibilityDeclaration)
        {
            if (fundingEligibilityDeclarationID != fundingEligibilityDeclaration.FundingEligibilityDeclarationID)
                return BadRequest();

            var existingRecord = _fundingEligibilityDeclarationService.Get(fundingEligibilityDeclarationID);
            if (existingRecord is null)
                return NotFound();

            await _fundingEligibilityDeclarationService.Update(fundingEligibilityDeclaration);

            return NoContent();
        }

        [HttpPut("Many/{studentDetailID}")]
        public async Task<IActionResult> UpdateMany(int studentDetailID, List<FundingEligibilityDeclarationModel> fundingEligibilityDeclarations)
        {
            if (fundingEligibilityDeclarations == null)
                return BadRequest();

            var existingRecords = _fundingEligibilityDeclarationService.GetByStudentDetailID(studentDetailID);
            if (existingRecords is null)
                return NotFound();

            await _fundingEligibilityDeclarationService.UpdateMany(studentDetailID, fundingEligibilityDeclarations);

            return NoContent();
        }

        [HttpDelete("{fundingEligibilityDeclarationID}")]
        public async Task<IActionResult> Delete(int fundingEligibilityDeclarationID)
        {
            var fundingEligibilityDeclaration = _fundingEligibilityDeclarationService.Get(fundingEligibilityDeclarationID);

            if (fundingEligibilityDeclaration is null)
                return NotFound();

            await _fundingEligibilityDeclarationService.Delete(fundingEligibilityDeclarationID);

            return NoContent();
        }

        [HttpDelete("Many/{studentDetailID}")]
        public async Task<IActionResult> DeleteMany(int studentDetailID, List<FundingEligibilityDeclarationModel> fundingEligibilityDeclarations)
        {
            var existingRecords = _fundingEligibilityDeclarationService.GetByStudentDetailID(studentDetailID);

            if (existingRecords is null)
                return NotFound();

            await _fundingEligibilityDeclarationService.DeleteMany(studentDetailID, fundingEligibilityDeclarations);

            return NoContent();
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
