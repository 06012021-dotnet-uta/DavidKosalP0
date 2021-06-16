using StoreDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class OrderDetail : StoreOrder
    {
        private StoreContext context = new StoreContext();

        public void orderHistory()
        {
            var names = context.StoreOrders.ToList();
            


        }

    }
}
