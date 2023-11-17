namespace WarehouseSim
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            //User Variables, you can change these
            var startingdocks=1;
            var testtill = 15;
            var frequency = .25;


            //Simulation Space
            double max = 0;
            var best = 0;
            
            for (int docks = startingdocks; docks < testtill+1; docks++)
            {
                Printer stats = new Printer();

                //Works best with 4 or 6 docks and a truck arriving with a 25% chance each turn.
                //Revenue between 25k and 30k
                Warehouse sim = new Warehouse(docks, stats, frequency);
                sim.Run();
                stats.PrintValues();
                System.Threading.Thread.Sleep(2000);

                //Logs best run.
                if ((stats.TotalValueOfCratesUnloaded - stats.TotalOperatingCost)> max){
                    max = (stats.TotalValueOfCratesUnloaded - stats.TotalOperatingCost);
                    best = docks;
                }
            }

            Console.WriteLine("Best Run: "+max+" with "+best+" Docks");
        }
    }
}