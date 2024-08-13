/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace FHIR_API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class FHIR : ControllerBase
   {
       private const string FhirServer = "https://server.fire.ly";

       [HttpGet]
       public IActionResult GetPatients()
       {
           try
           {
               FhirClient fhirClient = new FhirClient(FhirServer);
               Bundle patientBundle = fhirClient.Search<Patient>(new string[] { });

               var patients = new List<object>();
               while (patientBundle != null && patientBundle.Entry != null)
               {
                   foreach (Bundle.EntryComponent patientEntry in patientBundle.Entry)
                   {
                       if (patientEntry.Resource != null)
                       {
                           Patient patient = (Patient)patientEntry.Resource;

                           string address="Not Specified";


                           if (patient.Address != null && patient.Address.Count > 0)
                           {
                               var value = patient.Address[0];
                               var country = value.Country;
                               var city = value.City;
                               address = $"{city ?? "Not specified"}, {country ?? "Not specified"}";
                           }


                           *//* if(patient.Active ==null)
                            {
                                isActive = false;
                            }
                            else
                            {
                                isActive = true;
                            }*//*

                           patients.Add(new
                           {
                               *//*Name = patient.Name[0].ToString(),*//*
                               Address = address,
                               *//*MaritalStatus = patient.MaritalStatus,
                               IsActive = patient.ActiveElement*//*

                           });
                           *//*patients.Add(new
                           {
                               Id = patient.Id,
                               Name = patient.Name[0].ToString(),
                           });*//*
                       }
                       try
                       {
                           patientBundle = fhirClient.Continue(patientBundle);
                       }
                       catch (FhirOperationException ex) when (ex.Status == System.Net.HttpStatusCode.Gone)
                       {

                           break;
                       }
                   }     
               }
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
*/
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
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

                var patients = new List<object>();

                while (patientBundle != null && patientBundle.Entry != null && patientBundle.Entry.Count > 0)
                {

                    foreach (Bundle.EntryComponent patientEntry in patientBundle.Entry)
                    {
                        if (patients.Count >= maxCount)
                        {
                            break;
                        }

                        if (patientEntry.Resource != null)
                        {
                            Patient patient = (Patient)patientEntry.Resource;

                            //FOR ADDRESS
                            /*string address = "Not Specified";

                            if(patient.Address.Count > 0 && patient.Address!=null)
                            {
                                var value = patient.Address[0];
                                var country = value.Country;
                                var city = value.City;
                                address = $"{city ?? ""}, {country ?? ""}";
                            }*/

                            string address = "";
                            if (patient.Address != null && patient.Address.Count > 0)
                            {
                                if (patient.Address is List<Address> addressvalues)
                                {
                                    var postalcode = addressvalues.FirstOrDefault()?.PostalCode;
                                    var district = addressvalues.FirstOrDefault()?.District;
                                    var period = addressvalues.FirstOrDefault()?.Period;
                                    var line = addressvalues.FirstOrDefault()?.Line;
                                    var cityname = addressvalues.FirstOrDefault()?.City;
                                    var statename = addressvalues.FirstOrDefault()?.State;
                                    var countryname = addressvalues.FirstOrDefault()?.Country;
                                    address = $"{postalcode}, {district}, {period}, {line}, {cityname}, {statename}, {countryname}";
                                }
                            }


                            //FOR TELECOM

                            //IN LIST FORM
                            /*List<string> contact = new List<string>();


                            if (patient.Telecom != null && patient.Telecom.Count>0)
                            {
                                var forPhone = patient.Telecom[0];
                                var phone = forPhone.Value;
                                var forEmail = patient.Telecom[1];
                                var email = forEmail.Value;
                                contact.Add(phone);
                                contact.Add(email);
                            }
                            */
                            //IN STRING FORM

                            /*string contact = "NOT PROVIDED";

                            if (patient.Telecom != null && patient.Telecom.Count > 0)
                            {
                                var forPhone = patient.Telecom[0];
                                var phone = forPhone.Value;
                                var forEmail = patient.Telecom[1];
                                var email = forEmail.Value;

                                contact = $"{phone ?? "NOT PROVIDED"} , {email ?? "NOT PROVIDED"}";
                            }*/

                            //CORRECT WAY 
                            List<string> telecom = new List<string>();
                            if (patient.Telecom != null)
                            {
                                if (patient.Telecom is List<ContactPoint> telecomdetail)
                                {
                                    var phone = telecomdetail.FirstOrDefault()?.Value;
                                    var email = telecomdetail.LastOrDefault()?.Value;
                                    telecom.Add(phone);
                                    telecom.Add(email);
                                }
                            }

                            //FOR GENDER

                            string gender = "NOT SPECIFIED";
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
                                    gender = "NOT SPECIFIED";
                                }

                            }

                            //FOR DECEASED
                            string deceasedDate = "NOT SPECIFIED";
                            string deceasedTrue = "";
                            List<string> deceased = new List<string>();

                            if (patient.Deceased != null)
                            {
                                if (patient.Deceased is FhirDateTime deceasedDateTime)
                                {
                                    deceasedDate = deceasedDateTime.Value?.ToString() ?? "UNKNOWN";
                                }
                                else
                                {
                                    deceasedDate = "Deceased status without date";
                                }

                                if (patient.Deceased is FhirBoolean deceasedBool)
                                {
                                    deceasedTrue = "True";
                                }
                                else
                                {
                                    deceasedTrue = "False";
                                }

                                deceased.Add(deceasedDate);
                                deceased.Add(deceasedTrue);
                            }

                            //MARITAL STATUS
                            string marital = "NOT SPECIFIED";
                            string divorceDate = "";
                            List<string> maritalStatus = new List<string>();
                            if (patient.MaritalStatus != null)
                            {

                                if (patient.MaritalStatus is CodeableConcept married)
                                {
                                    var coding = married.Coding;
                                    var code = coding.FirstOrDefault()?.Code;
                                    var divorce = coding.LastOrDefault()?.Display;



                                    if (code == "M")
                                    {
                                        marital = "MARRIED";
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

                                    if (code == "D")
                                    {
                                        divorceDate = divorce;
                                    }
                                    maritalStatus.Add(marital);
                                    maritalStatus.Add(divorceDate);
                                }

                            }

                            object multipleBirth = "NOT SPECIFIED";

                            //MULTIPLE BIRTH 
                            if (patient.MultipleBirth != null)
                            {
                                if (patient.MultipleBirth is FhirBoolean multipleBirthBoolean)
                                {
                                    multipleBirth = multipleBirthBoolean.Value;
                                }
                            }


                            //CONTACT
                            string relationship = "";
                            List<string> contact = new List<string>();
                            if (patient.Contact != null)
                            {
                                if (patient.Contact.Count > 0)
                                {
                                    var relationshipContainer = patient.Contact.FirstOrDefault()?.Relationship;
                                    var relationshipCode = relationshipContainer.FirstOrDefault()?.Coding;
                                    var relationshipcodeValue = relationshipCode.FirstOrDefault()?.Code;
                                    if (relationshipcodeValue != null)
                                    {
                                        if (relationshipcodeValue == "BP")
                                        {
                                            relationship = "Billing Contact Person";
                                        }
                                        else if (relationshipcodeValue == "CP")
                                        {
                                            relationship = "Contact Person";
                                        }
                                        else if (relationshipcodeValue == "EP")
                                        {
                                            relationship = "Emergency Contact Person";
                                        }
                                        else if (relationshipcodeValue == "PR")
                                        {
                                            relationship = "Person Preparing Referral";
                                        }
                                        else if (relationshipcodeValue == "E")
                                        {
                                            relationship = "Employer";
                                        }
                                        else if (relationshipcodeValue == "C")
                                        {
                                            relationship = "Emergency Contact";
                                        }
                                        else if (relationshipcodeValue == "F")
                                        {
                                            relationship = "Federal Agency";
                                        }
                                        else if (relationshipcodeValue == "I")
                                        {
                                            relationship = "Insurance Company";
                                        }
                                        else if (relationshipcodeValue == "N")
                                        {
                                            relationship = "Next-of-Kin";
                                        }
                                        else if (relationshipcodeValue == "S")
                                        {
                                            relationship = "State Agency";
                                        }
                                        else if (relationshipcodeValue == "U")
                                        {
                                            relationship = "Unknown";
                                        }
                                        else
                                        {
                                            relationship = "NOT SPECIFIED";
                                        }
                                        contact.Add(relationship);
                                    }

                                    var name = patient.Contact.FirstOrDefault()?.Name;
                                    if (name is HumanName contactname)
                                    {
                                        var naam = contactname.Family;
                                        contact.Add(Convert.ToString(naam));
                                    }

                                }
                            }

                            patients.Add(new
                            {
                                /*Deceased = deceased,*/
                                MaritalStatus = patient.MaritalStatus,
                                /*MultipleBirth = multipleBirth,
                                Telecom = telecom,
                                Address = address,
                                Contact = contact*/
                            });
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
                    Total = patients.Count,
                    Patients = patients,
                    FullTotal = total


                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}