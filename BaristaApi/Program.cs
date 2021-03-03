﻿using System;

namespace BaristaApi
{
    class Program
    {
        static void Main(string[] args)
        {
            EspressoMachine espresso = new EspressoMachine().AddWater(20).AddBeans(20).ToBeverage() as EspressoMachine;
            Latte latte = new EspressoMachine().AddWater(20).AddBeans(15, EspressoMachine.BeanTypes.).AddMilk(20).ToBeverage() as Latte;

            /* pseudo-code
            Espresso espresso = new EspressoMachine().AddWater(20).AddBeans(b => b.AmountInG = 5 && b.Sort = CoffeSorts.Robusta).ToBravage();
            //espresso is type of Espresso

            Latte latte = new EspressoMachine().AddWater(20).AddBeans(b => b.AmountInG = 7 && b.Sort = CoffeSorts.Robusta).AddMilk().ToBravage();
            //latte is type of Latte
             */
        }
    }
}
