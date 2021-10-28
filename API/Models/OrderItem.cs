using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderItem
    {
        [Key]
        public long OrderItemID { get; set; }
        public long OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        public Item Item { get; set; }
       
        public int Quantity { get; set; }

        
    }
}
