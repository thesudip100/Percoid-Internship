using Hl7.Fhir.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHGAPI.Models;

namespace SHGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFhirPatient(string id)
        {
            var patientData = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == id);

            if (patientData == null)
            {
                return NotFound();
            }

            var fhirPatient = FhirConverter.ConvertToFhirPatient(patientData);

            // Serialize to JSON in FHIR-compliant format
            return Content(fhirPatient.ToJson(), "application/fhir+json");
        }
    }
}
