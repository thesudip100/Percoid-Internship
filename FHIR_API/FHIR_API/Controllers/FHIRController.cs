using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Microsoft.AspNetCore.Mvc;

namespace FHIR_API
{
    [ApiController]
    [Route("api/[controller]")]
    public class FHIRController : ControllerBase
    {
        private const string FhirServer = "https://server.fire.ly";

        [HttpGet]
        public IActionResult GetPatients()
        {
            try
            {
                FhirClient fhirClient = new FhirClient(FhirServer);
                Bundle patientBundle = fhirClient.Search<Patient>();

                var patients = new List<object>();

              
                    foreach (Bundle.EntryComponent patientEntry in patientBundle.Entry)
                    {
                        if (patientEntry.Resource != null)
                        {
                            Patient patient = (Patient)patientEntry.Resource;
                            patients.Add(new
                            {
                                id = patient.Id,
                                Name = patient.Name[0].ToString(),
                                contact=patient.Telecom,
                                gender=patient.Gender,
                                birthdate=patient.BirthDate
                            });
                        }
                    }

                   // patientBundle = fhirClient.Continue(patientBundle);
                

                return Ok(new
                {
                    Total = patients.Count,
                    Patients = patients
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
