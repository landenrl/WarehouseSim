using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    using System;

    public class Printer
    {
        public int NumberOfDocksOpen { get; set; }
        public int LongestLine { get; set; }
        public int TotalTrucksProcessed { get; set; }
        public int TotalCratesUnloaded { get; set; }
        public double TotalValueOfCratesUnloaded { get; set; }
        public int TotalTimeInUse { get; set; }
        public int TotalTimeNotInUse { get; set; }
        public int TotalTrucksArrived { get; set; }
        public double TotalOperatingCost { get; set; }

        public void PrintValues()
        {
            Console.Clear();
            Console.WriteLine("Number of docks open: " + NumberOfDocksOpen);
            Console.WriteLine("Number of trucks arrived: " + TotalTrucksArrived);
            Console.WriteLine("Longest line at any loading dock: " + LongestLine);
            Console.WriteLine("Total number of trucks processed: " + TotalTrucksProcessed);
            Console.WriteLine("Total number of crates unloaded: " + TotalCratesUnloaded);
            Console.WriteLine("Total value of crates unloaded: " + TotalValueOfCratesUnloaded);
            Console.WriteLine("Average value of each crate unloaded: " + TotalValueOfCratesUnloaded/TotalCratesUnloaded);
            Console.WriteLine("Average value of each truck unloaded: " + TotalValueOfCratesUnloaded / TotalTrucksProcessed);
            Console.WriteLine("Total time that all docks were in use: " + TotalTimeInUse);
            Console.WriteLine("Total time that all docks was not in use: " + TotalTimeNotInUse);
            Console.WriteLine("Average time that a dock was in use: " + TotalTimeInUse / NumberOfDocksOpen);
            Console.WriteLine("Total Game Ticks: " + 48*NumberOfDocksOpen);
            Console.WriteLine("Total cost of all docks: " + TotalOperatingCost);
            Console.WriteLine("Total Revenue: " + ( TotalValueOfCratesUnloaded - TotalOperatingCost));
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }
    }

}
