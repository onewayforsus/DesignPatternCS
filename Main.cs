using System;
using DesignPattern.Observer;
using DesignPattern.VisitorPattern;
using DesignPattern.PublisherSubscriber;
using DesignPattern.Factory;
using DesignPattern.Strategy;
using DesignPattern.ChainofResponsibility;
using DesignPattern.Builder;
using DesignPattern.Decorator;

class Program
{
    static void Main(string[] args)
    {
        // Publisher and subscriber pattern
        Console.WriteLine("----Publisher and subscriber pattern-----");
        PublisherSubscriberPattern.Run();

        // Observer pattern
        Console.WriteLine("–––––Observer pattern––––");
        ObserverPattern.Run();

        // visitor pattern
        Console.WriteLine("–––––Visitor pattern----–––––");
        VisitorPattern.Run();

        // Factory pattern
        Console.WriteLine("–––––Factory pattern–––––");
        FactoryPattern.Run();

        // Strategy pattern
        Console.WriteLine("------Strategy pattern------");
        StrategyPattern.Run();

        // chain of responsibility
        Console.WriteLine("-------- Chain of Responsibility pattern-----");
        ChainofResponsibilityPattern.Run();

        Console.WriteLine("-------Builder pattern-------");
        BuilderPattern.Run();

        Console.WriteLine("--------Decorator pattern-------");
        DecoratorPattern.Run();

    }
}