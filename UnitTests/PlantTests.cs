using FluentAssertions;
using Testing;

namespace UnitTests
{
    public class PlantTests
    {
        [Theory]
        [InlineData(3.12, 0, false, 0, 3.12, 0, 0, 0, 0)]
        [InlineData(3.12, 1.12, false, 0, 2.0, 0, 1.12, 0, 0)]
        [InlineData(3.12, 4.12, false, 0, -1.0, 0, 4.12, 0, 0)]
        [InlineData(3.12, 4.12, true, 50, 0.0, -1.0, 4.12, 0, 40)]
        [InlineData(4.0, 6.0, true, 10, -1.0, -1.0, 6.0, 0, 0)]
        [InlineData(5.0, 1.0, true, 70, 1.0, 3.0, 1.0, 0, 100)]
        [InlineData(6.0, 1.0, true, 90, 0, -4.5, 1.0, 9.5, 45)]
        [InlineData(6.5, 7.0, true, 90, -1.0, -9.0, 7.0, 9.5, 0)]
        public void DistributionShouldBeOk(
            decimal plantOutput, 
            decimal household, 
            bool useBattery, 
            int batterySoC, 
            decimal expectedGrid, 
            decimal expectedBattery, 
            decimal expectedHousehold, 
            decimal expectedCharge, 
            int expectedBatterySoC)
        {
            DistributionModel model = PlantHelpers.HandlePlantOutput(plantOutput, household, useBattery, batterySoC);

            model.Grid.Should().Be(expectedGrid);
            model.Battery.Should().Be(expectedBattery);
            model.Household.Should().Be(expectedHousehold);
            model.CarCharger.Should().Be(expectedCharge);
            model.BatteryStateOfCharge.Should().Be(expectedBatterySoC);
        }
    }
}