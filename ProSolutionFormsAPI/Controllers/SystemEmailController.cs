﻿using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemEmailController : ControllerBase
    {
        private readonly SystemEmailService _systemEmailService;
        private readonly IConfiguration _configuration;

        public SystemEmailController(SystemEmailService systemEmailService, IConfiguration configuration)
        {
            _systemEmailService = systemEmailService;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<List<SystemEmailModel>?> GetAll() =>
            _systemEmailService.GetAll();

        [HttpGet("{systemFileID}")]
        public ActionResult<SystemEmailModel> Get(int systemEmailID)
        {
            var systemEmail = _systemEmailService.Get(systemEmailID);

            if (systemEmail == null)
                return NotFound();

            return systemEmail;
        }

        

        [HttpPost]
        public async Task<IActionResult> Send(SystemEmailModel systemEmail)
        {
            //Check this record does not already exist
            var existingRecord = _systemEmailService.Get(systemEmail.SystemEmailID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            string? emailKey = _configuration.GetSection("Settings")["EmailKey"];

            if (emailKey != systemEmail.EmailKey)
                return Unauthorized("Email Key not valid");

            SystemEmailModel SystemEmail = new SystemEmailModel();
            SystemEmail = await _systemEmailService.SendEmail(systemEmail);

            return CreatedAtAction(nameof(Send), new { }, SystemEmail);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> SendMany(List<SystemEmailModel> systemEmails)
        {
            await _systemEmailService.SendEmails(systemEmails);

            return CreatedAtAction(nameof(Send), new { systemEmailID = systemEmails[0].SystemEmailID }, systemEmails);
        }
    }
}