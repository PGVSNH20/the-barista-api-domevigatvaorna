using System;
using System.Collections.Generic;

public abstract class Beverage
{
    List<Ingredient> Ingredients { get; }
    string CupType { get; }
}

public interface IEspressoMachine
{
    IEspressoMachine AddWater(int amount);
    IEspressoMachine AddMilk(int amount);
    IEspressoMachine AddBeans(int amount);
    IEspressoMachine BeanType(string name);
    Beverage ToBeverage();
}

public class Ingredient
{
    public string Name { get; set; }
    public int Amount { get; set; }
}


public class EspressoMachine : IEspressoMachine
{
    public List<Ingredient> Ingredients { get; }
    //public static string[] BeanTypes { get; set; }

    public string CupType => throw new System.NotImplementedException();

    public EspressoMachine()
    {
        Ingredients = new List<Ingredient>();
        //BeanTypes = new string[] { "Robusta", "Jamaican", "Columbian", "Arabica", "Kopi Luwak" };
    }

    public IEspressoMachine AddWater(int amount)
    {
        Ingredients.Add(new Ingredient() { Name = "Water", Amount = amount });
        return this;
    }

    public IEspressoMachine AddMilk(int amount)
    {
        Ingredients.Add(new Ingredient() { Name = "Milk", Amount = amount });
        return this;
    }
    public IEspressoMachine AddBeans(int amount)
    {
        Ingredients.Add(new Ingredient() { Name = "Bean", Amount = amount });
        return this;
    }

    public IEspressoMachine BeanType(string name)
    {
        Ingredients.Add(new Ingredient() { Name = name });
        return this;
    }

    public Beverage ToBeverage()
    {
        int? beverageType = null;

        /*foreach (var item in collection)
		{
			if (true)
			{

			}
		}*/
        switch (beverageType)
        {
            case 1:
                return new Espresso();
            case 2:
                return new Latte();
            case 3:
                return new Mocha();
            case 4:
                return new Americano();
            case 5:
                return new Cappuccino();
            case 6:
                return new Macchiato();
            default:
                return new CustomBeverage();
        }
    }
}

//Coffee Types
class Espresso : Beverage
{
    public Espresso()
    {

    }
}
class Latte : Beverage
{
    public Latte()
    {
        //Ingredients.Add(new Ingredient() { Name = })
    }
}
class Mocha : Beverage
{
    public Mocha()
    {

    }
}
class Americano : Beverage
{
    public Americano()
    {

    }
}
class Cappuccino : Beverage
{
    public Cappuccino()
    {

    }
}
class Macchiato : Beverage
{
    public Macchiato()
    {

    }
}
class CustomBeverage : Beverage
{
    public CustomBeverage()
    {

    }
}

//class Latte : IBeverage
//{
//    public List<string> Ingredients => throw new System.NotImplementedException();

//    public string CupType => throw new System.NotImplementedException();

//    public void AddWater(int amount) => throw new System.NotImplementedException();
//    public void AddMilk(int amount)
//    {
//        throw new System.NotImplementedException();
//    }

//    public EspressoMachine ToBeverage()
//    {
//        throw new System.NotImplementedException();
//    }
//}