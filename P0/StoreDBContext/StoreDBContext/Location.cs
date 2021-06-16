using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDBContext
{
    public partial class Location
    {
        public Location()
        {
            StoreOrders = new HashSet<StoreOrder>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<StoreOrder> StoreOrders { get; set; }
    }
}
