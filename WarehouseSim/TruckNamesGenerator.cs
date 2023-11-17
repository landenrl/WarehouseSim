using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSim
{
    internal class TruckNamesGenerator
    {
        /// <summary>
        /// 10 random first names
        /// </summary>
        private enum FirstName
        {
            John,
            Mary,
            David,
            Lisa,
            Michael,
            Sarah,
            James,
            Jennifer,
            William,
            Jessica
        }
        /// <summary>
        /// 10 random last names
        /// </summary>
        private enum LastName
        {
            Smith,
            Johnson,
            Brown,
            Davis,
            Miller,
            Wilson,
            Moore,
            Taylor,
            Anderson,
            Thomas
        }
        /// <summary>
        /// 20 random Companies
        /// </summary>
        private enum CompanyName
        {
            ABCCompany,
            XYZCorporation,
            SunriseLogistics,
            TechSolutions,
            BlueWaveIndustries,
            GlobalTransporters,
            PrecisionTools,
            QuickShipments,
            GreenEnergyInc,
            MegaMovers,
            SilverTechGroup,
            FastForwardCo,
            RedArrowLogistics,
            GoldenHarvest,
            QuantumSystems,
            StarLineTransport,
            DiamondBuilders,
            SecureDataCorp,
            OceanicTrade,
            SwiftExpress
        }

        private static Random random = new Random();
        /// <summary>
        /// Creates a new name for each driver
        /// </summary>
        /// <returns>The first and last name of the driver</returns>
        public static string GetName()
        {
            FirstName randomFirstName = (FirstName)random.Next(Enum.GetValues(typeof(FirstName)).Length);
            LastName randomLastName = (LastName)random.Next(Enum.GetValues(typeof(LastName)).Length);

            string firstName = randomFirstName.ToString();
            string lastName = randomLastName.ToString();

            return $"{firstName} {lastName}";
        }
        /// <summary>
        /// Creates a new company that each driver works for
        /// </summary>
        /// <returns>the company the driver is working for</returns>
        public static string GetCompanyName()
        {
            CompanyName randomCompanyName = (CompanyName)random.Next(Enum.GetValues(typeof(CompanyName)).Length);

            string companyName = randomCompanyName.ToString();

            return $"{companyName}";
        }
    }
}
