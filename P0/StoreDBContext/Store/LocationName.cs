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
        private Cart cart = new Cart();

        string locationChoice;

        public void shoppingMenu()
        {
            int userChoice;


            while (true)
            {
                Console.WriteLine("Please pick an option\n");
                Console.WriteLine("1.Pick a location\n2.View Cart\n3.Check Out\n4.Order History\n5.Location History\n6.Log out");
                userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice == 1)
                {
                    pickShopping();
                }

                else if(userChoice == 2)
                {
                    cart.viewCart();
                }

                else if(userChoice == 3)
                {
                    checkOut();
                }
            }
        }

        private void checkOut()
        {
            throw new NotImplementedException();
        }

        public void pickShopping()
        {
            string pickStore;

            pickStore = getStoreName();
            listProducts(pickStore);

        }

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
                Console.WriteLine("\nLocation was not found. Please try again\n");
                getStoreName();
            }

            string location = currentLocation.LocationName;

            return location;


        }

        public void listProducts(string location)
        {

            string pickProduct;
            int pickQuantity;
            int productID;

            Console.WriteLine("\nHere are the available products:\n");

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
            foreach (var s in productList)
            {
                string products = s.ProductName;
                int price = s.ProductPrice;
                int quantity = s.ProductAmount;
                Console.WriteLine($"{products}     ${price}     {quantity}");
            }

            Console.WriteLine("\nPlease pick a product\n");
            pickProduct = Console.ReadLine();
            var product = context.Products.Where(x => x.ProductName == pickProduct).FirstOrDefault();
            productID = product.ProductId;

            Console.WriteLine("\nPick Quantity\n");
            pickQuantity = Convert.ToInt32(Console.ReadLine());

            cart.addToCart(product, pickQuantity);
            Console.WriteLine($"\nYou have added {pickQuantity} {pickProduct} to your cart\n");
            decrement(location, productID, pickQuantity);
            shoppingMenu();

        }



        public void decrement(string location, int productID, int quantity)
        {
            StoreDBContext.Inventory inv = new StoreDBContext.Inventory();
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
            inv.LocationId = store.ProductLocationID;
            inv.ProductId = store.ProductID;
            inv.NumberProducts = store.ProductAmount - quantity;
            context.Inventories.Update(inv);
            context.SaveChanges();



        }




    }
}
