using System;
using System.Collections.Generic;

public interface IBeverage{
	List<Ingredient> Ingredients { get; }
    string CupType { get; }
    IBeverage AddWater(int amount);
    IBeverage AddMilk(int amount);
    IBeverage AddBeans(int amount, string type);
    object ToBeverage();
}

public class Ingredient
{
    public string Name { get; set; }
    public int Amount { get; set; }
}


public class EspressoMachine : IBeverage
{
    public List<Ingredient> Ingredients { get; }
    public static string[] BeanTypes { get; set; }
 
    public string CupType => throw new System.NotImplementedException();

    public EspressoMachine()
    {
        Ingredients = new List<Ingredient>();
        BeanTypes = new string[] { "Robusta", "Jamaican", "Columbian", "Arabica", "Kopi Luwak" };
    }

    public IBeverage AddWater(int amount)
    {
        Ingredients.Add(new Ingredient() { Name = "Water", Amount = amount});
        return this;
    }

    public IBeverage AddMilk(int amount)
    {
        Ingredients.Add(new Ingredient() { Name = "Milk", Amount = amount });
        return this;
    }
    public IBeverage AddBeans(int amount, string type)
    {
        Ingredients.Add(new Ingredient() { Name = type, Amount = amount });
        return this;
    }

    public object ToBeverage()
    {
        return this;
    }
}

class Latte : EspressoMachine
{
    public Latte()
    {
        Ingredients.Add(new Ingredient() { Name = })
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