using Hl7.Fhir.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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


        [HttpGet]
        public async Task<IActionResult> GetAllFhirPatients()
        {
            var allPatientData = await _context.Patients.ToListAsync();

            if (allPatientData == null || allPatientData.Count == 0)
            {
                return NotFound();
            }

            // Convert all patient records to FHIR-compliant patients
            var fhirPatients = new List<Hl7.Fhir.Model.Patient>();
            foreach (var patientData in allPatientData)
            {
                var fhirPatient = FhirConverter.ConvertToFhirPatient(patientData);
                fhirPatients.Add(fhirPatient);
            }

            // Serialize the list of FHIR patients using FHIR JSON serializer
            var fhirJsonSerializer = new FhirJsonSerializer();
            var serializedPatients = new List<string>();

            foreach (var patient in fhirPatients)
            {
                var serializedPatient = fhirJsonSerializer.SerializeToString(patient);
                serializedPatients.Add(serializedPatient);
            }

            // Combine all serialized FHIR patients into a single JSON array
            string jsonArray = "[" + string.Join(",", serializedPatients) + "]";

            return Content(jsonArray, "application/fhir+json");
        }

        /*[HttpGet("practitioners")]
        public async Task<IActionResult> GetAllFhirPractitioners()
        {
            var allPractitionerData = await _context.Users.ToListAsync();

            if (allPractitionerData == null || allPractitionerData.Count == 0)
            {
                return NotFound();
            }

            // Convert all patient records to FHIR-compliant patients
            var fhirPractitioners = new List<Hl7.Fhir.Model.Practitioner>();
            foreach (var practitionerData in allPractitionerData)
            {
                var fhirPatient = FhirConverter.ConvertToFhirPractitioner(practitionerData);
                fhirPractitioners.Add(fhirPatient);
            }

            // Serialize the list of FHIR patients using FHIR JSON serializer
            var fhirJsonSerializer = new FhirJsonSerializer();
            var serializedPractitioners = new List<string>();

            foreach (var practitioner in fhirPractitioners)
            {
                var serializedPractitioner = fhirJsonSerializer.SerializeToString(practitioner);
                serializedPractitioners.Add(serializedPractitioner);
            }

            // Combine all serialized FHIR patients into a single JSON array
            string jsonArray = "[" + string.Join(",", serializedPractitioners) + "]";

            return Content(jsonArray, "application/fhir+json");
        }*/
    }
}
