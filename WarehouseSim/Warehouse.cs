using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class Warehouse
    {
        public static int time = 0;
        public List<Dock> Docks; // The Warehouse docks, should be a maximum of 15
                               // Add any properties deemed necessary to complete the run of the simulation\
        public Printer stats;
        public int docksCount;
        public double frequency;

        /// <summary>
        /// New warehouse with a set amount of docks
        /// </summary>
        /// <param name="docksCount">the amount of docks</param>
        /// <param name="stats">The stats of prices, cost etc.</param>
        /// <param name="frequency">Frequency of the trucks arriving</param>
        public Warehouse(int docksCount, Printer stats, double frequency)
        {
            Docks = new List<Dock>();
            this.docksCount = docksCount;
            this.stats = stats;
            stats.NumberOfDocksOpen = docksCount;
            this.frequency = frequency;
        }

        public int getWaitingTrucks()
        {
            int trucks = 0;
            foreach (Dock dock in Docks) {
               trucks+= dock.line.Count();
            }
            return trucks;
        }

        public Dock GetDockWithShortestLine()
        {
            Dock dockWithShortestLine = null;
            int minLineCount = int.MaxValue;

            foreach (Dock dock in Docks)
            {
                int currentLineCount = dock.line.Count();

                if (currentLineCount < minLineCount)
                {
                    minLineCount = currentLineCount;
                    dockWithShortestLine = dock;
                }
            }

            return dockWithShortestLine;
        }


        public void addTruck(Truck truck) {
            GetDockWithShortestLine().line.Enqueue(truck);
        }



        /// <summary>
        /// This is the game loop, we call this to start a factory and test it.
        /// </summary>
        public void Run()
        {
            time = 0;

            Random rnd = new Random();
            //initialize how many docks we need.
            for (int i = 0; i < docksCount; i++) {
                Docks.Add(new Dock(i,stats));
            }



            //start the game loop
            while(time < 48)
            {   
                time++;

                //truck driver arrive at random time
                //By incorperating time in to the randomness this makes it so more drivers arrive in the afternoon. 
                //This is important for the section of the lab that says make a schedule for the drivers.
                if (rnd.NextDouble()*time > frequency) {
                    stats.LongestLine++;
                    addTruck(new Truck());
                }
                //driver enter qeue same tick as arrive to unload at dock




                //apply game tick to each dock
                foreach (Dock dock in Docks) {
                    //increment time in use or not in use
                    dock.Tick();
                    //unload crate
                    stats.TotalValueOfCratesUnloaded+= dock.UnloadProfit();
                    //send off truck
                    dock.SendOff();
                    



                    //lastly remove 100$ foreach dock warehouse has.
                    stats.TotalOperatingCost += 100;
                }
                WarehouseVisualizer.PrintState(this);
            }
        }
    }
}
