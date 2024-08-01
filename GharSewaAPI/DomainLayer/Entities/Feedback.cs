using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Feedback
    {
        [Key]
        public int id { get; set; }
        public int UserId { get; set; }
        public string? feedbackby { get; set; }
        public string? feedbackfor { get; set; }
        public string? Message { get; set; }
        
    }
}
