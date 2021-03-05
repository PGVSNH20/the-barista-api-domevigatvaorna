using Xunit;

namespace BaristaApi.Tests
{
    public class FluentApiTests 
    {
        [Fact]
        public void When_AddingWaterAndBeans_Expect_Espresso()
        {
            var beverage = new EspressoMachine().AddWater(25).AddBeans(BeanTypes.BeanEnum.Robusta.ToString(), 25).ToBeverage();
            //Assert.IsType<Espresso>(beverage);

            //Pseudo code
            /*
            // Act
            var beverage = new EspressoMachine().AddWater().AddBeans().ToBeverage();
            // Assert
            Assert.IsType<Espresso>(beverage);
            */
        }
    }
}