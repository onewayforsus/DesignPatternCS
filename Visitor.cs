using System;
using System.Reflection.Metadata.Ecma335;

namespace DesignPattern.VisitorPattern;

// take zoo as an example.
// there are abstract visitor, concrete visitor, abstract element, concrete element, object struct in this pattern.
/* basic structure:

*/

static class VisitorPattern
{
    public static void Run()
    {

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
    T Visit(LeopardSpot spot);
    T Visit(DolphinSpot spot);
}

public class LeopardSpot : IScenerySpot
{
    public T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
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
        return visitor.Visit(this);
    }

    public double GetPrice()
    {
        return 2000;
    }
}

class StudentVisitor : IVisitor<double>
{
    public double Visit(LeopardSpot spot)
    {
        return spot.GetPrice() / 2;
    }

    public double Visit(DolphinSpot spot)
    {
        return spot.GetPrice() / 2;
    }
}

class TeacherVisitor : IVisitor<double>
{
    public double Visit(LeopardSpot spot)
    {
        return spot.GetPrice() * 0.8;
    }

    public double Visit(DolphinSpot spot)
    {
        return spot.GetPrice() * 0.8;
    }
}













