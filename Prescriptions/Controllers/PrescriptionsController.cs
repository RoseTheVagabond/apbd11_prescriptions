using Microsoft.AspNetCore.Mvc;
using Prescriptions.DTOs;
using Prescriptions.Models;
using Prescriptions.Services;

namespace Prescriptions.Controllers;

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
        return Ok(prescription);
    }
}