using System.ComponentModel.DataAnnotations;

namespace FHIR_NEW.Data_Access
{
    public class PatientModel
    {
        [Key]
        public string? Id { get; set; }
        public bool Active { get; set; }
        public string? Name { get; set; }
        public List<string>? Telecom { get; set; }
        public string? Gender { get; set; }
        public string? DoB { get; set; }
        public List<string>? Deceased { get; set; }
        public string? Address { get; set; }
        public List<string>? MaritalStatus { get; set; }
        public List<string>? MultipleBirth { get; set; }
        public List<string>? Family_ContactDetails { get; set; }
        public string? Communication { get; set; }
    }
}
