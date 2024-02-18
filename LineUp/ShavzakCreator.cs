using System.Collections.Generic;

public class ShavzakCreator
{
    public Shavzak NextShavzak { get; set; }
    public List<IConstraint> Constraints { get; set; }

    public ShavzakCreator(List<Person> people)
    {
        NextShavzak = new Shavzak(people);
        Constraints = new List<IConstraint>();
        Constraints.Add(new TwiceInTheSameDay());
    }

    public void InitializePossiblePeople()
    {
        foreach (var day in NextShavzak.Days)
        {
            foreach (var shift in day.Shifts)
            {
                shift.Possibilities.AddRange(NextShavzak.People);
            }
        }
    }

    public void Run()
    {
        RunPrerequisites();
        NextShavzak = BackTracking(NextShavzak);
        Console.WriteLine(NextShavzak.ToString());
        // Consider implementing JSON file output here
    }

    private void RunPrerequisites()
    {
        //scan the preivious shavzak?
        InitializePossiblePeople();
        //remove people who cant on certain dates
    }

    private bool PropagateConstraints(Shavzak newShavzak)
    {
        foreach (var constraint in Constraints)
        {
            constraint.RunConstraint(newShavzak);
        }
        return false;
    }

    private Shavzak TakeAGuess(Shavzak newShavzak)
    {
        foreach (var day in newShavzak.Days)
        {
            foreach (var shift in day.Shifts)
            {
                if (shift.Possibilities.Count > 0)
                {
                    shift.Fill(shift.Possibilities[0]);
                    return newShavzak;
                }
            }
        }
        return newShavzak;
    }

    private Shavzak BackTracking(Shavzak newShavzak)
    {
        if (newShavzak.IsFilled())
        {
            return newShavzak;
        }
        else
        {
            PropagateConstraints(newShavzak);
            newShavzak = TakeAGuess(newShavzak);
            return BackTracking(newShavzak);
        }
        
    }
}
