using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemUserController : ControllerBase
    {
        private readonly SystemUserService _systemUserService;
        private readonly IConfiguration _configuration;

        public SystemUserController(SystemUserService systemUserService, IConfiguration configuration)
        {
            _systemUserService = systemUserService;
            _configuration = configuration;
        }

        [HttpGet("{accessToken}")]
        public async Task<ActionResult<SystemUserModel>> Get(string accessToken)
        {
            var systemUser = await _systemUserService.Get(accessToken);

            if (systemUser == null)
                return NotFound();

            return systemUser;
        }
    }
}
