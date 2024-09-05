using Hl7.Fhir.Model;
using SHGAPI.Models;

public class FhirConverter
{
    public static Patient ConvertToFhirPatient(PatientData data)
    {
        var patient = new Patient
        {
            Id = data.PatientId,
            Name = new List<HumanName>
            {
                new HumanName
                {
                    Text = data.Name
                }
            },
            Gender = data.Gender.ToLower() == "male" ? AdministrativeGender.Male : AdministrativeGender.Female,
            BirthDate = data.Dob?.ToString("yyyy-MM-dd"),
            Telecom = new List<ContactPoint>
            {
                new ContactPoint
                {
                    System = ContactPoint.ContactPointSystem.Phone,
                    Value = data.PhoneNumber
                }
            },
            Address = new List<Address>
            {
                new Address
                {
                    State = data.Province,
                    City = data.District,
                    District = data.Palika,
                    PostalCode = data.Ward.ToString()
                }
            },
            Identifier = new List<Identifier>
            {
                new Identifier
                {
                    System = "https://nationalid.com",
                    Value = data.NationalId
                },
                new Identifier
                {
                    System = "https://nhis.com",
                    Value = data.NhisNumber
                }
            }
        };

        return patient;
    }
}
