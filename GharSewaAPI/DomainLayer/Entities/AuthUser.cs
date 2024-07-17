using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class AuthUser
    {
        [Key]
        public int AuthId { get; set; }

        public string? UserName { get; set; }

        public byte[]? PassWordHash  { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public string? Role {  get; set; }
    }
}
