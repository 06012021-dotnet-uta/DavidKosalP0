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


        public void menuOptions()
        {
            Console.WriteLine("Please Choose an Number for an Option\n");
            Console.WriteLine("1.Sign in\n2.Register\n3.Exit\n");
            signInChoice = Convert.ToInt32(Console.ReadLine());
           
                if (signInChoice == 1)
                {
                    signIn();
                }

                if (signInChoice == 2)
                {
                    createAccount();
                    menuOptions();
                }
            else
            {
                Console.WriteLine("Not a Valid Choice. Please choose a number\n");
                menuOptions();
            }
            
        }

        public void signIn()
        {
            StoreDBContext.Customer userNameAttempt;
            StoreDBContext.Customer passwordAttempt;

            
                Console.WriteLine("Enter your username:\n");
                usernameSignIn = Console.ReadLine();

                userNameAttempt = context.Customers.Where(x => x.Username == usernameSignIn).FirstOrDefault();
            
            while (userNameAttempt == null)
            {
                Console.WriteLine("\nUsername was not found. Please try again\n");
                Console.WriteLine("Enter your username:\n");
                usernameSignIn = Console.ReadLine();
                userNameAttempt = context.Customers.Where(x => x.Username == usernameSignIn).FirstOrDefault();
            }

            
                Console.WriteLine("Enter your password:\n");
                passwordSignIn = Console.ReadLine();

                passwordAttempt = context.Customers.Where(x => x.Password == passwordSignIn).FirstOrDefault();
            
            while (passwordAttempt == null)
            {
                Console.WriteLine("\nPassword was not found. Please try again\n");
                Console.WriteLine("Enter your password:\n");
                passwordSignIn = Console.ReadLine();
                passwordAttempt = context.Customers.Where(x => x.Password == passwordSignIn).FirstOrDefault();
            }




        }

        /// <summary>
        /// 
        /// Asks the user for Customer ID and then matches with first and last name.
        /// Asks the user for username and password and saves it in a dictionary
        /// 
        /// </summary

        public void createAccount()
        {

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

            Console.WriteLine("\nCreate a password\n");
            passwordCreate = Console.ReadLine();

            Customer c = new Customer();
            c.FirstName = fname;
            c.LastName = lname;
            c.Username = usernameCreate;
            c.Password = passwordCreate;

            context.Customers.Update(c);
            context.SaveChanges();

            Console.WriteLine("Your account has been created\n");


        }


    }
}
