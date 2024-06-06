using System.ComponentModel.DataAnnotations;

namespace PercoidCRUD.Models
{
    public class AddInterViewModel
    {

        [Required]
        public string name { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public DateTime joiningDate { get; set; }

        [Required]
        public double salary { get; set; }


    }
}
