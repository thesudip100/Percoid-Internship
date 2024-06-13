using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCRUD.Models
{
    public class CustomerGoods
    {
        [Key]
        public int CGId { get; set; }

        [Required]
        public int GoodsId { get; set; }

        [Required]
        public int Cus_id { get; set; }

        [ForeignKey("GoodsId")]
        public Goods Gds { get; set; }

        [ForeignKey("Cus_id")]
        public Customer Cust { get; set; }
    }
}
