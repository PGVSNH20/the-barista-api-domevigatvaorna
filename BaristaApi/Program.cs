using System;

namespace BaristaApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Latte input example
            IBeverage input = new EspressoMachine().AddWater(20).AddBeans(15).AddMilk(20).ToBeverage();



            /* pseudo-code
            Espresso espresso = new EspressoMachine().AddWater(20).AddBeans(b => b.AmountInG = 5 && b.Sort = CoffeSorts.Robusta).ToBravage();
            //espresso is type of Espresso

            Latte latte = new EspressoMachine().AddWater(20).AddBeans(b => b.AmountInG = 7 && b.Sort = CoffeSorts.Robusta).AddMilk().ToBravage();
            //latte is type of Latte
             */
        }
    }
}
