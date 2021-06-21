using StoreDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Cart
    {
        private StoreContext context = new StoreContext();
        private Dictionary<Product,int> cart = new Dictionary<Product, int>();
        private Dictionary<String, int> productPrices = new Dictionary<String, int>();

        /// <summary>
        /// 
        /// Takes in a product and quantity and stores it in a dictionary
        /// 
        /// </summary>
        /// <param name="product">The name of the product</param>
        /// <param name="quantity">How much of the product is in the cart</param>
        public void addToCart(Product product, int quantity)
        {
            cart.Add(product, quantity);
            
        }

        /// <summary>
        /// 
        /// Checks what product and how many are in the cart and prints it
        /// 
        /// </summary>
        public void viewCart()
        {
            int sum = 0;
            Console.WriteLine("\nItems in cart: \n");
            foreach (KeyValuePair<Product, int> s in cart)
            {
                Console.WriteLine("{1} {0} = ${2}", s.Key.ProductName, s.Value, s.Key.ProductPrice * s.Value);
                sum = sum + s.Key.ProductPrice * s.Value;
            }

            Console.WriteLine($"\nThe total cost of your cart is ${sum}\n");

        }

        /// <summary>
        /// 
        /// Finds the total cost of the cart and prints it
        /// 
        /// </summary>
        public void totalCost()
        {
            int sum = 0;

            //Instantiates a list of products from the products database
            var names = context.Products.ToList();
            foreach (StoreDBContext.Product s in names)
            {
                string name = s.ProductName;
                int price = s.ProductPrice;
                productPrices.Add(name, price);
            }

            //Finds the price of the products and adds the total
            /*foreach (KeyValuePair<string,int> product in cart)
            {
                int findPrice = productPrices[product.Key];
                int quantityTotal = findPrice * product.Value;
                sum = sum + quantityTotal;

            }*/
            Console.WriteLine($"\nThe total cost of your cart is ${sum}");
        }

        /// <summary>
        /// 
        /// Displays the user's order history
        /// 
        /// </summary>
        public void displayOrderHistory()
        {
            Console.WriteLine("\nHere is your Order History: \n");
            /*foreach (KeyValuePair<String, int> s in cart)
            {
                Console.WriteLine("{1} {0}", s.Key, s.Value);
            }*/
        }

    }
}
