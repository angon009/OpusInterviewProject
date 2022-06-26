using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.BusinessObjects
{
    public class Item
    {
        public int Id { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? Price { get; set; }
    }
}
