using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDBContext
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            StoreOrders = new HashSet<StoreOrder>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<StoreOrder> StoreOrders { get; set; }
    }
}
