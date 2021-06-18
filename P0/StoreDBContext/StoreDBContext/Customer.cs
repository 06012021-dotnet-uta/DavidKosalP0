using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDBContext
{
    public partial class Customer
    {
        public Customer()
        {
            StoreOrders = new HashSet<StoreOrder>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<StoreOrder> StoreOrders { get; set; }
    }
}
