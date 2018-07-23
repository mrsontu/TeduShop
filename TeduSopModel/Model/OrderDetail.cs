using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeduSopModel.Model
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order=1)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order=2)]
        public int ProductID { get; set; }

        public int Quantity { get; set; }//SỐ lượng

        public decimal Price { get; set; } //Giá

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

    }
}
