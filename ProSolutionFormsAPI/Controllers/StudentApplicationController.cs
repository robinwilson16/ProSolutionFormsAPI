using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using Microsoft.Graph;

namespace ProSolutionFormsAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class StudentApplicationController : ControllerBase
    {
        private readonly StudentApplicationService _studentApplicationService;
        private readonly ILogger<StudentDetailController> _logger;
        private readonly GraphServiceClient _graphServiceClient;

        public StudentApplicationController(StudentApplicationService studentApplicationService, ILogger<StudentDetailController> logger, GraphServiceClient graphServiceClient)
        {
            _studentApplicationService = studentApplicationService;
            _logger = logger;
            _graphServiceClient = graphServiceClient;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentApplicationModel>?>> GetAll()
        {
            //var user = await _graphServiceClient.Me.Request().GetAsync();

            return _studentApplicationService.GetAll();
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}")]
        public async Task<ActionResult<List<StudentApplicationModel>?>> Get(int? academicYearIDPart1, int? academicYearIDPart2)
        {
            //var user = await _graphServiceClient.Me.Request().GetAsync();

            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var studentApplications = _studentApplicationService.Get(academicYearID);

            if (studentApplications == null)
                return NotFound();

            return studentApplications;
        }


        [HttpGet("{studentRef}")]
        public async Task<ActionResult<List<StudentApplicationModel>?>> Get(string studentRef)
        {
            //var user = await _graphServiceClient.Me.Request().GetAsync();

            var studentApplications = _studentApplicationService.GetByStudent(studentRef);

            if (studentApplications == null)
                return NotFound();

            return studentApplications;
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}/{studentRef}")]
        public async Task<ActionResult<List<StudentApplicationModel>?>> Get(int? academicYearIDPart1, int? academicYearIDPart2, string studentRef)
        {
            //var user = await _graphServiceClient.Me.Request().GetAsync();

            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var studentApplications = _studentApplicationService.Get(academicYearID, studentRef);

            if (studentApplications == null)
                return NotFound();

            return studentApplications;
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}/{studentRef}/{applicationCourseID}")]
        public async Task<ActionResult<StudentApplicationModel?>> Get(int? academicYearIDPart1, int? academicYearIDPart2, string studentRef, int? applicationCourseID)
        {
            //var user = await _graphServiceClient.Me.Request().GetAsync();
            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            if (applicationCourseID == null)
                return NotFound();

            var studentApplication = _studentApplicationService.Get(academicYearID, studentRef, applicationCourseID);

            if (studentApplication == null)
                return NotFound();

            return studentApplication;
        }
    }
}
