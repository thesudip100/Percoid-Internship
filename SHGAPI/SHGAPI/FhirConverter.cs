using Hl7.Fhir.Model;
using Newtonsoft.Json.Linq;
using SHGAPI.Models;


public class FhirConverter
{
    /* public static JObject ConvertToFhirPatient(PatientData data)
     {
         var nameParts = data.Name?.Split(' ', 2);

         // Create the HumanName object
         var humanName = new HumanName
         {
             Use = HumanName.NameUse.Official,
             Family = nameParts.Length > 1 ? nameParts[1] : string.Empty,
             Given = new List<string> { nameParts.Length > 0 ? nameParts[0] : string.Empty }
         };

         // Manually construct the name JSON object
         var nameObject = new JObject
         {
             ["use"] = new JObject { ["value"] = "official" },
             ["family"] = new JObject { ["value"] = humanName.Family },
             ["given"] = new JArray(
                 humanName.Given.Select(givenName => new JObject { ["value"] = givenName })
             )
         };

         var patientObject = new JObject
         {
             ["resourceType"] = "Patient",
             ["identifier"] = data.PatientId,
             ["active"] = null,
             ["name"] = new JArray { nameObject },
             ["telecom"] = !string.IsNullOrWhiteSpace(data.PhoneNumber) ? new JArray
                 {
                     new JObject
                     {
                         ["system"] = new JObject{["value"]="phone" },
                         ["value"] =  new JObject { ["value"] = data.PhoneNumber},
                         ["use"]= new JObject{["value"]="home"}
                     }
                 } : new JArray()
          ,
             ["gender"] = !string.IsNullOrWhiteSpace(data.Gender) ? ConvertGenderToNumber(data.Gender) : null,
             ["birthDate"] = data.Dob.HasValue ? data.Dob.Value.ToString("yyyy-MM-dd") : null,

             ["address"] = !string.IsNullOrWhiteSpace(data.District) ? new JArray
             {
                 new JObject
                 {
                     ["line"] =  new JObject{["value"]= data.Palika + ", " + data.Ward.ToString() },
                     ["city"] = new JObject{["value"]=data.District},
                     ["state"] = new JObject{["value"]=data.Province },
                 }
             } : new JArray(),
         };

         return patientObject;
     }

     public static int ConvertGenderToNumber(string gender)
     {
         if (string.IsNullOrWhiteSpace(gender))
         {
             return 3; // UNKNOWN
         }

         switch (gender.ToLower())
         {
             case "male":
                 return 0; // Male
             case "female":
                 return 1; // Female
             case "other":
                 return 2; // Other
             default:
                 return 3; // UNKNOWN
         }
     }*/


    public static Patient ConvertToFhirPatient(PatientData data)
    {
        var nameParts = data.Name?.Split(' ', 2);
        var patient = new Patient
        {
            Id = data.PatientId,
            Name = new List<HumanName>
    {
                new HumanName
                {
                    Use = HumanName.NameUse.Official,
                    FamilyElement = new FhirString{Value= nameParts[1] },
                    GivenElement= new List<FhirString>
                    {
                        new FhirString { ObjectValue = nameParts[0] }
                    }

                }
            },

            Gender = Gender(data.Gender.ToLower()),
            BirthDate = data.Dob?.ToString("yyyy-MM-dd"),
            Telecom = new List<ContactPoint>
            {
                new ContactPoint
                {
                    System = ContactPoint.ContactPointSystem.Phone,
                    Value = data.PhoneNumber,
                    Use=ContactPoint.ContactPointUse.Mobile
                }
            },
            Address = new List<Address>
            {
                new Address
                {
                    LineElement= new List<FhirString>
                    {
                        new FhirString { ObjectValue = data.Palika + ", " + data.Ward }
                    },
                    District = data.Palika,
                    State = data.Province,
                }
            }
        };


        return patient;
    }

    public static AdministrativeGender Gender(string gender)
    {
        if (string.IsNullOrWhiteSpace(gender))
        {
            return AdministrativeGender.Unknown; // UNKNOWN
        }

        switch (gender.ToLower())
        {
            case "male":
                return AdministrativeGender.Male; // Male
            case "female":
                return AdministrativeGender.Female; // Female
            case "other":
                return AdministrativeGender.Other; // Other
            default:
                return AdministrativeGender.Unknown; // UNKNOWN
        }
    }
}

/*public static Practitioner ConvertToFhirPractitioner(User data)
{
    var practitioner = new Practitioner
    {
        Id = Convert.ToString(data.Id),
        Name = new List<HumanName>
    {
        new HumanName
        {
            Text = data.FirstName + " " + data.LastName
        }


},
        Telecom = new List<ContactPoint>
{
    new ContactPoint
    {
        System = ContactPoint.ContactPointSystem.Phone,
        Value = data.PhoneNumber,

    },
    new ContactPoint
    {
         System= ContactPoint.ContactPointSystem.Email,
        Value= data.Email
    }

},


    };

    return practitioner;
}*/

/*
public static JObject ConvertToFhirPractitioner(User data)
    {

        // Manually construct the name JSON object
        var nameObject = new JObject
        {
            ["use"] = new JObject { ["value"] = "official" },
            ["family"] = new JObject { ["value"] = data.LastName },
            ["given"] = new JObject { ["value"] = data.FirstName }
        };

        var telecomArray = new JArray();

        if (!string.IsNullOrWhiteSpace(data.PhoneNumber))
        {
            telecomArray.Add(new JObject
            {
                ["system"] = new JObject { ["value"] = "phone" },
                ["value"] = new JObject { ["value"] = data.PhoneNumber },
            });
        }

        // Add email if it exists
        if (!string.IsNullOrWhiteSpace(data.Email))
        {
            telecomArray.Add(new JObject
            {
                ["system"] = new JObject { ["value"] = "email" },
                ["value"] = new JObject { ["value"] = data.Email },
            });
        }

        var practitionerObject = new JObject
        {
            ["resourceType"] = "Practitioner",
            ["identifier"] = data.Id,
            ["active"] = null,
            ["name"] = new JArray { nameObject },
            ["telecom"] = telecomArray
        };
        return practitionerObject;
    }
}
*/