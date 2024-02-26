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
    private Person findNextAvailablePerson(Shift shift){
        //finds the next available person to shift, removes people who cant and removes that person when returning him
        List<Person> originalPossibilities= shift.Possibilities.ToList<Person>();
        foreach(Person person in originalPossibilities){
            if(person.MaxShiftsPerWeek > person.CurrentShifts){
                shift.Possibilities.Remove(person);
                return person;
            }else{
                shift.Possibilities.Remove(person);
            }
        }
        return null;
    }

    private Shavzak TakeAGuess(Shavzak newShavzak)
    {
        foreach (var day in newShavzak.Days)
        {
            foreach (var shift in day.Shifts)
            {
                if (shift.Possibilities.Count > 0)
                {
                    Person person_to_fill = findNextAvailablePerson(shift);
                    shift.Fill(person_to_fill);
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
