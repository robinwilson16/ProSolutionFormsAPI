using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisabilityCategoryController : ControllerBase
    {
        private readonly DisabilityCategoryService _disabilityCategoryService;

        public DisabilityCategoryController(DisabilityCategoryService disabilityCategoryService)
        {
            _disabilityCategoryService = disabilityCategoryService;
        }

        [HttpGet]
        public ActionResult<List<DropDownIntModel>?> GetAll() =>
            _disabilityCategoryService.GetAll();

        [HttpGet("{code}")]
        public ActionResult<DropDownIntModel> Get(int code)
        {
            var dropDownValue = _disabilityCategoryService.Get(code);

            if (dropDownValue == null)
                return NotFound();

            return dropDownValue;
        }
    }
}
