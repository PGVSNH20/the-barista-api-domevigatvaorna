using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Beverage
{
    public virtual List<Ingredient> Ingredients { get; }
    public virtual string CupType { get; }

    public bool CheckIngredients(List<Ingredient> inputIngredients)
    {
        //TODO: Keep checking if there are more ingredients than there should be
        //Check if every required ingredient matches the sent in ingredients
        foreach (Ingredient ingredient in Ingredients)
        {
            //Countdown reaches 0 means we reached the end of the search
            int count = inputIngredients.Count;

            foreach (Ingredient inputIngredient in inputIngredients)
            {
                //Ingredient was found, moving on to next ingredient
                //TODO: Check amount needed and not just name (within percentage of required amount/share?)
                if (ingredient.Name == inputIngredient.Name && inputIngredient.Amount <= ingredient.Amount +5 && inputIngredient.Amount >= ingredient.Amount -2)
                {
                    break;
                }

                count--;

                //Ingredient wasn't found
                if (count == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }
}

public static class BeanTypes
{
    //TODO: Some proper way of making either of these easy to use?
    //public static string[] Beans = new[]
    //{
    //    "Robusta", "Jamaican", "Columbian", "Arabica", "Kopi Luwak"
    //};

    //public static List<string> BeanList = new List<string>
    //{
    //    "Robusta", "Jamaican", "Columbian", "Arabica", "Kopi Luwak"
    //};

    public enum BeanEnum 
    {
        Robusta, Jamaican, Columbian, Arabica, KopiLuwak
    };
}

public interface IEspressoMachine
{
    IEspressoMachine AddWater(int amount);
    IEspressoMachine AddMilk(int amount);
    IEspressoMachine AddBeans(string name, int amount);
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

    public EspressoMachine()
    {
        Ingredients = new List<Ingredient>();
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

    public IEspressoMachine AddBeans(string name, int amount)
    {
        Ingredients.Add(new Ingredient() { Name = name, Amount = amount });
        return this;
    }

    public Beverage ToBeverage()
    {
        //What project/assembly to look through
        Assembly assembly = typeof(EspressoMachine).Assembly;
        //The parent class that we're checking compatibility with
        Type target = typeof(Beverage);
        //Get all types that appear in the assembly that are inheriting from Beverage
        var types = assembly.GetTypes()
            .Where(type => target.IsAssignableFrom(type) && type.Name != "Beverage" && type.Name != "CustomBeverage");

        //Check ingredients for every matching class
        foreach (Type type in types)
        {
            //Instantiate a new beverage to use for checking
            var beverage = (Beverage)Activator.CreateInstance(type);
            if (beverage.CheckIngredients(Ingredients))
            {
                return beverage;
            }
        }

        //TODO: Actually send back something useful for custom beverages
        //No matching recipes found
        CustomBeverage result = new CustomBeverage();
        result.SetIngredientList(Ingredients);
        return result;
    }
}

//Coffee Types
class Espresso : Beverage
{
    public override List<Ingredient> Ingredients { get; }
    public override string CupType { get; }

    public Espresso()
    {
        Ingredients = new List<Ingredient>
        {
            new Ingredient() {Name = "Water", Amount = 25},
            new Ingredient() {Name = BeanTypes.BeanEnum.Robusta.ToString(), Amount = 25}
        };

        CupType = "Small";
    }
}

class Latte : Beverage
{
    public override List<Ingredient> Ingredients { get; }
    public override string CupType { get; }

    public Latte()
    {
        Ingredients = new List<Ingredient>
        {
            new Ingredient() {Name = BeanTypes.BeanEnum.KopiLuwak.ToString(), Amount = 25},
            new Ingredient() {Name = "Milk", Amount = 25}
        };

        CupType = "Medium";
    }
}
class Mocha : Beverage
{
    public override List<Ingredient> Ingredients { get; }
    public override string CupType { get; }

    public Mocha()
    {
        Ingredients = new List<Ingredient>
        {
            new Ingredient() {Name = "Water", Amount = 25},
            new Ingredient() {Name = BeanTypes.BeanEnum.Robusta.ToString(), Amount = 25}
        };

        CupType = "Medium";
    }
}
class Americano : Beverage
{
    public override List<Ingredient> Ingredients { get; }
    public override string CupType { get; }

    public Americano()
    {
        Ingredients = new List<Ingredient>
        {
            new Ingredient() {Name = "Water", Amount = 100},
            new Ingredient() {Name = BeanTypes.BeanEnum.Robusta.ToString(), Amount = 25}
        };

        CupType = "Medium";
    }
}
class Cappuccino : Beverage
{
    public override List<Ingredient> Ingredients { get; }
    public override string CupType { get; }

    public Cappuccino()
    {
        Ingredients = new List<Ingredient>
        {
            new Ingredient() {Name = "Water", Amount = 50},
            new Ingredient() {Name = BeanTypes.BeanEnum.Robusta.ToString(), Amount = 25},
            new Ingredient() {Name = "Milk", Amount = 50},
            new Ingredient() {Name = "MilkFoam", Amount = 50}

        };

        CupType = "Large";
    }
}
class Macchiato : Beverage
{
    public override List<Ingredient> Ingredients { get; }
    public override string CupType { get; }

    public Macchiato()
    {
        Ingredients = new List<Ingredient>
        {
            new Ingredient() {Name = "Water", Amount = 25},
            new Ingredient() {Name = BeanTypes.BeanEnum.Robusta.ToString(), Amount = 25},
            new Ingredient() {Name = "MilkFoam", Amount = 125}
        };

        CupType = "Medium";
    }
}
class CustomBeverage : Beverage
{
    public override List<Ingredient> Ingredients { get; }
    public override string CupType { get; }

    public CustomBeverage()
    {
        Ingredients = new List<Ingredient>
        {
        };
        CupType = "Medium";
    }

    public void SetIngredientList(List<Ingredient> newList)
    {
        foreach (Ingredient ingredient in newList)
        {
            Ingredients.Add(ingredient);
        }
    }
}

//Pseudo-code
//class Latte : Beverage
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