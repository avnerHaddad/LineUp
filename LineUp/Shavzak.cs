using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;


public class Shavzak
{
    public List<Day> Days { get; set; }

    public List<Person> People { get; set; }

    public Shavzak(List<Person> people)
    {
        Days = new List<Day>();
            Days.Add(new Day("sunday"));
            Days.Add(new Day("monday"));
            Days.Add(new Day("tuesday"));
            Days.Add(new Day("wendsday"));
            Days.Add(new Day("tuersday"));
            Days.Add(new Day("friday"));
            Days.Add(new Day("saturday"));    
        People = people;
    }
    public bool IsFilled()
    {
        foreach (var day in Days)
        {
            foreach (var shift in day.Shifts)
            {
                if (!shift.IsTaken) return false;
            }
        }
        return true;
    }
    public override string ToString(){
        string shifts = "";
        foreach(Day day in Days){
            shifts+= "\n " + " " + day.name;
            foreach(Shift shift in day.Shifts){
                shifts +=  " " + shift.Type +":" +  shift.Person.Name;
            }
        }
        return shifts;

    }
}
