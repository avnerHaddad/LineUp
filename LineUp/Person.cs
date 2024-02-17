using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int MaxShiftsPerWeek { get; set; }
    public bool WasInSofashShift { get; set; }
    public int CurrentShifts { get; set; }
    public List<string> ProhibitedShiftTypes { get; set; }
    public List<Shift> AvailableShifts { get; set; }

    public Person(string name, string type, int maxShiftsPerWeek)
    {
        Name = name;
        Type = type;
        MaxShiftsPerWeek = maxShiftsPerWeek;
        WasInSofashShift = false;
        CurrentShifts = 0;
        ProhibitedShiftTypes = new List<string>();
        AvailableShifts = new List<Shift>(); // Initialize with all shifts if applicable
    }

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Type: {Type}");
    }

    public void CanOnlyTake(List<Shift> shifts)
    {
        AvailableShifts = shifts;
    }

    public void CantTake(List<Shift> shifts)
    {
        foreach (var shift in shifts)
        {
            AvailableShifts.Remove(shift);
        }
    }
}
