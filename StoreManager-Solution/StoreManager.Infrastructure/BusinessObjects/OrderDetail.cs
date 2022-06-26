using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.BusinessObjects
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public OrderMaster? OrderMaster { get; set; }
        public int OrderMasterId { get; set; }
        public Item? Item { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
