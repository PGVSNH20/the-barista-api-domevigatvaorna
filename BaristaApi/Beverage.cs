using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using BaristaApi.Classes;

public abstract class Beverage
{
    List<Ingredient> Ingredients { get; }
    string CupType { get; }
}

public interface IEspressoMachine{
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
        Ingredients.Add(new Ingredient() { Name = "Water", Amount = amount});
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

    public IEspressoMachine BeanType (string name)
    {
        Ingredients.Add(new Ingredient() { Name = "BeanType" });
        return this;
    }

    public Beverage ToBeverage()
    {
        Assembly assembly = typeof(EspressoMachine).Assembly;
        Type target = typeof(Beverage);
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

class Latte : Beverage
{
    public Latte()
    {
        //Ingredients.Add(new Ingredient() { Name = })
        
    }

    public bool IsStuff(Ingredient[] ingredients)
    {
        bool result = true;
        return result;
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