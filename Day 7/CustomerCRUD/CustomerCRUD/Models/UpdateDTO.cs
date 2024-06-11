using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CustomerCRUD.Models
{
    public class UpdateDTO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string PhoneNumber { get; set; } = "";

        [Required]
        public string Address { get; set; } = "";

        [Required]
        public DateTime DateofBirth { get; set; }

    }
}
