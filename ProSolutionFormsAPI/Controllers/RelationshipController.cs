using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelationshipController : ControllerBase
    {
        private readonly RelationshipService _relationshipService;

        public RelationshipController(RelationshipService relationshipService)
        {
            _relationshipService = relationshipService;
        }

        [HttpGet]
        public ActionResult<List<DropDownIntModel>?> GetAll() =>
            _relationshipService.GetAll();

        [HttpGet("{code}")]
        public ActionResult<DropDownIntModel> Get(int code)
        {
            var dropDownValue = _relationshipService.Get(code);

            if (dropDownValue == null)
                return NotFound();

            return dropDownValue;
        }
    }
}
