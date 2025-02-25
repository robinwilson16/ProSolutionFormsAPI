using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcademicYearController : ControllerBase
    {
        private readonly AcademicYearService _academicYearService;

        public AcademicYearController(AcademicYearService academicYearService)
        {
            _academicYearService = academicYearService;
        }

        [HttpGet]
        public ActionResult<List<DropDownStringModel>?> GetAll() =>
            _academicYearService.GetAll();

        [HttpGet("{code}")]
        public ActionResult<DropDownStringModel> Get(string code)
        {
            var dropDownValue = _academicYearService.Get(code);

            if (dropDownValue == null)
                return NotFound();

            return dropDownValue;
        }
    }
}
