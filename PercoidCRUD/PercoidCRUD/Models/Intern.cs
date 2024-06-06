using System.ComponentModel.DataAnnotations;

namespace PercoidCRUD.Models
{
    public class Intern
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]  
        public DateTime JoiningDate { get; set; }

        [Required]
        public double Salary { get; set; }
    }
}
