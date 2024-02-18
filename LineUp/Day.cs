using System.Collections.Generic;

public class Day
{
    public List<Shift> Shifts { get; set; }
    public bool IsFilled { get; set; }

    public string name {get; set;}

    public Day(string day_name)
    {
        name = day_name;
        Shifts = new List<Shift>
        {
            new Shift("morning"),
            new Shift("evening"),
            new Shift("night"),
            new Shift("konanut")
        };
        IsFilled = false;
    }
}
