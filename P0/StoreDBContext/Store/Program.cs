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
            int customerID;



            Console.WriteLine("Welcome to Best Buy! Please make an account\n");
            account.menuOptions();
            customerID = account.cID;

            locationName.shoppingMenu(customerID);



        }
    }
}
