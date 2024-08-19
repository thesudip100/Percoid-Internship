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
using Dapper;
using FHIR_API.Data_Access;
using FHIR_API.DataAccess;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PatientController : ControllerBase
    {
        private const string FhirServer = "https://server.fire.ly";
        /*private const string FhirServer = "http://hapi.fhir.org/baseR4";*/
        private readonly ApplicationDbContext appDbContext;
        private readonly string connectionstring;

        public PatientController(ApplicationDbContext _appDbContext, IConfiguration _configuration)
        {
            appDbContext = _appDbContext;
            connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }

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
                        if (patients.Count() >= maxCount)
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
                            string line = "";
                            if (patient.Address != null && patient.Address.Count > 0)
                            {
                                if (patient.Address is List<Address> addressvalues)
                                {
                                    var postalcode = addressvalues.FirstOrDefault()?.PostalCode;
                                    var district = addressvalues.FirstOrDefault()?.District;
                                    var period = addressvalues.FirstOrDefault()?.Period;
                                    var lineList = addressvalues.FirstOrDefault()?.Line;
                                    if (lineList != null)
                                    {
                                        foreach (var l in lineList)
                                        {
                                            line = l.ToString();
                                        }
                                    }
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
                            List<string> telecom = new List<string>(["Not Provided"]);
                            if (patient.Telecom != null)
                            {
                                if (patient.Telecom is List<ContactPoint> telecomdetail)
                                {
                                    var phone = telecomdetail.FirstOrDefault()?.Value;
                                    var email = telecomdetail.LastOrDefault()?.Value;
                                    if (phone != null)
                                        telecom.Add(phone);
                                    if (email != null)
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
                            List<string> deceased = new List<string>(["NOT SPECIFIED"]);

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
                            List<string> maritalStatus = new List<string>(["NOT SPECIFIED"]);
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
                                        if (divorce != null)
                                        {
                                            divorceDate = divorce;
                                        }

                                    }
                                    maritalStatus.Add(marital);
                                    if (divorceDate != null)
                                    {
                                        maritalStatus.Add(divorceDate);
                                    }

                                }

                            }

                            bool? multipleBirth = false;

                            //MULTIPLE BIRTH 
                            if (patient.MultipleBirth != null)
                            {
                                if (patient.MultipleBirth is FhirBoolean multipleBirthBoolean)
                                {
                                    multipleBirth = multipleBirthBoolean.Value;
                                }
                            }


                            //CONTACT
                            string? relationship = "";
                            string? contactRelationship = "";
                            string? contactName = "";
                            string? contactPhone = "";
                            string? contactEmail = "Not Provided";
                            string? contactAddress = "";
                            string? contactGender = "";
                            string? contactPeriod = "";

                            if (patient.Contact != null)
                            {
                                if (patient.Contact.Count > 0)
                                {
                                    var relationshipContainer = patient.Contact.FirstOrDefault()?.Relationship;
                                    if (relationshipContainer != null)
                                    {
                                        var relationshipCode = relationshipContainer.FirstOrDefault()?.Coding;
                                        if (relationshipCode != null)
                                        {
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
                                                contactRelationship = relationship;

                                            }

                                        }
                                    }

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
                                    }

                                    var contactTelecom = patient.Contact.FirstOrDefault()?.Telecom;
                                    if (contactTelecom is List<ContactPoint> contactTel)
                                    {
                                        if (contactTel.FirstOrDefault()?.System.ToString().ToLower() == "phone")
                                        {
                                            contactPhone = contactTel.FirstOrDefault()?.Value;
                                        }
                                        else
                                        {
                                            contactPhone = "";
                                        }

                                        if (contactTel.LastOrDefault()?.System.ToString().ToLower() == "email")
                                        {
                                            contactEmail = contactTel.LastOrDefault()?.Value;
                                        }
                                        else
                                        {
                                            contactEmail = "";
                                        }
                                    }

                                    var contactaddress = patient.Contact.FirstOrDefault()?.Address;
                                    if (contactaddress is Address add)
                                    {
                                        var contactLineList = add.Line;
                                        string contactLine = "";
                                        string contactCity = "";
                                        string contactDistrict = "";
                                        string contactState = "";
                                        string contactPostal = "";
                                        /*string contactCountry = "";*/

                                        foreach (var l in contactLineList)
                                        {
                                            contactLine = l.ToString();
                                        }
                                        contactCity = add.City.ToString();
                                        if (add.District != null)
                                            contactDistrict = add.District.ToString();
                                        if (add.State != null)
                                            contactState = add.State.ToString();
                                        if (add.PostalCode != null)
                                            contactPostal = add.PostalCode.ToString();
                                        /*contactCountry = add.Country.ToString();*/
                                        contactAddress = contactPostal + ", " + contactLine + ", " + contactCity + ", " + contactState;
                                    }

                                    contactGender = patient.Contact.FirstOrDefault()?.Gender.ToString();

                                    if (patient.Contact.FirstOrDefault()?.Period is Period per)
                                    {
                                        contactPeriod = per.Start.ToString();
                                    }

                                    else
                                    {
                                        contactPeriod = "";
                                    }

                                }
                            }


                            //COMMUNICATION
                            string? language = "";
                            string? preferredLang = "";

                            if (patient.Communication != null && patient.Communication.Count > 0)
                            {
                                if (patient.Communication is List<Patient.CommunicationComponent> commList)
                                {
                                    foreach (var comm in commList)
                                    {
                                        var lang = comm.Language;
                                        /* foreach(var coding in lang)
                                         {
                                             Language = coding.Key;
                                             Language.FirstOrDefault()?.
                                         }*/
                                        if (lang != null && lang.Coding != null)
                                        {
                                            var coding = lang.Coding;
                                            foreach (var value in coding)
                                            {
                                                if (value.Display != null)
                                                {
                                                    language += value.Display + " ";
                                                }
                                                else
                                                {
                                                    language += value.Code + " ";
                                                }

                                            }
                                        }

                                        var preferred = comm.Preferred;
                                        if (preferred is Boolean pre)
                                        {
                                            preferredLang = pre.ToString();
                                        }
                                        else
                                        {
                                            preferredLang = "Not Specified";
                                        }

                                    }
                                }
                            }


                            var patientsdata = new PatientDetail()
                            {
                                Id = patient.Id,
                                Active = patient.Active ?? false,
                                Name = patient.Name.FirstOrDefault()?.ToString() ?? "Not specified",
                                Address = address,
                                Gender = gender,
                                DoB = patient.BirthDate ?? "NOT SPECIFIED",
                                Deceased = deceased,
                                MaritalStatus = maritalStatus,
                                MultipleBirth = multipleBirth,
                                Telecom = telecom,
                                ContactRelationship = contactRelationship,
                                ContactName = contactName,
                                ContactPhone = contactPhone,
                                ContactEmail = contactEmail,
                                ContactAddress = contactAddress,
                                ContactGender = contactGender,
                                ContactPeriod = contactPeriod,
                                Communication = language,
                                PreferredLanguage = preferredLang,

                            };
                            appDbContext.Patients.Add(patientsdata);
                            appDbContext.SaveChanges();

                            /*using(var connection = new NpgsqlConnection(connectionstring))
                            {
                                var query = "INSERT INTO Patients(Id,Active,Name,Address,Gender,DoB,Deceased,MaritalStatus,MultipleBirth,Telecom,ContactRelationship,ContactName,ContactPhone,ContactEmail,ContactAddress,ContactGender,ContactPeriod,Communication,PreferredLanguage) VALUES (@Id,@Active,@Name,@Address,@Gender,@DoB,@Deceased,@MaritalStatus,@MultipleBirth,@Telecom,@ContactRelationship,@ContactName,@ContactPhone,@ContactEmail,@ContactAddress,@ContactGender,@ContactPeriod,@Communication,@PreferredLanguage)";
                                connection.Execute(query, new
                                {
                                    @Id = patient.Id,
                                    @Active = patient.Active ?? false,
                                    @Name = patient.Name.FirstOrDefault()?.ToString() ?? "Not specified",
                                    @Address = address,
                                    @Gender = gender,
                                    @DoB = patient.BirthDate ?? "NOT SPECIFIED",
                                    @Deceased = deceased,
                                    @MaritalStatus = maritalStatus,
                                    @MultipleBirth = multipleBirth,
                                    @Telecom = telecom,
                                    @ContactRelationship = contactRelationship,
                                    @ContactName = contactName,
                                    @ContactPhone = contactPhone,
                                    @ContactEmail = contactEmail,
                                    @ContactAddress = contactAddress,
                                    @ContactGender = contactGender,
                                    @ContactPeriod = contactPeriod,
                                    @Communication = language,
                                    @PreferredLanguage = preferredLang
                                });
                            }*/

                            /*patients.Add(new
                            {
                                Id = patient.Id,
                                *//*Active = patient.Active??false,
                                Name = patient.Name.FirstOrDefault()?.ToString() ?? "Not specified",
                                Address = address,
                                Gender = gender,
                                DoB = patient.BirthDate ?? "NOT SPECIFIED",*/
                            /*Deceased = patient.Deceased,
                            MaritalStatus = patient.MaritalStatus,
                            MultipleBirth = multipleBirth,
                            Telecom = patient.Telecom,
                            Address = address,
                            StandardContact = patient.Contact,
                            ContactRelationship = contactRelationship,
                            ContactName = contactName,
                            ContactPhone = contactPhone,
                            ContactEmail = contactEmail,
                            ContactAddress = contactAddress,
                            ContactGender = contactGender,
                            ContactPeriod = contactPeriod,*//*
                            Communcation = patient.Communication

                        });*/
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
                    FullTotal = total,
                    Patients = patients
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }


        [HttpGet()]
        public IActionResult GetPractitioner(int maxCount)
        {
            try
            {
                FhirClient fhirClient = new FhirClient(FhirServer);
                Bundle practitionerBundle = fhirClient.Search<Practitioner>(new string[] { });
                var total = practitionerBundle.Total;

                var practitioners = new List<object>();

                while (practitionerBundle != null && practitionerBundle.Entry != null && practitionerBundle.Entry.Count > 0)
                {
                    foreach (Bundle.EntryComponent practitionerEntry in practitionerBundle.Entry)
                    {
                        if (practitioners.Count() >= maxCount)
                        {
                            break;
                        }

                        if (practitionerEntry.Resource != null)
                        {
                            Practitioner practitioner = (Practitioner)practitionerEntry.Resource;

                            //for prefix of Name

                            string prefix = "";
                            if (practitioner.Name != null)
                            {
                                var prefixList = practitioner.Name.FirstOrDefault()?.Prefix;
                                if (prefixList != null)
                                {
                                    foreach (var p in prefixList)
                                    {
                                        prefix = p.ToString();
                                    }
                                }


                            }


                            //for telecom

                            string email = "";
                            string phone = "";
                            string fax = "";
                            if (practitioner.Telecom != null)
                            {

                                if (practitioner.Telecom is List<ContactPoint> telecomdetail)
                                {
                                    if (telecomdetail.Count > 0 && telecomdetail != null)
                                    {
                                        foreach (var a in telecomdetail)
                                        {
                                            if (a.System != null)
                                            {
                                                if (a.System.ToString() == "Email")
                                                {
                                                    email += a.Value.ToString() + " ";
                                                }
                                                if (a.System.ToString() == "Phone")
                                                {
                                                    phone += a.Value.ToString() + " ";
                                                }

                                                if (a.System.ToString() == "Fax")
                                                {
                                                    fax += a.Value.ToString() + " ";
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            //FOR GENDER

                            string gender = "NOT SPECIFIED";
                            if (practitioner.Gender != null)
                            {
                                if (practitioner.Gender == AdministrativeGender.Female)
                                {
                                    gender = "Female";
                                }
                                else if (practitioner.Gender == AdministrativeGender.Male)
                                {
                                    gender = "Male";
                                }
                                else if (practitioner.Gender == AdministrativeGender.Unknown)
                                {
                                    gender = "Unknown";
                                }
                                else if (practitioner.Gender == AdministrativeGender.Other)
                                {
                                    gender = "Other";
                                }
                                else
                                {
                                    gender = "NOT SPECIFIED";
                                }

                            }

                            //FOR ADDRESS

                            string address = "";
                            string line = "";
                            if (practitioner.Address != null && practitioner.Address.Count > 0)
                            {
                                if (practitioner.Address is List<Address> addressvalues)
                                {
                                    var postalcode = addressvalues.FirstOrDefault()?.PostalCode;
                                    var district = addressvalues.FirstOrDefault()?.District;
                                    var period = addressvalues.FirstOrDefault()?.Period;
                                    var lineList = addressvalues.FirstOrDefault()?.Line;
                                    if (lineList != null)
                                    {
                                        foreach (var l in lineList)
                                        {
                                            line = l.ToString();
                                        }
                                    }
                                    var cityname = addressvalues.FirstOrDefault()?.City;
                                    var statename = addressvalues.FirstOrDefault()?.State;
                                    var countryname = addressvalues.FirstOrDefault()?.Country;
                                    address = $"{postalcode}, {district}, {period}, {line}, {cityname}, {statename}, {countryname}";
                                }
                            }


                            //FOR QUALIFICATION

                            List<string> qualification = new List<string>();
                            if (practitioner.Qualification != null)
                            {
                                var qualificationList = practitioner.Qualification;
                                if (qualificationList.Count > 0 && qualificationList != null)
                                {
                                    string? id = "";
                                    string? degree = "";
                                    string? period = "";
                                    string? university = "";
                                    foreach (var i in qualificationList)
                                    {
                                        if (i.Identifier != null)
                                        {
                                            var idList = i.Identifier;
                                            foreach (var j in idList)
                                            {
                                                id = j.Value.ToString();
                                            }
                                            qualification.Add(id);
                                        }

                                        if (i.Code is CodeableConcept code)
                                        {
                                            var codingList = code.Coding;
                                            foreach (var k in codingList)
                                            {
                                                degree = k.Display.ToString();
                                            }
                                            qualification.Add(degree);
                                        }

                                        if (i.Period != null)
                                        {
                                            period = i.Period.Start.ToString();
                                            qualification.Add(period);
                                        }

                                        if (i.Issuer != null)
                                        {
                                            university = i.Issuer.Display.ToString();
                                            qualification.Add(university);
                                        }
                                    }
                                }
                            }

                            /*//COMMUNICATION
                            string? language = "";
                            string? preferredLang = "";

                            if (practitioner.Communication != null && practitioner.Communication.Count > 0)
                            {
                                if (practitioner.Communication is List<CodeableConcept> commList)
                                {
                                    foreach (var comm in commList)
                                    {
                                        var lang = comm.Language;
                                        foreach (var coding in lang)
                                        {
                                            Language = coding.Key;
                                            Language.FirstOrDefault()?.
                                         }
                                        if (lang != null && lang.Coding != null)
                                        {
                                            var coding = lang.Coding;
                                            foreach (var value in coding)
                                            {
                                                if (value.Display != null)
                                                {
                                                    language += value.Display + " ";
                                                }
                                                else
                                                {
                                                    language += value.Code + " ";
                                                }

                                            }
                                        }

                                        var preferred = comm.Preferred;
                                        if (preferred is Boolean pre)
                                        {
                                            preferredLang = pre.ToString();
                                        }
                                        else
                                        {
                                            preferredLang = "Not Specified";
                                        }

                                    }
                                }
                            }*/


                            practitioners.Add(new
                            {
                                Id = practitioner.Id,
                                Active = practitioner.Active ?? false,
                                Name = prefix + " " + practitioner.Name.FirstOrDefault()?.ToString() ?? "Not specified",
                                /* Email = email,
                                 Phone = phone,
                                 Fax = fax,*/
                                Gender = gender,
                                Address = address,
                                Qualification = qualification,
                                stdQual = practitioner.Qualification,
                                Language = practitioner.Language
                            });

                        }
                    }

                    if (practitioners.Count >= maxCount)
                    {
                        break;
                    }

                    practitionerBundle = fhirClient.Continue(practitionerBundle);
                }

                return Ok(new
                {
                    Practitioner = practitioners,
                    Total = total
                });
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}