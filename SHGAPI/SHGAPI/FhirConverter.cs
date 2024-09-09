﻿using Hl7.Fhir.Model;
using Newtonsoft.Json.Linq;
using SHGAPI.Models;


public class FhirConverter
{
    public static JObject ConvertToFhirPatient(PatientData data)
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
            ["resourceType"]="Patient",
            ["id"] = data.PatientId,
            ["name"] = new JArray { nameObject },
            ["gender"] = data.Gender?.ToLower() == "male" ? "male" : "female",
            ["birthDate"] = data.Dob?.ToString("yyyy-MM-dd"),
            ["telecom"] = !string.IsNullOrWhiteSpace(data.PhoneNumber)
                ? new JArray
                {
                    new JObject
                    {
                        ["system"] = "phone",
                        ["value"] = data.PhoneNumber
                    }
                }
                : new JArray(),
            ["address"] = new JArray
            {
                new JObject
                {
                    ["state"] = data.Province,
                    ["city"] = data.District,
                    ["district"] = data.Palika,

                }
            },
            ["identifier"] = new JArray
            {
                new JObject
                {
                    ["system"] = "https://nationalid.com",
                    ["value"] = !string.IsNullOrWhiteSpace(data.NationalId) ? data.NationalId : null
                },
                new JObject
                {
                    ["system"] = "https://nhis.com",
                    ["value"] = !string.IsNullOrWhiteSpace(data.NhisNumber) ? data.NhisNumber : null
                }
            }
        };

        return patientObject;
    }
}
/*
    public static Practitioner ConvertToFhirPractitioner(User data)
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

