using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalConditionTypeController : ControllerBase
    {
        private readonly MedicalConditionTypeService _medicalConditionTypeService;

        public MedicalConditionTypeController(MedicalConditionTypeService medicalConditionTypeService)
        {
            _medicalConditionTypeService = medicalConditionTypeService;
        }

        [HttpGet]
        public ActionResult<List<DropDownIntModel>?> GetAll() =>
            _medicalConditionTypeService.GetAll();

        [HttpGet("{code}")]
        public ActionResult<DropDownIntModel> Get(int code)
        {
            var dropDownValue = _medicalConditionTypeService.Get(code);

            if (dropDownValue == null)
                return NotFound();

            return dropDownValue;
        }
    }
}
