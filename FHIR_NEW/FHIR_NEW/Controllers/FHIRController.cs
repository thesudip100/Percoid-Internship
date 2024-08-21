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
                                    multipleBirthStatus = multipleBirth.Value?.ToString();
                                    mul_birth.Add(multipleBirthStatus ?? "Unknown");
                                }
                                else if (patient.MultipleBirth is Integer birth_number)
                                {
                                    multipleBirthStatus = "True";  

                                    if (birth_number.Value == 0)
                                    {
                                        birth_Order = "Birth order not specified";
                                    }
                                    else if (birth_number.Value == 1)
                                    {
                                        birth_Order = "First child";
                                    }
                                    else if (birth_number.Value == 2)
                                    {
                                        birth_Order = "Second child";
                                    }
                                    else
                                    {
                                        birth_Order = $"Child number {birth_number.Value}";
                                    }

                                    mul_birth.Add(multipleBirthStatus);
                                    mul_birth.Add(birth_Order);
                                }
                            }


                            //COMMUNICATION
                            string langg;
                            if (patient.Communication!=null && patient.Communication.Count > 0)
                            {
                                if(patient.Communication is List<Patient.CommunicationComponent> commList)
                                {
                                    foreach(var comm in commList)
                                        if (comm.Language != null && comm.Language.Coding != null && comm.Language.Coding.Count > 0)
                                        {
                                            foreach (var coding in comm.Language.Coding)
                                            {
                                                
                                                
                                                if(coding.Code=="en")
                                                {
                                                    langg = "English";
                                                }

                                                else if(coding.Code=="es")
                                                {
                                                    langg = "Spanish";
                                                }

                                                else if (coding.Code == "ca")
                                                {
                                                    langg = "English(Canada)";
                                                }

                                                else if (coding.Code == "fr")
                                                {
                                                    langg = "French";
                                                }

                                                else
                                                {
                                                    //checks if coding.Code is not null, if not null assigns value of coding.Code else "Unknown Code"
                                                    langg = coding.Code ?? "Unknown Code";
                                                }

                                                if (!string.IsNullOrWhiteSpace(coding.Display))
                                                {
                                                     langg= coding.Display;
                                                }
                                                
                                               
                                            }
                                        }
                                }
                            }


                            //CONTACT
                            string relationship;
                            string contactName;
                            string contactEmail;
                            string contactPhone;
                            string contactGender;
                            string contactAddress = String.Empty;
                            List<string> contactList= new List<string>();
                            if(patient.Contact!=null)
                            {
                                //FOR CONTACT RELATIONSHIP
                                var relationshipContainer = patient.Contact.FirstOrDefault()?.Relationship;
                                if(relationshipContainer!=null)
                                {
                                    var relationshipCode = relationshipContainer.FirstOrDefault()?.Coding;
                                    if(relationshipCode!=null)
                                    {
                                        var relationshipValue = relationshipCode.FirstOrDefault()?.Code;

                                        relationship = relationshipValue switch
                                        {
                                            "BP" => "Billing Contact Person",
                                            "CP" => "Contact Person",
                                            "EP" => "Emergency Contact Person",
                                            "PR" => "Person Preparing Referral",
                                            "E" => "Employer",
                                            "C" => "Emergency Contact",
                                            "F" => "Federal Agency",
                                            "I" => "Insurance Company",
                                            "N" => "Next-of-Kin",
                                            "S" => "State Agency",
                                            "U" => "Unknown",
                                            _ => "NOT SPECIFIED"
                                        };
                                        contactList.Add(relationship);
                                    }
                                }

                                //FOR CONTACT NAME
                                var name = patient.Contact.FirstOrDefault()?.Name;
                                if (name is HumanName contactname)
                                {
                                    var contactLastName = contactname.Family;
                                    var givenNamesList = new List<string>();
                                    foreach (var g in contactname.Given)
                                    {
                                        givenNamesList.Add(g.ToString());
                                    }
                                    var contactGivenName = string.Join(" ", givenNamesList);
                                    contactName = contactGivenName + " " + Convert.ToString(contactLastName);
                                    contactList.Add(contactName);
                                }

                                //FOR CONTACT TELECOM
                                var contactTelecom = patient.Contact.FirstOrDefault()?.Telecom;
                                if (contactTelecom is List<ContactPoint> contactTel)
                                {
                                    if (contactTel.FirstOrDefault()?.System.ToString().ToLower() == "phone")
                                    {
                                        contactPhone = contactTel.FirstOrDefault()?.Value;
                                        contactList.Add(contactPhone);
                                    }
                                   

                                    if (contactTel.LastOrDefault()?.System.ToString().ToLower() == "email")
                                    {
                                        contactEmail = contactTel.LastOrDefault()?.Value;
                                        contactList.Add(contactEmail);
                                    }
                                    

                                }

                                //FOR CONTACT GENDER
                                contactGender = patient.Contact.FirstOrDefault()?.Gender.ToString();
                                if(contactGender!=null)
                                {
                                    contactList.Add(contactGender);
                                }
                                

                                //FOR CONTACT ADDRESS
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
                                                contactAddress += line;
                                            }

                                        }
                                    }

                                    if (!string.IsNullOrEmpty(addressValue.City))
                                    {
                                        var city = addressValue.City;
                                        contactAddress += city + ",";
                                    }

                                    if (!string.IsNullOrEmpty(addressValue.District))
                                    {
                                        var district = addressValue.District;
                                        contactAddress += district + ",";
                                    }

                                    if (!string.IsNullOrEmpty(addressValue.State))
                                    {
                                        var state = addressValue.State;
                                        contactAddress += state + ",";
                                    }

                                    if (!string.IsNullOrEmpty(addressValue.Country))
                                    {
                                        var state = addressValue.Country;
                                        contactAddress += state + ",";
                                    }

                                    if (!string.IsNullOrEmpty(addressValue.PostalCode))
                                    {
                                        var postalcode = addressValue.PostalCode;
                                        contactAddress += postalcode + ",";

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
                                        contactAddress = address.Substring(0, address.Length - 1);
                                    }

                                    contactList.Add(contactAddress);
                                    
                                }

                                patients.Add(contactList);
                                
                            }
                            
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


