using System;

namespace DesignPattern.Strategy;
// sutable situations : 1. need to switch algorithm freely. 2. algorithm rules need to be masked.
// shortage: 1. the number of classes increase. If there are more than 4 concrete strategies, consider mix multiple patterns. 2. all strategy class must expose to upper module.
// To address the drawbacks of the strategy pattern, we can use other patterns to correct these issues, 
// such as the factory method pattern, proxy pattern, or flyweight pattern. I will summarize the use of other design patterns later.
public static class StrategyPattern
{
    public static void Run()
    {
        Car[] cars = new Car[]{
            new Car(1,2),
            new Car(3,4),
            new Car(55,7),
            new Car(16,0)
        };
        // sort elements in cars
        var ctx = new Context();
        ctx.sortCar(cars);

        // print elements
        foreach (var car in cars)
            Console.WriteLine(car);


        SecurityMan[] men = { new SecurityMan("Bob", 3, 186), new SecurityMan("Alexanda", 1, 174), new SecurityMan("Pony", 6, 192) };
        // stratege pattern
        var cctx = new Context<SecurityMan>(new SecurityManExperienceComparer());
        cctx.sortWhatYouWant(men);
        foreach (var man in men) Console.WriteLine(man);

    }
}

// Assuming the company wants to buy some cars and recruit several security guards.
//But the boss wants to have a car list ordered by price and a list of security guard names sorted in decending order by seniority

//comparable interface needs to implement `int compareTo(T o)`, return negetive value when current object is less than `T o`, 0 means two objects are equal, positive value when the former is greater than the latter.

// car sorted by price
public class Car : IComparable<Car>
{
    // car price
    public int price;
    // petrol tank capacity
    public int capacity;

    public Car(int price, int capacity)
    {
        this.price = price;
        this.capacity = capacity;
    }
    public int CompareTo(Car? other)
    {
        if (this.price < other.price)
            return -1;
        else if (this.price == other.price)
            return 0;
        else
            return 1;
    }

    public override string ToString()
    {
        return $"Car{{ price = {this.price}, capacity = {capacity} }}";
    }

}

public class SecurityMan : IComparable<SecurityMan>
{

    // name
    private string name;
    // seniority
    public int experience;
    // height
    public int height;

    public SecurityMan(string name, int experience, int height)
    {
        this.name = name;
        this.experience = experience;
        this.height = height;
    }

    public int CompareTo(SecurityMan? other)
    {
        if (this.experience < other.experience)
            return -1;
        else if (this.experience == other.experience)
            return 0;
        else
            return 1;
    }

    public override string ToString()
    {
        return $"SecurityMan{{ name = {name}, experience = {experience}, height = {height} }}";
    }
}

// Context used to encapsulate sorting function
public class Context
{
    public void sortCar(Car[] cars)
    {
        for (int i = 0; i < cars.Length; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < cars.Length; j++)
            {
                minIndex = cars[i].CompareTo(cars[j]) > 0 ? j : minIndex;
            }
            var tem = cars[i];
            cars[i] = cars[minIndex];
            cars[minIndex] = tem;
        }
    }

    public void sortSecurityMan(SecurityMan[] men)
    {
        for (int i = 0; i < men.Length; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < men.Length; j++)
            {
                minIndex = men[i].CompareTo(men[j]) > 0 ? j : minIndex;
            }
            var tem = men[i];
            men[i] = men[minIndex];
            men[minIndex] = tem;
        }
    }

}

// Above example have many limits. if boss wants to have a list of car ordered by capacities, we have modify Car and Context


// complement different sort strategies with strategy pattern. we use IComparer interface which used to compare two objects.

// strategy 1 : Sort the cars by price
public class CarPriceComparer : IComparer<Car>
{
    public int Compare(Car? x, Car? y)
    {
        if (x.price < y.price) return -1;
        else if (x.price > y.price) return 1;
        return 0;
    }
}

// strategy 2 : Sort the cars by capacity
public class CarCapacityComparer : IComparer<Car>
{
    public int Compare(Car? x, Car? y)
    {
        if (x.capacity < y.capacity) return -1;
        else if (x.capacity > y.capacity) return 1;
        return 0;
    }
}

// strategy 3 : sort security man by seniority
public class SecurityManExperienceComparer : IComparer<SecurityMan>
{
    public int Compare(SecurityMan? x, SecurityMan? y)
    {
        if (x.experience < y.experience) return -1;
        else if (x.experience > y.experience) return 1;
        return 0;
    }
}

// strategy 4 : sort security man by height
public class SecurityManHeightComparer : IComparer<SecurityMan>
{
    public int Compare(SecurityMan? x, SecurityMan? y)
    {
        if (x.height < y.height) return -1;
        else if (x.height > y.height) return 1;
        return 0;
    }
}

// stragegies switch context
public class Context<T>
{
    private IComparer<T> comparer;

    public Context(IComparer<T> comparer)
    {
        this.comparer = comparer;
    }

    public void sortWhatYouWant(T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                minIndex = this.comparer.Compare(arr[i], arr[j]) > 0 ? j : minIndex;
            }
            T tem = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = tem;
        }
    }
}