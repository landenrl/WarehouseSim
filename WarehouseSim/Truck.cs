using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class Truck
    {
        public string Driver { get; set; } // The driver's name
        public string DeliveryCompany { get; set; }// The delivery company the driver works for
        public Stack<Crate> Trailer; // The crates that are in the truck's trailer
        private Dock dock;

        /// <summary>
        /// Truck object that gets a random driver, Delivery company, and amount of crates in its trailer
        /// </summary>
        public Truck()
        {
            Driver = TruckNamesGenerator.GetName();
            DeliveryCompany = TruckNamesGenerator.GetCompanyName();
            Trailer = GenerateRandomCrates();
        }

        /// <summary>
        /// Generates a random number of crates and adds them to a stack
        /// </summary>
        /// <returns>The stack of crates</returns>
        private Stack<Crate> GenerateRandomCrates()
        {
            Random random = new Random();
            int numCrates = random.Next(1, 11);
            Stack<Crate> crates = new Stack<Crate>();

            for (int i = 0; i < numCrates; i++)
            {
                crates.Push(new Crate());
            }

            return crates;
        }
        /// <summary>
        /// "Pushes" the crates into the trailer
        /// </summary>
        /// <param name="crate">The crate objects we are loading</param>
        public void Load(Crate crate)
        {
            Trailer.Push(crate);
        }
        /// <summary>
        /// Unloads the crates from the truck and collects information about each, writes the info into a CSV document
        /// </summary>
        /// <param name="line">the queue of trucks</param>
        /// <returns>the crate object and what information is stored with it</returns>
        /// <exception cref="InvalidOperationException">Throws an invalid exception in case the trailer has nothing inside</exception>
        public Crate Unload(Queue<Truck> line)
        {
            string filePath = "data.csv";
            if (Trailer.Count > 0)
            {
                Crate crate = Trailer.Pop();

                String reason = Trailer.Count > 0 ? "with more crates on the truck " : "and the truck has no more crates to unload ";
                String reason2 = line.Count > 0 ? "there are still trucks in line." : "there are no more trucks in line.";

                try
                {
                    // Create a StreamWriter to write to the CSV file
                    using (StreamWriter sw = new StreamWriter(filePath, true))
                    {
                        sw.WriteLine(Warehouse.time+","+Driver+","+DeliveryCompany+","+crate.id + "," + crate.price+","+"Crate was unloaded "+reason+reason2);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
                return crate;
            }
            else
            {
                throw new InvalidOperationException("The trailer is empty. There is nothing to unload.");
            }
        }

    }
}
