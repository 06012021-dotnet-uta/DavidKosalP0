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
            if (!cart.ContainsKey(product))
            {
                cart.Add(product, quantity);
            }
            else
            {
                cart[product] += quantity;
            }
           
            
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
        /// Clears the cart
        /// 
        /// </summary>
        public void clearCart()
        {
            cart.Clear();
        }


    }
}
