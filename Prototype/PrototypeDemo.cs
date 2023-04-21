//https://dev.to/kalkwst/prototype-pattern-in-c-2fnh
//https://refactoring.guru/design-patterns/prototype
//TODO: Prototype registry demo
using Shared;

namespace Prototype;

public class PrototypeDemo : IDemoApp
{
    public Task ExecuteAsync()
    {
        Person OriginalPerson = new Person();
        OriginalPerson.Age = 42;
        OriginalPerson.BirthDate = Convert.ToDateTime("1977-01-01");
        OriginalPerson.Name = "Fred Flintstone";
        OriginalPerson.IdInfo = new IdInfo(321);

        // Perform a shallow copy of OriginalPerson and assign it to ShallowCopyPerson.
        Person ShallowCopyPerson = OriginalPerson.ShallowCopy();
        // Make a deep copy of OriginalPerson and assign it to ClonedPerson.
        Person ClonedPerson = OriginalPerson.Clone() as Person;

        // Display values of OriginalPerson, ShallowCopyPerson and ClonedPerson.
        Console.WriteLine("Original values of OriginalPerson, ShallowCopyPerson, ClonedPerson:");
        Console.WriteLine("   OriginalPerson instance values: ");
        DisplayValues(OriginalPerson);
        Console.WriteLine("   ShallowCopyPerson instance values:");
        DisplayValues(ShallowCopyPerson);
        Console.WriteLine("   ClonedPerson instance values:");
        DisplayValues(ClonedPerson);

        // Change the value of OriginalPerson properties and display the values of OriginalPerson,
        // ShallowCopyPerson and ClonedPerson.
        OriginalPerson.Age = 32;
        OriginalPerson.BirthDate = Convert.ToDateTime("1900-01-01");
        OriginalPerson.Name = "Frank";
        OriginalPerson.IdInfo.IdNumber = 7878;
        Console.WriteLine("\nValues of OriginalPerson, ShallowCopyPerson and ClonedPerson after changes to OriginalPerson:");
        Console.WriteLine("   OriginalPerson instance values: ");
        DisplayValues(OriginalPerson);
        Console.WriteLine("   ShallowCopyPerson instance values (reference values have changed):");
        DisplayValues(ShallowCopyPerson);
        Console.WriteLine("   ClonedPerson instance values (everything was kept the same):");
        DisplayValues(ClonedPerson);

        return Task.CompletedTask;
    }

    public string GetMenuEntry()
    {
        return "Prototype";
    }

    public static void DisplayValues(Person p)
    {
        Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
            p.Name, p.Age, p.BirthDate);
        Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
    }
}