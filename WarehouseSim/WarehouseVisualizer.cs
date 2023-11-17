using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class WarehouseVisualizer
    {
        /// <summary>
        /// Visualizer for the warehouse while its running
        /// </summary>
        /// <param name="warehouse">the warehouse its simulating</param>
        public static void PrintState(Warehouse warehouse)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("WAREHOUSE KEY: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("█ : Dock In Use");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("█ : Dock Open");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("o=o : Truck");
            Console.WriteLine("\n\n");
            Console.WriteLine("WAREHOUSE STATE:     ");
            var height = 4;
            var width = warehouse.docksCount+2;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                    {
                        Console.Write("*");
                    }
                    else if (i == height - 2)
                    {
                        if (warehouse.Docks[j - 1].truck != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }


                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\n\n\n\nTrucks waiting at Docks:");
            Console.ForegroundColor=ConsoleColor.Yellow;
            
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            for (int i = 0; i < warehouse.getWaitingTrucks(); i++) {
                Console.Write("o=o ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            System.Threading.Thread.Sleep(100);
        }
    }
}
