using System;
using DesignPattern.Observer;
using DesignPattern.VisitorPattern;
using DesignPattern.PublisherSubscriber;
using DesignPattern.Factory;

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
    }
}