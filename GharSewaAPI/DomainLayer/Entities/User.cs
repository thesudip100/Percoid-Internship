using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class User
    {
        [Key]
        public int UserId {  get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone {  get; set; }
    }
}
