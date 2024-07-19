using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class UserBooking
    {
        [Key]
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }
    }
}
