using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>
        {
            new Person("Avner", "sadir", 5),
            new Person("Eilam", "sadir", 5),
            new Person("Ohad", "sadir", 5),
            new Person("goren", "sadir", 5)

        };

        ShavzakCreator shavzakCreator = new ShavzakCreator(people);
        shavzakCreator.Run();
        Console.WriteLine("done");
        
        // Implement ToString in Shavzak to print its state
        Console.WriteLine(shavzakCreator.NextShavzak.ToString());
    }
}
