using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs
{
    public class UserRegisterDTO
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? PhoneAddress { get; set; }
        public string? EmailAddress { get; set; }
        public string? ProfilePicURL { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;
    }
}
