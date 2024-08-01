using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class feedbackDTO
    {
        [Key]
        public string? feedbackby { get; set; }
        public string? feedbackfor { get; set; }
        public string? Message { get; set; }
    }
}
