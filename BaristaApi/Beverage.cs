using System;
using System.Collections.Generic;

public interface IBeverage{
	List<Ingredient> Ingredients { get; }
    string CupType { get; }
    IBeverage AddWater(int amount);
    IBeverage AddMilk(int amount);
    object ToBeverage();
}

public class Ingredient
{
    public string Name { get; set; }
    public int Amount { get; set; }
}

class EspressoMachine : IBeverage
{
    public List<Ingredient> Ingredients { get; }
 
    public string CupType => throw new System.NotImplementedException();

    public EspressoMachine(string type)
    {
        Ingredients = new List<Ingredient>();

        //Use type for coffee
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

    public object ToBeverage()
    {
        return this;
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