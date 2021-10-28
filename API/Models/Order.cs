using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Order
    {
        [Key]
        public long OrderID { get; set; }
        public string OrderNo { get; set; }

        public int  CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        
        public string PMethod { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal GTotal { get; set; }

        

        public ICollection<OrderItem> OrdersItems { get; set; }
    }
}
