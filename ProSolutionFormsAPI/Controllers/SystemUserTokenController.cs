using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemUserTokenController : ControllerBase
    {
        private readonly SystemUserTokenService _systemUserTokenService;
        private readonly IConfiguration _configuration;

        public SystemUserTokenController(SystemUserTokenService systemUserTokenService, IConfiguration configuration)
        {
            _systemUserTokenService = systemUserTokenService;
            _configuration = configuration;
        }

        [HttpGet("{codeToken}")]
        public async Task<ActionResult<SystemUserTokenModel>> Get(string codeToken)
        {
            var systemUserToken = await _systemUserTokenService.Get(codeToken);

            if (systemUserToken == null)
                return NotFound();

            return systemUserToken;
        }
    }
}
