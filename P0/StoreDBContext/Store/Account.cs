using StoreDBContext;
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
        private int signInChoice;
        private string fname;
        private string lname;
        private string usernameSignIn;
        private string passwordSignIn;
        private string usernameCreate;
        private string passwordCreate;
        public int cID { get; set; }

        /// <summary>
        /// 
        /// Creates a menu to log in or register
        /// 
        /// </summary>
        public void menuOptions()
        {
            Console.WriteLine("Please Choose an Number for an Option\n");
            Console.WriteLine("1.Sign in\n2.Register\n3.Exit\n");
            signInChoice = Convert.ToInt32(Console.ReadLine());

            if (signInChoice == 1)
            {
                signIn();

            }

            else if (signInChoice == 2)
            {
                createAccount();
                menuOptions();
            }

            else if (signInChoice == 3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Not a Valid Choice. Please choose a number\n");
                menuOptions();
            }


        }

        /// <summary>
        /// 
        /// Asks the user to sign in to their username and password
        /// 
        /// </summary>
        public void signIn()
        {
            StoreDBContext.Customer customer = new StoreDBContext.Customer();
            StoreDBContext.Customer userNameAttempt;
            StoreDBContext.Customer passwordAttempt;


            Console.WriteLine("\nEnter your username:\n");
            usernameSignIn = Console.ReadLine();

            //Checks if the username exists
            userNameAttempt = context.Customers.Where(x => x.Username == usernameSignIn).FirstOrDefault();

            while (userNameAttempt == null)
            {
                Console.WriteLine("\nUsername was not found. Please try again\n");
                Console.WriteLine("Enter your username:\n");
                usernameSignIn = Console.ReadLine();
                userNameAttempt = context.Customers.Where(x => x.Username == usernameSignIn).FirstOrDefault();
            }

            //Checks if the password exists
            Console.WriteLine("\nEnter your password:\n");
            passwordSignIn = Console.ReadLine();

            passwordAttempt = context.Customers.Where(x => x.Password == passwordSignIn && x.Username == usernameSignIn).FirstOrDefault();

            while (passwordAttempt == null)
            {
                Console.WriteLine("\nPassword was not found. Please try again\n");
                Console.WriteLine("Enter your password:\n");
                passwordSignIn = Console.ReadLine();
                passwordAttempt = context.Customers.Where(x => x.Password == passwordSignIn && x.Username == usernameSignIn).FirstOrDefault();
            }

            customer = context.Customers.Where(x => x.Username == usernameSignIn).FirstOrDefault();

            
            cID = customer.CustomerId;
        }

        /// <summary>
        /// 
        /// Asks the user for Customer ID and then matches with first and last name.
        /// Asks the user for username and password and saves it in a dictionary
        /// 
        /// </summary

        public void createAccount()
        {
            StoreDBContext.Customer customer = new StoreDBContext.Customer();
            //Asks the user for CustomerID and tries to match
            //first and last name with it

            /*Console.WriteLine("Do you want to log in or register? \n1. Login\n 2. Register");
            choices = Console.ReadLine();*/

            Console.WriteLine($"Please enter your first name: \n");
            fname = Console.ReadLine();

            Console.WriteLine($"Please enter your last name: \n");
            lname = Console.ReadLine();

            //Asks the user to create a username and password and saves it in a dictionary
            Console.WriteLine("\nCreate a username\n");
            usernameCreate = Console.ReadLine();
            var nameCheck = context.Customers.Where(x => x.Username == usernameCreate).FirstOrDefault();
            if (nameCheck != null)
            {
                Console.WriteLine("\nThat username already exists. Please try again\n");
                createAccount();
            }

            Console.WriteLine("\nCreate a password\n");
            passwordCreate = Console.ReadLine();

            //Adds the new Customer Account to the database
            customer.FirstName = fname;
            customer.LastName = lname;
            customer.Username = usernameCreate;
            customer.Password = passwordCreate;

            context.Customers.Add(customer);
            context.SaveChanges();

            Console.WriteLine("\nYour account has been created\n");
            Console.WriteLine($"Your customer id is {customer.CustomerId}\n");


        }


    }
}
