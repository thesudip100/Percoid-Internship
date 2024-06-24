using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string empName { get; set; } = "";

        [Required]
        public string empAddress { get; set; } = "";

        [Required]
        public string empPhone { get; set; } = "";

    }
}
