using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDBContext
{
    public partial class OrderDetail
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int? Quantity { get; set; }

        public virtual StoreOrder Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
