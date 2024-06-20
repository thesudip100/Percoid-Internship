using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Shop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShopID { get; set; }

        [Required]
        public string ShopName { get; set; } = "";

        [Required]
        public string ShopAddress { get; set; } = "";

        [Required]
        public string ShopCategory { get; set; } = "";

        [Required]
        public string OpenTime { get; set; } = "";

        [Required]
        public string CloseTime { get; set; } = "";
    }
}
