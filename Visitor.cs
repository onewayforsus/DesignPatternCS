using System;
using System.Reflection.Metadata.Ecma335;

namespace DesignPattern.VisitorPattern;

// take zoo as an example.
// there are abstract visitor, concrete visitor, abstract element, concrete element, object struct in this pattern.
/* basic structure:
    * 1. abstract element: IScenerySpot
    * 2. concrete element: LeopardSpot, DolphinSpot
    * 3. abstract visitor: IVisitor<T>
    * 4. concrete visitor: StudentVisitor, TeacherVisitor
    * 5. object struct: Zoo
*/

static class VisitorPattern
{
    public static void Run()
    {
        Zoo zoo = new();
        // add spots
        zoo.Add(new LeopardSpot());
        zoo.Add(new DolphinSpot());

        // zoo accept different visitors

        // accept student visitor
        System.Console.WriteLine("student visitor price: " + zoo.Accept(new StudentVisitor()));

        // accept teacher visitor
        System.Console.WriteLine("teacher visitor price: " + zoo.Accept(new TeacherVisitor()));

    }
}

class Zoo {
    private List<IScenerySpot> list = new();

    public double Accept(IVisitor<double> visitor)
    {
        double total = 0;
        foreach (var spot in list)
        {
            total += spot.Accept(visitor);
        }
        return total;
    }

    public void Add(IScenerySpot spot)
    {
        list.Add(spot);
    }

    public void Remove(IScenerySpot spot)
    {
        list.Remove(spot);
    }

}



// abstract element : scenery spot
public interface IScenerySpot
{
    // accept visitor
    T Accept<T>(IVisitor<T> visitor);
    // get ticket price
    double GetPrice();
}

// abstract visitor
public interface IVisitor<T>
{
    T VisitLeopardSpot(LeopardSpot spot);
    T VisitDolphinSpot(DolphinSpot spot);
}

public class LeopardSpot : IScenerySpot
{
    public T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.VisitLeopardSpot(this);
    }

    public double GetPrice()
    {
        return 1500;
    }
}

public class DolphinSpot : IScenerySpot
{
    public T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.VisitDolphinSpot(this);
    }

    public double GetPrice()
    {
        return 2000;
    }
}

class StudentVisitor : IVisitor<double>
{
    public double VisitLeopardSpot(LeopardSpot spot)
    {
        return spot.GetPrice() * 0.5;
    }

    public double VisitDolphinSpot(DolphinSpot spot)
    {
        return spot.GetPrice() / 2;
    }
}

class TeacherVisitor : IVisitor<double>
{
    public double VisitLeopardSpot(LeopardSpot spot)
    {
        return spot.GetPrice();
    }

    public double VisitDolphinSpot(DolphinSpot spot)
    {
        return spot.GetPrice();
    }
}













