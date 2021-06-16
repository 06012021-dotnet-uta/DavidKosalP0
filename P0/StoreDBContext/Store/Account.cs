﻿using StoreDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Account : Customer
    {
        private StoreContext context = new StoreContext();
        private Dictionary<String, String> account = new Dictionary<String, String>();
        private string customerID;
        private string firstName;
        private string lastName;
        private string username;
        private string password;

        /// <summary>
        /// 
        /// Asks the user for Customer ID and then matches with first and last name.
        /// Asks the user for username and password and saves it in a dictionary
        /// 
        /// </summary>
        public void createAccount()
        {
            var names = context.Customers.ToList();

            //Asks the user for CustomerID and tries to match
            //first and last name with it
            Console.WriteLine("What is your Customer ID?\n");
            customerID = Console.ReadLine();
            int customerIDInt = Convert.ToInt32(customerID);

            foreach (StoreDBContext.Customer match in names)
            {
                if (customerIDInt == match.CustomerId)
                {
                    firstName = match.FirstName;
                    lastName = match.LastName;
                }
            }

            Console.WriteLine($"\nCongratulations {firstName} {lastName} on creating your account\n");

            //Asks the user to create a username and password and saves it in a dictionary
            Console.WriteLine("\nEnter your username\n");
            username = Console.ReadLine();

            Console.WriteLine("\nEnter your password\n");
            password = Console.ReadLine();

            account.Add(username, password);

        }


    }
}