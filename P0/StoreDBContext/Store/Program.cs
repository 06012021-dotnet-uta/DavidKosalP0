using StoreDBContext;
using System;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiates the objects of all the classes needed
            Account account = new Account();
            LocationName locationName = new LocationName();
            AvailableProducts productName = new AvailableProducts();
            Cart cart = new Cart();
            string locationChoice;
            string productChoice;
            int quantityChoice;

            Console.WriteLine("Welcome to Best Buy! Please make an account\n");
            account.createAccount();

            Console.WriteLine("\nPlease Choose a Location\n");
            locationName.getStoreName();

            Console.WriteLine("\n");
            locationChoice = Console.ReadLine();

            Console.WriteLine("\nPlease Choose a Product\n");
            productName.getAvailableProducts();

            Console.WriteLine("\n");
            productChoice = Console.ReadLine();

            Console.WriteLine("\nHow many quantities will you buy?\n");
            quantityChoice = Convert.ToInt32(Console.ReadLine());

            cart.addToCart(productChoice, quantityChoice);

            Console.WriteLine("\n");
            locationName.decrement(quantityChoice);

            Console.WriteLine("\n");
            cart.viewCart();

            Console.WriteLine("\n");
            cart.totalCost();

            Console.WriteLine("\n");
            cart.displayOrderHistory();




        }
    }
}
