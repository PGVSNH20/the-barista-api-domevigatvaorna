using Xunit;

namespace BaristaApi.Tests
{
    public class FluentApiTests
    {
        //private Beverage Expected = Espresso;
        [Fact]
        public void When_AddingWaterAndBeans_Expect_Espresso()
        {
            var beverage = new EspressoMachine().AddWater(25).AddBeans(BeanTypes.BeanEnum.Robusta.ToString(), 25).ToBeverage();
            Assert.IsType<Espresso>(beverage);
        }

        [Fact]
        public void When_AddingMilkAndChocolateSyrup_Expect_Mocha()
        {
            var beverage = new EspressoMachine().AddWater(25).AddBeans(BeanTypes.BeanEnum.Robusta.ToString(), 25).AddMilk(50).AddChocolateSyrup(15).ToBeverage();
            Assert.IsType<Mocha>(beverage);
        }

        [Fact]
        public void When_AddingMilk_Expect_Latte()
        {
            var beverage = new EspressoMachine().AddWater(25).AddMilk(25).AddBeans(BeanTypes.BeanEnum.KopiLuwak.ToString(), 25).ToBeverage();
            Assert.IsType<Latte>(beverage);
        }

        [Fact]
        public void When_AddingExtraWater_Expect_Americano()
        {
            var beverage = new EspressoMachine().AddWater(100).AddBeans(BeanTypes.BeanEnum.Robusta.ToString(), 25).ToBeverage();
            Assert.IsType<Americano>(beverage);
        }

        [Fact]
        public void When_AddingMilkAndMilkFoam_Expect_Cappucino()
        {
            var beverage = new EspressoMachine().AddWater(50).AddBeans(BeanTypes.BeanEnum.Robusta.ToString(), 25).AddMilk(50).AddMilkFoam(50).ToBeverage();
            Assert.IsType<Cappuccino>(beverage);
        }

        [Fact]
        public void When_AddingMilkFoam_Expect_Macchiato()
        {
            var beverage = new EspressoMachine().AddWater(25).AddBeans(BeanTypes.BeanEnum.Robusta.ToString(), 25).AddMilkFoam(125).ToBeverage();
            Assert.IsType<Macchiato>(beverage);
        }

        [Fact]
        public void When_Whatever_Expect_CustomBeverage()
        {
            var beverage = new EspressoMachine().AddWater(35).AddBeans(BeanTypes.BeanEnum.Robusta.ToString(), 25).ToBeverage();
            Assert.IsType<CustomBeverage>(beverage);
        }
    }
}