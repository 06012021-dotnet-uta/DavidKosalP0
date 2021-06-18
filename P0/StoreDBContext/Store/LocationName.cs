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
        string locationChoice;
        int locationID;
        int q;
        /// <summary>
        /// 
        /// Instantiates a list of locations from the location database and prints out the results
        /// 
        /// </summary>
        public string getStoreName()
        {
            StoreDBContext.Location currentLocation;


            Console.WriteLine("\nPlease choose a location from this list\n");

            var names = context.Locations.ToList();
            foreach(StoreDBContext.Location s in names)
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

            string location = currentLocation.ToString();

            return location;


        }

        public void listProducts()
        {
            Console.WriteLine("Here are the available products:\n");

            var joinResults = context.Inventories.Join(
                context.Products,
                invent => invent.ProductId,
                prod => prod.ProductId,
                (invent, prod) => new
                {
                    ProductId = prod.ProductId,
                    ProductName = prod.ProductName,
                    ProductLocationID = invent.LocationId,
                    ProductAmount = invent.NumberProducts,
                    ProductDesc = prod.ProductDescription,
                    ProductPrice = prod.ProductPrice
                }
            );/*
            var productList = joinResults.Where(x => x.ProductLocationID == user.currentLocation.LocationId).ToList();*/
        }

        public void decrement(int quantity)
        {
            Inventory inventory = new Inventory();
            inventory.NumberProducts = 1;
            /*locationID = (int)inventory.LocationId;
            q = (int)inventory.Quantity;*/


            using(context)
            {
                var inven = context.Inventories.FirstOrDefault(a => a.NumberProducts == 1);
                inven.NumberProducts = inven.NumberProducts - quantity;
                //context.Inventories.Update(inven);
                context.SaveChanges();
            }


        }




    }
}
