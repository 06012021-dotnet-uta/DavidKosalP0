using StoreDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class LocationName : Location
    {
        private StoreContext context = new StoreContext();
        private Account account = new Account();
        private Cart cart = new Cart();
        private DateTime timestamp;
        private int orderID;

        string locationChoice;

        /// <summary>
        /// 
        /// Creates a shopping menu to pick a store location, view cart, check out,
        /// view order history, view location history or log out
        /// 
        /// </summary>
        /// <param name="customerID">the id of the Customer who is logged in</param>
        public void shoppingMenu(int customerID)
        {
            int userChoice;
            StoreDBContext.Location currentLocation;

            while (true)
            {
                Console.WriteLine("\nPlease pick an option\n");
                Console.WriteLine("1.Pick a location\n2.View Cart\n3.Check Out\n4.Order History\n5.Location History\n6.Log out");
                userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice == 1)
                {
                    pickShopping(customerID);
                }

                else if (userChoice == 2)
                {
                    cart.viewCart();
                }

                else if (userChoice == 3)
                {
                    checkOut(customerID);
                }

                else if (userChoice == 4)
                {
                    orderHistory(customerID);
                }

                else if (userChoice == 5)
                {
                    Console.WriteLine("\nWhich location history would you like to see?\n");
                    var names = context.Locations.ToList();
                    foreach (StoreDBContext.Location s in names)
                    {
                        string name = s.LocationName;
                        Console.WriteLine(name);
                    }

                    Console.WriteLine("\n");
                    locationChoice = Console.ReadLine();
                    currentLocation = context.Locations.Where(x => x.LocationName == locationChoice).FirstOrDefault();

                    while (currentLocation == null)
                    {
                        Console.WriteLine("\nThat location does not exist. Please Enter a Valid Location\n");
                        foreach (StoreDBContext.Location s in names)
                        {
                            string name = s.LocationName;
                            Console.WriteLine(name);
                        }
                        locationChoice = Console.ReadLine();
                        currentLocation = context.Locations.Where(x => x.LocationName == locationChoice).FirstOrDefault();
                    }

                    string location = currentLocation.LocationName;
                    locationHistory(location);
                }

                else if (userChoice == 6)
                {
                    account.menuOptions();
                }

                else
                {
                    Console.WriteLine("Please pick a valid option");
                    shoppingMenu(customerID);
                }
            }
        }

        /// <summary>
        /// 
        /// Displays the order history of the store that the user picked
        /// 
        /// </summary>
        /// <param name="location">Name of location that the user picked</param>
        private void locationHistory(string location)
        {
            var locationName = context.Locations.Where(x => x.LocationName == location).FirstOrDefault();

            var locationOrder = (
                from orders in context.StoreOrders
                join loc in context.Locations
                on orders.LocationId equals loc.LocationId
                select new
                {
                    OrderId = orders.OrderId,
                    OrderTime = orders.OrderTime,
                    CustomerID = orders.CustomerId,
                    LocationID = orders.LocationId,
                    LocationName = loc.LocationName
                }
                
                );

            var locationDetails = (
                from  loc in locationOrder
                join details in context.OrderDetails
                on loc.OrderId equals details.OrderId
                select new
                {
                    OrderId = loc.OrderId,
                    OrderTime = loc.OrderTime,
                    CustomerID = loc.CustomerID,
                    LocationID = loc.LocationID,
                    LocationName = loc.LocationName,
                    ProductId = details.ProductId,
                    ProductQuantity = details.Quantity
                }
                );

            var locationFull = (
                from loc in locationDetails
                join product in context.Products
                on loc.ProductId equals product.ProductId
                select new
                {
                    OrderId = loc.OrderId,
                    OrderTime = loc.OrderTime,
                    CustomerID = loc.CustomerID,
                    LocationID = loc.LocationID,
                    LocationName = loc.LocationName,
                    ProductId = loc.ProductId,
                    ProductName = product.ProductName,
                    ProductQuantity = loc.ProductQuantity,

                }
                );

            Console.WriteLine($"\nOrder history of {locationName.LocationName}\n");
            var orderHistory = locationFull.Where(x => x.LocationName == location).FirstOrDefault();
            var orderlist = locationFull.Where(x => x.LocationName == location).ToList();

            Console.WriteLine("\nOrderID      Product     Time Ordered        Quantity        Location\n");
            foreach (var s in orderlist)
            {
                int order = s.OrderId;
                string productName = s.ProductName;
                var customer = s.CustomerID;
                var time = s.OrderTime;
                var quantity = s.ProductQuantity;
                Console.WriteLine($"{order}     {productName}       {customer}      {time.ToString()}      {quantity}");


            }

        }

        /// <summary>
        /// 
        /// Displays the order history of the customer
        /// 
        /// </summary>
        /// <param name="customerID">ID of the Customer who is logged in</param>
        private void orderHistory(int customerID)
        {
            var customer = context.Customers.Where(x => x.CustomerId == customerID).FirstOrDefault();

            var orderJoin = (
                from details in context.OrderDetails
                join order in context.StoreOrders
                on details.OrderId equals order.OrderId
                select new
                {
                    OrderId = details.OrderId,
                    ProductID = details.ProductId,
                    Quantity = details.Quantity,
                    Time = order.OrderTime,
                    CustomerID = order.CustomerId,
                    LocationID = order.LocationId
                }
                );

            var orderProductName = orderJoin.Join(
                context.Products,
                i => i.ProductID,
                p => p.ProductId,
                (i, p) => new
                {
                    OrderID = i.OrderId,
                    ProductID = i.ProductID,
                    ProductName = p.ProductName,
                    ProductPrice = p.ProductPrice,
                    Time = i.Time,
                    ProductAmount = i.Quantity,
                    CustomerID = i.CustomerID,
                    ProductLocationID = i.LocationID
                }
                );

            var orderLocationJoin = (
                from orderjoin in orderProductName
                join location in context.Locations
                on orderjoin.ProductLocationID equals location.LocationId
                select new
                {
                    OrderID = orderjoin.OrderID,
                    ProductID = orderjoin.ProductID,
                    ProductName = orderjoin.ProductName,
                    ProductPrice = orderjoin.ProductPrice,
                    Time = orderjoin.Time,
                    ProductAmount = orderjoin.ProductAmount,
                    CustomerID = orderjoin.CustomerID,
                    ProductLocationID = orderjoin.ProductLocationID,
                    ProductLocationName = location.LocationName

                }

                );


            Console.WriteLine($"\nOrder history of {customer.FirstName} {customer.LastName}\n");
            var orderHistory = orderLocationJoin.Where(x => x.CustomerID == customer.CustomerId).FirstOrDefault();
            var orderlist = orderLocationJoin.Where(x => x.CustomerID == customer.CustomerId).ToList();

            Console.WriteLine("\nOrderID      Product     Time Ordered        Quantity        Location\n");
            foreach (var s in orderlist)
            {
                int order = s.OrderID;
                string productName = s.ProductName;
                var time = s.Time;
                var quantity = s.ProductAmount;
                var location = s.ProductLocationName;
                Console.WriteLine($"{order}     {productName}       {time.ToString()}      {quantity}      {location}");


            }

        }

        /// <summary>
        /// 
        /// Clears the cart
        /// 
        /// </summary>
        /// <param name="customerID">ID of the Customer who is logged in</param>
        private void checkOut(int customerID)
        {

            cart.clearCart();

            Console.WriteLine($"\nYou have checked out\n");
        }

        /// <summary>
        /// 
        /// Stores the name of the store the user picked in a variable and
        /// then list the products of the store
        /// 
        /// </summary>
        /// <param name="customerID">ID of the Customer who is logged in</param>
        public void pickShopping(int customerID)
        {
            string pickStore;

            pickStore = getStoreName();
            listProducts(pickStore, customerID);

        }

        /// <summary>
        /// 
        /// Displays a list of stores and asks the user to input their choice
        /// 
        /// </summary>
        /// <returns>The name of the store the user picked</returns>
        public string getStoreName()
        {
            StoreDBContext.Location currentLocation;


            Console.WriteLine("\nPlease choose a location from this list\n");

            var names = context.Locations.ToList();
            foreach (StoreDBContext.Location s in names)
            {
                string name = s.LocationName;
                Console.WriteLine(name);
            }

            Console.WriteLine("\n");
            locationChoice = Console.ReadLine();
            currentLocation = context.Locations.Where(x => x.LocationName == locationChoice).FirstOrDefault();

            while (currentLocation == null)
            {
                Console.WriteLine("\nThat location does not exist. Please Enter a Valid Location\n");
                foreach (StoreDBContext.Location s in names)
                {
                    string name = s.LocationName;
                    Console.WriteLine(name);
                }
                locationChoice = Console.ReadLine();
                currentLocation = context.Locations.Where(x => x.LocationName == locationChoice).FirstOrDefault();
            }

            string location = currentLocation.LocationName;
            Console.WriteLine($"\nYou have chosen the {location} location\n");

            return location;


        }

        /// <summary>
        /// 
        /// Displays the product of the selected store and asks the user
        /// to input their choices
        /// 
        /// </summary>
        /// <param name="location">Name of location that user picked</param>
        /// <param name="customerID">ID of the Customer who is logged in</param>
        public void listProducts(string location, int customerID)
        {
            StoreDBContext.Inventory inventory = new StoreDBContext.Inventory();
            StoreDBContext.OrderDetail orderDetail = new StoreDBContext.OrderDetail();
            StoreDBContext.StoreOrder storeOrder = new StoreDBContext.StoreOrder();
            string pickProduct;
            int pickQuantity;
            int productID;
            timestamp = DateTime.Now;

            Console.WriteLine("\nHere are the available products:\n");

            var orderJoin = (
                from details in context.OrderDetails
                join order in context.StoreOrders
                on details.OrderId equals order.OrderId
                select new
                {
                    OrderId = details.OrderId,
                    ProductID = details.ProductId,
                    Quantity = details.Quantity,
                    Time = order.OrderTime,
                    CustomerID = order.CustomerId,
                    LocationID = order.LocationId
                }
                );


            var joinInvenLocation = (
                from inven in context.Inventories
                join loc in context.Locations
                on inven.LocationId equals loc.LocationId
                select new
                {
                    ProductID = inven.ProductId,
                    ProductLocationID = inven.LocationId,
                    ProductAmount = inven.NumberProducts,
                    ProductLocationName = loc.LocationName

                }
            );

            var joinProductLocation = (
                from invenloc in joinInvenLocation
                join prod in context.Products
                on invenloc.ProductID equals prod.ProductId
                select new
                {
                    ProductID = invenloc.ProductID,
                    ProductLocationID = invenloc.ProductLocationID,
                    ProductAmount = invenloc.ProductAmount,
                    ProductLocationName = invenloc.ProductLocationName,
                    ProductName = prod.ProductName,
                    ProductPrice = prod.ProductPrice,
                    ProductDescription = prod.ProductDescription
                }

                );


            var productList = joinProductLocation.Where(x => x.ProductLocationName == location).ToList();
            Console.WriteLine("Product      Price       Quantity        Description");
            foreach (var s in productList)
            {
                string products = s.ProductName;
                int price = s.ProductPrice;
                int quantity = s.ProductAmount;
                string desc = s.ProductDescription;
                Console.WriteLine($"{products}     ${price}     {quantity}      {desc}");
            }

            Console.WriteLine("\nPlease pick a product\n");
            pickProduct = Console.ReadLine();

            var product = context.Products.Where(x => x.ProductName == pickProduct).FirstOrDefault();

            while (product == null)
            {
                Console.WriteLine("\nProduct was not found. Please try again\n");
                Console.WriteLine("Product      Price       Quantity        Description");
                foreach (var s in productList)
                {
                    string products = s.ProductName;
                    int price = s.ProductPrice;
                    int quantity = s.ProductAmount;
                    string desc = s.ProductDescription;
                    Console.WriteLine($"{products}     ${price}     {quantity}      {desc}");
                }

                Console.WriteLine("\nPlease pick a product\n");
                pickProduct = Console.ReadLine();
                product = context.Products.Where(x => x.ProductName == pickProduct).FirstOrDefault();



            }

            productID = product.ProductId;
            var invQuan = context.Inventories.Join(
                context.Products,
                i => i.ProductId,
                p => p.ProductId,
                (i, p) => new
                {
                    ProductID = i.ProductId,
                    ProductName = p.ProductName,
                    ProductAmount = i.NumberProducts,
                    ProductLocationID = i.LocationId
                }
                );


            Console.WriteLine("\nPick Quantity\n");

            if (!Int32.TryParse(Console.ReadLine(), out pickQuantity))
            {
                Console.WriteLine("Quantity must be a number");
                listProducts(location, customerID);
            }


            var currentInv = invQuan.Where(x => x.ProductName == product.ProductName).FirstOrDefault();
            if (pickQuantity > currentInv.ProductAmount)
            {
                Console.WriteLine("pick quantity: " + pickQuantity);
                Console.WriteLine("quantity: " + currentInv.ProductAmount);
                Console.WriteLine("\nCan't take more quantity than the amount in Inventory");
                listProducts(location, customerID);
            }


            cart.addToCart(product, pickQuantity);
            Console.WriteLine($"\nYou have added {pickQuantity} {pickProduct} to your cart\n");
            decrement(location, productID, pickQuantity);

            context.StoreOrders.Where(x => x.LocationId == currentInv.ProductLocationID && x.CustomerId == customerID).FirstOrDefault();
            storeOrder.LocationId = currentInv.ProductLocationID;
            storeOrder.CustomerId = customerID;
            storeOrder.OrderTime = timestamp;



            context.Add(storeOrder);
            context.SaveChanges();

            orderID = storeOrder.OrderId;

            orderDetail.OrderId = orderID;
            orderDetail.ProductId = productID;
            orderDetail.Quantity = pickQuantity;

            context.Add(orderDetail);

            context.SaveChanges();

            shoppingMenu(customerID);



        }


        /// <summary>
        /// 
        /// Decreases the quantity in a store's inventory by the amount
        /// placed in the user's cart
        /// 
        /// </summary>
        /// <param name="location">Name of the location that the user selected</param>
        /// <param name="productID">ID of the product the user placed in their cart</param>
        /// <param name="quantity">Amount of the product the user placed in their cart</param>
        public void decrement(string location, int productID, int quantity)
        {
            var joinInvenLocation = (
                            from inven in context.Inventories
                            join loc in context.Locations
                            on inven.LocationId equals loc.LocationId
                            select new
                            {
                                ProductID = inven.ProductId,
                                ProductLocationID = inven.LocationId,
                                ProductAmount = inven.NumberProducts,
                                ProductLocationName = loc.LocationName

                            }
                        );

            var store = joinInvenLocation.Where(x => x.ProductLocationName == location && x.ProductID == productID).FirstOrDefault();
            var inv = context.Inventories.Where(x => x.ProductId == productID && x.LocationId == store.ProductLocationID).FirstOrDefault();
            inv.NumberProducts -= quantity;
            context.SaveChanges();




        }




    }
}
