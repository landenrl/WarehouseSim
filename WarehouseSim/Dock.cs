using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class Dock
    {
        public string id; // Dock's unique id number
        public Truck truck = null; //Trucks in dock's line
        public Printer stats;
        public Queue<Truck> line;

        /// <summary>
        /// Dock object and its parameters
        /// </summary>
        /// <param name="id">the id of the dock</param>
        /// <param name="stats">stats of the dock's performance</param>
        /// <param name="entrance">entrance queue of the dock</param>
        public Dock(int id, Printer stats)
        {
            this.id = id.ToString();
            this.stats = stats;
            this.line = new Queue<Truck>();
        }
        /// <summary>
        /// Adds up the time that the dock is being used or not used
        /// </summary> 
        public void Tick() {
            if (truck == null) {  stats.TotalTimeNotInUse++; JoinLine(line.Count>0?line.Dequeue():null); return; }
            stats.TotalTimeInUse++;
        }
        /// <summary>
        /// Adds a truck to a line 
        /// </summary>
        /// <param name="truck">the truck object that is joining the line</param>
        /// <returns>Whether the truck is joining the line or not</returns>
        public bool JoinLine(Truck truck)
        {
            if (truck == null) { return false; }

            if (this.truck == null) { 
                this.truck = truck; 
                stats.TotalTrucksArrived++; 
                return true; 
            }
            return false;
        }
        /// <summary>
        /// Increments trucks proccessed value if a truck was accounted for
        /// </summary>
        public void SendOff()
        {
            if (truck != null && truck.Trailer.Count()==0) {
                truck = null;
                stats.TotalTrucksProcessed++;
            }
        }
        /// <summary>
        /// Takes the crates that were processed and adds their prices together
        /// </summary>
        /// <returns>The amount of profit obtained</returns>
        public double UnloadProfit()
        {
            if (truck == null)
            {
                return 0;
            }
            var profit = truck.Unload(line).GetPrice();
            stats.TotalValueOfCratesUnloaded += profit;
            stats.TotalCratesUnloaded++;

            return profit;
        }

    }
}
