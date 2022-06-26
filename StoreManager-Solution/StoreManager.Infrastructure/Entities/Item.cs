using StoreManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.Entities
{
    public class Item : IEntity<int>
    {
        public int Id { get; set; }
        public string? ItemCode { get; set; } 
        public string? ItemName { get; set; }
        public string? Price { get; set; }

    }
}
