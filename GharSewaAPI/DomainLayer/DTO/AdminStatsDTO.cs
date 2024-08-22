using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class AdminStatsDTO
    {
        public int ApprovedBookingsCount { get; set; }
        public int UnapprovedBookingsCount { get; set; }
        public int CategoryCount { get; set; }
    }
}
