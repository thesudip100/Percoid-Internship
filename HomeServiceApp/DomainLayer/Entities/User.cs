using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Address {  get; set; }
        public string? PhoneAddress { get; set; }
        public string? EmailAddress { get; set; }
        public string? UserName { get; set; }
        public string? ProfilePicURL { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string Role { get; set; } = string.Empty;
        public string? CreatedOn { get; set; } = DateTime.UtcNow.ToString();

    }
}
