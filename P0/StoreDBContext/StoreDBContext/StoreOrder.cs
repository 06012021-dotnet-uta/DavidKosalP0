using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDBContext
{
    public partial class StoreOrder
    {
        public StoreOrder()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderTime { get; set; }
        public int? CustomerId { get; set; }
        public int? LocationId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
