using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using Microsoft.Graph;

namespace ProSolutionFormsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class StudentDetailController : ControllerBase
    {
        private readonly StudentDetailService _studentDetailService;
        private readonly ILogger<StudentDetailController> _logger;
        private readonly GraphServiceClient _graphServiceClient;

        public StudentDetailController(StudentDetailService studentDetailService, ILogger<StudentDetailController> logger, GraphServiceClient graphServiceClient)
        {
            _studentDetailService = studentDetailService;
            _logger = logger;
            _graphServiceClient = graphServiceClient;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDetailModel>?>> GetAll()
        {
            var user = await _graphServiceClient.Me.Request().GetAsync();

            return _studentDetailService.GetAll();
        }
            

        [HttpGet("{studentRef}")]
        public async Task<ActionResult<StudentDetailModel>> Get(string studentRef)
        {
            var user = await _graphServiceClient.Me.Request().GetAsync();

            var studentDetail = _studentDetailService.Get(studentRef);

            if (studentDetail == null)
                return NotFound();

            return studentDetail;
        }

        [HttpGet("{academicYearIDPart1}/{academicYearIDPart2}/{studentRef}")]
        public async Task<ActionResult<StudentDetailModel>> Get(int? academicYearIDPart1, int? academicYearIDPart2, string studentRef)
        {
            var user = await _graphServiceClient.Me.Request().GetAsync();

            string academicYearID;
            if (academicYearIDPart1 != null && academicYearIDPart2 != null)
                academicYearID = $"{academicYearIDPart1.ToString()}/{academicYearIDPart2.ToString()}";
            else
                return NotFound();

            var studentDetail = _studentDetailService.Get(academicYearID, studentRef);

            if (studentDetail == null)
                return NotFound();

            return studentDetail;
        }
    }
}
