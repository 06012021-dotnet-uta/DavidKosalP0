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
        int locationID;
        int q;
        /// <summary>
        /// 
        /// Instantiates a list of locations from the location database and prints out the results
        /// 
        /// </summary>
        public void getStoreName()
        {
            Console.WriteLine("Please choose a location from this list");

            var names = context.Locations.ToList();
            foreach(StoreDBContext.Location s in names)
            {
                string name = s.LocationName;
                Console.WriteLine(name);
            }
            

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
