using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeeExemptionReasonController : ControllerBase
    {
        private readonly FeeExemptionReasonService _feeExemptionReasonService;

        public FeeExemptionReasonController(FeeExemptionReasonService feeExemptionReasonService)
        {
            _feeExemptionReasonService = feeExemptionReasonService;
        }

        [HttpGet]
        public ActionResult<List<DropDownIntModel>?> GetAll() =>
            _feeExemptionReasonService.GetAll();

        [HttpGet("{code}")]
        public ActionResult<DropDownIntModel> Get(int code)
        {
            var dropDownValue = _feeExemptionReasonService.Get(code);

            if (dropDownValue == null)
                return NotFound();

            return dropDownValue;
        }
    }
}
