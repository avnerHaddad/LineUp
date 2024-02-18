public class Shift
{
    public bool IsTaken { get; set; }
    public Person Person { get; set; }
    public string Type { get; set; }
    public List<Person> Possibilities { get; set; }

    public Shift(string shiftType)
    {
        IsTaken = false;
        Type = shiftType;
        Possibilities = new List<Person>();
    }

    public void Fill(Person person)
    {
        IsTaken = true;
        Person = person;
        Possibilities.Clear();
        person.CurrentShifts++;
    }
}
