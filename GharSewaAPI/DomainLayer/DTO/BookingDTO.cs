using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class BookingDTO
    {
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? ServiceName { get; set; }
        public string? BookingDate { get; set; }
        public int? BookingId { get; set; }
    }
}
