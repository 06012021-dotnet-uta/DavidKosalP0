using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDBContext
{
    public partial class Product
    {
        public Product()
        {
            StoreOrders = new HashSet<StoreOrder>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }

        public virtual ICollection<StoreOrder> StoreOrders { get; set; }
    }
}
