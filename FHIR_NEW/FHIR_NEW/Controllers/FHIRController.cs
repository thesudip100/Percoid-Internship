using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FHIR_NEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FHIRController : ControllerBase
    {
        private const string FhirServer = "https://server.fire.ly";


        [HttpGet]
        public IActionResult GetPatients(int maxCount)
        {
            try
            {
                FhirClient fhirClient = new FhirClient(FhirServer);
                Bundle patientBundle = fhirClient.Search<Patient>(new string[] { });
                var total = patientBundle.Total;

                //creating list "patients" that stores objects
                var patients = new List<object>();

                while (patientBundle != null && patientBundle.Entry != null && patientBundle.Entry.Count > 0)
                {
                    foreach (Bundle.EntryComponent patientEntry in patientBundle.Entry)
                    {
                        if (patients.Count() >= maxCount)
                        {
                            break;
                        }

                        if (patientEntry.Resource != null)
                        {
                            Patient patient = (Patient)patientEntry.Resource;


                            //FOR ADDRESS
                            var address = String.Empty;
                            if (patient.Address != null && patient.Address.Count > 0)
                            {
                                if (patient.Address != null && patient.Address.Count > 0)
                                {
                                    // Get the first address from the list
                                    var addressValue = patient.Address.FirstOrDefault();
                                    if (addressValue != null)
                                    {
                                        // Loop through the lines if they exist
                                        if (addressValue.Line != null)
                                        {
                                            foreach (var l in addressValue.Line)
                                            {
                                                if (!string.IsNullOrEmpty(l))
                                                {
                                                    var line = l;
                                                    address += line + ",";
                                                }

                                            }
                                        }

                                        if (!string.IsNullOrEmpty(addressValue.City))
                                        {
                                            var city = addressValue.City;
                                            address += city + ",";
                                        }

                                        if (!string.IsNullOrEmpty(addressValue.District))
                                        {
                                            var district = addressValue.District;
                                            address += district + ",";
                                        }

                                        if (!string.IsNullOrEmpty(addressValue.State))
                                        {
                                            var state = addressValue.State;
                                            address += state + ",";
                                        }

                                        if (!string.IsNullOrEmpty(addressValue.Country))
                                        {
                                            var state = addressValue.Country;
                                            address += state + ",";
                                        }

                                        if (!string.IsNullOrEmpty(addressValue.PostalCode))
                                        {
                                            var postalcode = addressValue.PostalCode;
                                            address += postalcode + ",";

                                        }

                                        if (!string.IsNullOrEmpty(addressValue.Text))
                                        {
                                            var text = addressValue.Text;
                                        }

                                        //since Use in enum, HasValue is used
                                        if (addressValue.Use.HasValue)
                                        {
                                            var use = addressValue.Use.ToString();
                                        }


                                        if (addressValue.Type.HasValue)
                                        {
                                            var type = addressValue.Type.ToString();
                                        }

                                        //removing last comma and space
                                        if (address.EndsWith(","))
                                        {
                                            address = address.Substring(0, address.Length - 1);
                                        }

                                    }
                                }




                            }

                            //FOR TELECOM
                            List<string> telecom = new List<string>();
                            if (patient.Telecom != null)
                            {
                                if (patient.Telecom is List<ContactPoint> telecomdetail)
                                {
                                    var phone = telecomdetail.FirstOrDefault()?.Value;
                                    var email = telecomdetail.LastOrDefault()?.Value;
                                    if (phone != null && email != null)
                                    {
                                        telecom.Add(phone);
                                        telecom.Add(email);
                                    }
                                }
                            }


                            //FOR GENDER
                            string gender = String.Empty;
                            if (patient.Gender != null)
                            {
                                if (patient.Gender == AdministrativeGender.Female)
                                {
                                    gender = "Female";
                                }

                                else if (patient.Gender == AdministrativeGender.Male)
                                {
                                    gender = "Male";
                                }

                                else if (patient.Gender == AdministrativeGender.Unknown)
                                {
                                    gender = "Unknown";
                                }

                                else if (patient.Gender == AdministrativeGender.Other)
                                {
                                    gender = "Other";
                                }
                                else
                                {
                                    gender = "Not Specified";
                                }
                            }


                            //FOR DECEASED
                            string deceasedTrue = String.Empty;
                            List<string> deceased = new List<string>();

                            if (patient.Deceased != null)
                            {
                                if (patient.Deceased is FhirDateTime deceasedDateTime && deceasedDateTime != null)
                                {
                                    string deceasedDate = deceasedDateTime.Value.ToString();
                                    deceased.Add(deceasedDate);
                                }

                                if (patient.Deceased is FhirBoolean deceasedBool)
                                {
                                    deceasedTrue = "False";
                                }
                                else
                                {
                                    deceasedTrue = "True";
                                }

                                deceased.Add(deceasedTrue);
                            }

                            // MARITAL STATUS
                            string marital = String.Empty;
                            string divorceDate = String.Empty;
                            List<string> maritalStatus = new List<string>();
                            if (patient.MaritalStatus is CodeableConcept married)
                            {
                                var coding = married.Coding;
                                var code = coding.FirstOrDefault()?.Code;
                                var divorce = coding.LastOrDefault()?.Display;

                                if (code == "M")
                                {
                                    marital = "Married";
                                }
                                else if (code == "S")
                                {
                                    marital = "SINGLE";
                                }
                                else if (code == "D")
                                {
                                    marital = "DIVORCED";
                                }
                                else if (code == "W")
                                {
                                    marital = "WIDOWED";
                                }
                                else
                                {
                                    marital = "NOT SPECIFIED";
                                }
                                maritalStatus.Add(marital);

                                //if divorced, then needed divorced date as well
                                if (code == "D" && divorce != null)
                                {
                                    divorceDate = divorce;
                                    maritalStatus.Add(divorceDate);
                                }
                            }

                            // MULTIPLE BIRTH
                            string? multipleBirthStatus = null;
                            string birth_Order = String.Empty;
                            List<string> mul_birth = new List<string>();

                            if (patient.MultipleBirth != null)
                            {
                                if (patient.MultipleBirth is FhirBoolean multipleBirth)
                                {
                                    multipleBirthStatus = multipleBirth.Value?.ToString() ?? "False";
                                    mul_birth.Add(multipleBirthStatus);
                                }
                                else if (patient.MultipleBirth is Integer birth_number)
                                {
                                    if (birth_number.Value == 0)
                                    {
                                        multipleBirthStatus = "True";
                                        birth_Order = "Birth order not specified";
                                    }
                                    else if (birth_number.Value == 1)
                                    {
                                        multipleBirthStatus = "True";
                                        birth_Order = "First child";
                                    }
                                    else if (birth_number.Value == 2)
                                    {
                                        multipleBirthStatus = "True";
                                        birth_Order = "Second child";
                                    }

                                    mul_birth.Add(multipleBirthStatus);
                                    mul_birth.Add(birth_Order);
                                }
                            }

                            patients.Add(mul_birth);
                        }

                    }

                    if (patients.Count >= maxCount)
                    {
                        break;
                    }

                    patientBundle = fhirClient.Continue(patientBundle);
                }
                return Ok(new
                {
                    Patient = patients
                });


            }
            catch (FhirOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
