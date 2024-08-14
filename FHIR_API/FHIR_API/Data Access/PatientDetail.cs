using System.ComponentModel.DataAnnotations;

namespace FHIR_API.Data_Access
{
        public class PatientDetail
        {
            [Key]
            public string Id { get; set; }
            public bool Active { get; set; }
            public string? Name { get; set; }
            public string? Address { get; set; }
            public string? Gender { get; set; }
            public string? DoB { get; set; }
            public List<string>? Deceased { get; set; }
            public List<string>? MaritalStatus { get; set; }
            public bool? MultipleBirth { get; set; }
            public List<string>? Telecom { get; set; }
            public string? ContactRelationship { get; set; }
            public string? ContactName { get; set; }
            public string? ContactPhone { get; set; }
            public string? ContactEmail { get; set; }
            public string? ContactAddress { get; set; }
            public string? ContactGender { get; set; }
            public string? ContactPeriod { get; set; }
            public string? Communication { get; set; }
            public string? PreferredLanguage { get; set; }
        }
    }
