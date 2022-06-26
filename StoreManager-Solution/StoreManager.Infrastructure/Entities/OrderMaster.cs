using StoreManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.Entities
{
    public class OrderMaster : IEntity<int>
    {
        public int Id { get; set; } 
        public DateTime OrderDate { get; set; }
        public string? OrderNo { get; set; }
        public int TotalQuantity { get; set; }
        public string? Status { get; set; }
        public string? DeliveryMode { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
