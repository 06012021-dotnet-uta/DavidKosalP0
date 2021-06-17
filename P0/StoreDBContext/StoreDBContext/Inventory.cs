using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDBContext
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int? PoductId { get; set; }
        public int? LocationId { get; set; }
        public int? Quantity { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Poduct { get; set; }
    }
}
