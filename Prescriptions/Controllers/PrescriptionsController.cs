using Microsoft.AspNetCore.Mvc;
using Prescriptions.DTOs;
using Prescriptions.Services;

namespace Prescriptions.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] NewPrescriptionDto prescription)
    {
        try
        {
            var prescriptionId = await _dbService.CreatePrescriptionAsync(prescription);
            return Created($"/api/prescriptions/{prescriptionId}", new { IdPrescription = prescriptionId });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    
    [HttpGet("{idPatient}")]
    public async Task<IActionResult> GetPatientDetails(int idPatient)
    {
        try
        {
            var patientDetails = await _dbService.GetPatientDetailsAsync(idPatient);
            return Ok(patientDetails);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}