using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeduSopModel.Model
{
    [Table("Orders")]
   public class Order
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerMessage { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }
        public string CustomerId { get; set; }
    //    public virtual ApplicationUsser User { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
