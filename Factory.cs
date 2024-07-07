using System;

namespace DesignPattern.Factory;

// Factory pattern
// Factory pattern is a creational pattern that provides an interface to create objects in a superclass

// why we need factory pattern? although we can use new keyword to create objects, but it's not flexible enough.

static class FactoryPattern
{
    public static void Run()
    {
        Console.WriteLine("----Simple Factory pattern----");
        SimpleProtectiveEquipFactory simpleFactory = new();
        FaceMask faceMask = simpleFactory.CreateFaceMask();
        HandMask handMask = simpleFactory.CreateHandMask();
        faceMask.Protect();
        handMask.Protect();

        Console.WriteLine("---Factory pattern---");
        FaceMaskFactory faceMaskFactory = new();
        faceMaskFactory.create().Protect();
        HandMaskFactory handMaskFactory = new();
        handMaskFactory.create().Protect();

        Console.WriteLine("---Abstract Factory pattern---");
        BaseFactory chineseFactory = new ChineseFactory();
        chineseFactory.createFood().eat();
        chineseFactory.createProtectiveEquip().protect();
        BaseFactory americanFactory = new AmericanFactory();
        americanFactory.createFood().eat();
        americanFactory.createProtectiveEquip().protect();

    }
}

// objects that need to be created
public class FaceMask
{
    public void Protect()
    {
        Console.WriteLine("Face mask protect you from virus");
    }
}

// objects that need to be created
public class HandMask
{
    public void Protect()
    {
        Console.WriteLine("Hand mask protect you from virus");
    }
}


// simple factory pattern
public class SimpleProtectiveEquipFactory
{
    public FaceMask CreateFaceMask()
    {
        return new FaceMask();
    }

    public HandMask CreateHandMask()
    {
        return new HandMask();
    }
    // if other protective equipment is added, we need to modify this method and write CreateXXX.
}

// *************************
// above method is not convenient, we can use factory method pattern to solve this problem. Each Factory class is responsible for creating a specific type of object.
// facemask factory
public class FaceMaskFactory
{
    public FaceMask create()
    {
        return new FaceMask();
    }
}

// HandMask factory
public class HandMaskFactory
{
    public HandMask create()
    {
        return new HandMask();
    }
}

// *************************
// above method is not convenient, we can use abstract factory pattern to solve this problem.
// for example, chinese factroy produce Cfacemask as protective equipment and rice as food, and american factory produce protective clothing as protective equipment and hamburger as food.
public abstract class Food
{
    public abstract void eat();
}

public class Rice : Food
{
    public override void eat()
    {
        Console.WriteLine("eat rice");
    }
}

public class Hamburger : Food
{
    public override void eat()
    {
        Console.WriteLine("eat hamburger");
    }
}

public abstract class ProtectiveEquip
{
    public abstract void protect();
}

public class CFaceMask : ProtectiveEquip
{
    public override void protect()
    {
        Console.WriteLine("wear face mask");
    }
}

public class ProtectiveClothing : ProtectiveEquip
{
    public override void protect()
    {
        Console.WriteLine("wear protective clothing");
    }
}



public abstract class BaseFactory
{
    public abstract Food createFood();
    public abstract ProtectiveEquip createProtectiveEquip();
}

// chinese factory
public class ChineseFactory : BaseFactory
{
    public override Food createFood()
    {
        return new Rice();
    }

    public override ProtectiveEquip createProtectiveEquip()
    {
        return new CFaceMask();
    }
}

// american factory
public class AmericanFactory : BaseFactory
{
    public override Food createFood()
    {
        return new Hamburger();
    }

    public override ProtectiveEquip createProtectiveEquip()
    {
        return new ProtectiveClothing();
    }
}






