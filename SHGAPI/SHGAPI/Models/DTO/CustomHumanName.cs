using Hl7.Fhir.Model;

namespace SHGAPI.Models.DTO
{
   

    public class CustomHumanName
    {
        public List<HumanName> Name { get; set; }

        public string Use { get; set; }

        public List<string> Given { get; set; }

        public string Family {  get; set; }

        public string Value { get; set; }

    }
}
