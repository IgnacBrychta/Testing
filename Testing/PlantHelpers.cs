using System.Xml.XPath;

namespace Testing
{
    public static class PlantHelpers
    {
        static DistributionModel result = new DistributionModel
        {
            Grid = 0,// output - household,
            Battery = 0,
            Household = 0,//household,
            CarCharger = 0,
            BatteryStateOfCharge = 0
        };
        const int maxBatteryCapacity = 10;
        internal static bool gridFailure = false;
        public static DistributionModel HandlePlantOutput(decimal output, decimal household = 0, bool useBattery = false, int batteryStateOfCharge = 50)
        {
            gridFailure = false;
            result.Grid = output - household;
            result.Household = household;
            
            if(result.Grid < 0)
            {
                if(result.Battery > Math.Abs(result.Grid))
                {
                    result.Battery -= Math.Abs(result.Grid);
                }
                else
                {
                    result.Battery = 0;
                    gridFailure = true;
                }
            }
            else
            {
                if(result.Battery + result.Grid < maxBatteryCapacity)
                {
                    result.Battery += result.Grid;
                }
                else
                {
                    result.Battery = maxBatteryCapacity;
                }
            }

            result.BatteryStateOfCharge = (int)(result.Battery / maxBatteryCapacity * 100);

			return result;
        }
    }
}
