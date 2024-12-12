using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TitleController : ControllerBase
    {
        private readonly TitleService _titleService;

        public TitleController(TitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public ActionResult<List<DropDownStringModel>?> GetAll() =>
            _titleService.GetAll();

        [HttpGet("{code}")]
        public ActionResult<DropDownStringModel> Get(string code)
        {
            var dropDownValue = _titleService.Get(code);

            if (dropDownValue == null)
                return NotFound();

            return dropDownValue;
        }
    }
}
