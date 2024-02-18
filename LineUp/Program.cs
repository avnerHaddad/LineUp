using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>
        {
            new Person("Avner", "sadir", 1),
            new Person("Eilam", "sadir", 7),
            new Person("Ohad", "sadir", 7),
            new Person("goren", "sadir", 7),
            new Person("turkish", "sadir", 7)

        };

        ShavzakCreator shavzakCreator = new ShavzakCreator(people);
        shavzakCreator.Run();
        Console.WriteLine("done");
        
        // Implement ToString in Shavzak to print its state
        Console.WriteLine(shavzakCreator.NextShavzak.ToString());
    }
}
