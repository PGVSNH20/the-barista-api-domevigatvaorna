using System;

namespace BaristaApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Espresso input example
            Beverage coffee = new EspressoMachine().AddWater(25).AddBeans(BeanTypes.BeanEnum.Robusta.ToString(), 27).ToBeverage();

            Console.WriteLine("Got a " + coffee.CupType.ToLower() + " cup of " + coffee.ToString()?.ToLower());

            //Latte input example
            Beverage coffee2 = new EspressoMachine().AddMilk(25).AddBeans(BeanTypes.BeanEnum.KopiLuwak.ToString(), 23).ToBeverage();
            //Beverage coffee2 = new EspressoMachine().AddMilk(25).AddBeans(b => b.Name = BeanTypes.BeanEnum.KopiLuwak && b.Amount = 25).ToBeverage();

            Console.WriteLine("Got a " + coffee2.CupType.ToLower() + " cup of " + coffee2.ToString()?.ToLower());

            //Custom input example
            Beverage coffee3 = new EspressoMachine().AddMilk(25).ToBeverage();

            Console.WriteLine("Got a " + coffee3.CupType.ToLower() + " cup of " + coffee3.ToString()?.ToLower());

            /* pseudo-code
            Espresso espresso = new EspressoMachine().AddWater(20).AddBeans(b => b.AmountInG = 5 && b.Sort = CoffeeSorts.Robusta).ToBeverage();
            //espresso is type of Espresso

            Latte latte = new EspressoMachine().AddWater(20).AddBeans(b => b.AmountInG = 7 && b.Sort = CoffeeSorts.Robusta).AddMilk().ToBeverage();
            //latte is type of Latte
             */
        }
    }
}
