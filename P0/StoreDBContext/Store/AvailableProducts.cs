using StoreDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class AvailableProducts : Product
    {
        private StoreContext context = new StoreContext();

        /// <summary>
        /// 
        /// Instantiates a list of products from the products database and prints out the results
        /// with a name and a price
        /// 
        /// </summary>
        public void getAvailableProducts()
        {
            var names = context.Products.ToList();
            foreach (StoreDBContext.Product s in names)
            {
                string name = s.ProductName;
                int price = s.ProductPrice;
                Console.WriteLine($"{name} is ${price}");
            }


        }
    }
}
