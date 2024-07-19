using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string? ServiceName { get; set; }
        public DateTime? BookingDate { get; set; }
    }
}
