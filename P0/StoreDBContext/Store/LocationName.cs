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

        /// <summary>
        /// 
        /// Instantiates a list of locations from the location database and prints out the results
        /// 
        /// </summary>
        public void getStoreName()
        {
            var names = context.Locations.ToList();
            foreach(StoreDBContext.Location s in names)
            {
                string name = s.LocationName;
                Console.WriteLine(name);
            }
            

        }
        



    }
}
