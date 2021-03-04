using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


public interface IBeverage
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
    IBeverage ToBeverage();
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

    public IBeverage ToBeverage()
    {
        Assembly assembly = typeof(EspressoMachine).Assembly;
        Type target = typeof(IBeverage);
        var types = assembly.GetTypes()
            .Where(type => target.IsAssignableFrom(type));

        foreach (Type type in types)
        {
            Console.WriteLine(type.Name);
            //<Beverage>type.Name.IsStuff;
            //return new type();
        }
        return new Latte();
    }
}

//Coffee Types
class Espresso : IBeverage
{
    List<Ingredient> IBeverage.Ingredients { get; }

    public string CupType => throw new NotImplementedException();
    public Espresso()
    {
        Ingredients = new List<Ingredient>();
        Ingredients.Add(new Ingredient() { Name = "Water", Amount = 25 });
    }

    
}
class Latte : IBeverage
{
    public Latte()
    {
      //  Ingredients = new List<Ingredient>();
      //  Ingredients.Add(new Ingredient() { Name = "Water", Amount = 25 });
    }

    List<Ingredient> IBeverage.Ingredients => throw new NotImplementedException();

    string IBeverage.CupType => throw new NotImplementedException();

    public bool IsStuff(Ingredient[] ingredients)
    {
        bool result = true;
        return result;
    }
}
class Mocha : IBeverage
{
    public Mocha()
    {

    }

    List<Ingredient> IBeverage.Ingredients => throw new NotImplementedException();

    string IBeverage.CupType => throw new NotImplementedException();
}
class Americano : IBeverage
{
    public Americano()
    {

    }

    List<Ingredient> IBeverage.Ingredients => throw new NotImplementedException();

    string IBeverage.CupType => throw new NotImplementedException();
}
class Cappuccino : IBeverage
{
    public Cappuccino()
    {

    }

    List<Ingredient> IBeverage.Ingredients => throw new NotImplementedException();

    string IBeverage.CupType => throw new NotImplementedException();
}
class Macchiato : IBeverage
{
    public Macchiato()
    {

    }

    List<Ingredient> IBeverage.Ingredients => throw new NotImplementedException();

    string IBeverage.CupType => throw new NotImplementedException();
}
class CustomBeverage : IBeverage
{
    public CustomBeverage()
    {

    }

    List<Ingredient> IBeverage.Ingredients => throw new NotImplementedException();

    string IBeverage.CupType => throw new NotImplementedException();
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