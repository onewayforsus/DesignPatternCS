using System;
using System.Text;
using DesignPattern.Strategy;

namespace DesignPattern.Builder;

static class BuilderPattern
{
    public static void Run()
    {
        Employee em = new Employee.EmployeeBuilder()
                .BasicInfo("Alex", 28, "male")
                .Height(184.2)
                .Weight(79.1)
                .Address("B15 7AC")
                .Build();
        Console.WriteLine(em);

    }
}

// The builder design pattern is used to construct complex objects. Its characteristics are:
// Separation of the construction and representation of complex objects.
// The same construction process can create different representations.

// The builder pattern always combines with chain calling to construct complex instance.
// StringBuilder is an example of builder pattern.

public class Employee
{
    private string? name;
    private int? age;
    private string? gender;
    private double? height;
    private double? weight;
    private string? address;
    private string? level;

    public override string ToString()
    {
        return "Employee{" +
                "name='" + name + '\'' +
                ", age=" + age +
                ", sex='" + gender + '\'' +
                ", height=" + height + "CM" +
                ", weight=" + weight + "KG" +
                ", address='" + address + '\'' +
                ", level='" + level + '\'' +
                '}';
    }

    // set constructor as private method in order to restrict external access
    private Employee() { }

    // A builder for constructing the Employee instance.
    public class EmployeeBuilder
    {
        // most important part.  This employee is the instance that will be constructed attribute by attribute.
        Employee employee = new Employee();

        // in order to support chain calling so that return EmployeeBuilder itself
        public EmployeeBuilder BasicInfo(String name, int age, string gender)
        {
            employee.name = name;
            employee.age = age;
            employee.gender = gender;
            return this;
        }

        public EmployeeBuilder Height(double height)
        {
            employee.height = height;
            return this;
        }

        public EmployeeBuilder Weight(double weight)
        {
            employee.weight = weight;
            return this;
        }

        public EmployeeBuilder Address(string add)
        {
            employee.address = add;
            return this;
        }
        public EmployeeBuilder Level(string level)
        {
            employee.level = level;
            return this;
        }

        // final calling after constructing the instance
        public Employee Build()
        {
            return employee;
        }

    }



}



