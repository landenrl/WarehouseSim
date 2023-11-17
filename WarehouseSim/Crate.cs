using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class Crate
    {
        private static Random random = new Random();

        public string id;
        public double price; // The price will be a random value from $50 to $500.

        /// <summary>
        /// Crate object that has an individual ID and Price
        /// </summary>
        public Crate()
        {
            id = Guid.NewGuid().ToString();
            price = random.Next(50, 501);

        }

        public string GetId()
        {
            return id;
        }
        public double GetPrice()
        {
            return price;
        }

    }
}
