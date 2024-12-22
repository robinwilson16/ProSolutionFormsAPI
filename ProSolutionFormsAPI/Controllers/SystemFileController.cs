using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemFileController : ControllerBase
    {
        private readonly SystemFileService _systemFileService;

        public SystemFileController(SystemFileService systemFileService)
        {
            _systemFileService = systemFileService;
        }

        [HttpGet]
        public ActionResult<List<SystemFileModel>?> GetAll() =>
            _systemFileService.GetAll();

        [HttpGet("{systemFileID}")]
        public ActionResult<SystemFileModel> Get(int systemFileID)
        {
            var systemFile = _systemFileService.Get(systemFileID);

            if (systemFile == null)
                return NotFound();

            return systemFile;
        }

        

        [HttpPost]
        public async Task<IActionResult> Create(SystemFileModel systemFile)
        {
            //Check this record does not already exist
            var existingRecord = _systemFileService.Get(systemFile.SystemFileID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            await _systemFileService.Add(systemFile);

            return CreatedAtAction(nameof(Create), new { systemFileID = systemFile.SystemFileID }, systemFile);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<SystemFileModel> systemFiles)
        {
            await _systemFileService.AddMany(systemFiles);

            return CreatedAtAction(nameof(Create), new { systemFileID = systemFiles[0].SystemFileID }, systemFiles);
        }
    }
}
