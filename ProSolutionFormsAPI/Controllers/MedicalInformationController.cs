﻿using ProSolutionFormsAPI.Models;
using ProSolutionFormsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionFormsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalInformationController : ControllerBase
    {
        private readonly MedicalInformationService _medicalInformationService;

        public MedicalInformationController(MedicalInformationService medicalInformationService)
        {
            _medicalInformationService = medicalInformationService;
        }

        [HttpGet]
        public ActionResult<List<MedicalInformationModel>?> GetAll() =>
            _medicalInformationService.GetAll();

        [HttpGet("{medicalInformationID}")]
        public ActionResult<MedicalInformationModel> Get(int medicalInformationID)
        {
            var medicalInformation = _medicalInformationService.Get(medicalInformationID);

            if (medicalInformation == null)
                return NotFound();

            return medicalInformation;
        }

        [HttpGet("StudentDetailID/{medicalInformationID}")]
        public ActionResult<List<MedicalInformationModel>> GetByStudentDetailID(int studentDetailID)
        {
            var medicalInformations = _medicalInformationService.GetByStudentDetailID(studentDetailID);

            if (medicalInformations == null)
                return NotFound();

            return medicalInformations;
        }

        [HttpGet("StudentRef/{academicYearID}/{studentRef}")]
        public ActionResult<List<MedicalInformationModel>> GetByStudentRef(string academicYearID, string studentRef)
        {
            var medicalInformations = _medicalInformationService.GetByStudentRef(academicYearID, studentRef);

            if (medicalInformations == null)
                return NotFound();

            return medicalInformations;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicalInformationModel medicalInformation)
        {
            //Check this record is not already existing
            var existingRecord = _medicalInformationService.Get(medicalInformation.MedicalInformationID);

            if (existingRecord is not null)
                return BadRequest("Record Exists");

            await _medicalInformationService.Add(medicalInformation);

            return CreatedAtAction(nameof(Create), new { medicalInformationID = medicalInformation.MedicalInformationID }, medicalInformation);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(List<MedicalInformationModel> medicalInformations)
        {
            await _medicalInformationService.AddMany(medicalInformations);

            return CreatedAtAction(nameof(Create), new { medicalInformationID = medicalInformations[0].MedicalInformationID }, medicalInformations);
        }

        [HttpPut("{medicalInformationID}")]
        public async Task<IActionResult> Update(int medicalInformationID, MedicalInformationModel medicalInformation)
        {
            if (medicalInformationID != medicalInformation.MedicalInformationID)
                return BadRequest();

            var existingRecord = _medicalInformationService.Get(medicalInformationID);
            if (existingRecord is null)
                return NotFound();

            await _medicalInformationService.Update(medicalInformation);

            return NoContent();
        }

        [HttpDelete("{medicalInformationID}")]
        public async Task<IActionResult> Delete(int medicalInformationID)
        {
            var medicalInformation = _medicalInformationService.Get(medicalInformationID);

            if (medicalInformation is null)
                return NotFound();

            await _medicalInformationService.Delete(medicalInformationID);

            return NoContent();
        }
    }
}