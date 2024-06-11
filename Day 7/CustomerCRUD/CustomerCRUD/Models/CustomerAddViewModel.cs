using System.ComponentModel.DataAnnotations;

namespace CustomerCRUD.Models
{
    public class CustomerAddViewModel
    {
        [Required]
        public string name { get; set; } = "";

        [Required]
        public string email { get; set; } = "";

        [Required]
        public string phoneNumber { get; set; } = "";

        [Required]
        public string address { get; set; } = "";

        [Required]
        public DateTime dateofBirth { get; set; }
    }
}
