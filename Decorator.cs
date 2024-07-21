using System;

namespace DesignPattern.Decorator;

public static class DecoratorPattern
{
    public static void Run()
    {
        // In this example, Coffee and Tea are  two different types of beverages.
        // MilkDecorator and SugarDecorator add extra ingredients (milk and sugar) to them and computing the total cost after adding these ingredients.
        // This allow us to add any number of decorators to the beverage without having to change original class.
        IBeverage coffee = new Coffee();
        Console.WriteLine($"{coffee.GetDescription()} Cost: {coffee.GetCost()}");

        IBeverage coffeeWithMilk = new MilkDecorator(new Coffee());
        Console.WriteLine($"{coffeeWithMilk.GetDescription()} Cost: {coffeeWithMilk.GetCost()}");

        IBeverage teaWithMilkAndSugar = new SugarDecorator(new MilkDecorator(new Tea()));
        Console.WriteLine($"{teaWithMilkAndSugar.GetDescription()} Cost: {teaWithMilkAndSugar.GetCost()}");

    }
}

// Why the abstract interface of decorator have to implement IBeverage while having a member of IBeverage.
// 1. Type consistency: Implementing IBeverage ensure that there are the same interface between the decorator instance and the instance decorated by the decorator(another decorator instance or concrete entity).
//      because they are the same type from user's perspective.

// 2. functionality extending: Holding a member variable of type IBeverage allows the abstract decorator to delegate the call to the next
// object in the chain (another decorator or a concrete component) before or after executing its own behavior. 
// This design makes it possible to dynamically add new functionality to an object, forming a chain of decorators, with each decorator able to add its own unique functionality.

// beverage interface
public interface IBeverage
{
    string GetDescription();
    double GetCost();
}

// concrete beverage
public class Coffee : IBeverage
{
    public string GetDescription()
    {
        return "Coffee";
    }

    public double GetCost()
    {
        return 1.99;
    }
}

public class Tea : IBeverage
{
    public string GetDescription()
    {
        return "Tea";
    }

    public double GetCost()
    {
        return 4.19;
    }
}

// then define abstract decorator class
public abstract class BeverageDecorator : IBeverage
{
    protected IBeverage beverage;
    public BeverageDecorator(IBeverage beverage)
    {
        this.beverage = beverage;
    }
    public abstract string GetDescription();
    public abstract double GetCost();
}

// concrete decorator: milk
public class MilkDecorator : BeverageDecorator
{
    public MilkDecorator(IBeverage beverage) : base(beverage) { }
    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Milk";
    }

    public override double GetCost()
    {
        return beverage.GetCost() + 0.5;
    }

}

// concrete decorator : Sugar
public class SugarDecorator : BeverageDecorator
{
    public SugarDecorator(IBeverage beverage) : base(beverage) { }
    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Sugar";
    }
    public override double GetCost()
    {
        return beverage.GetCost() + 0.2;
    }
}



