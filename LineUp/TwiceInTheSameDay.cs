using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using Newtonsoft.Json;


public class TwiceInTheSameDay : IConstraint
{
    public bool RunConstraint(Shavzak shavzak)
    {
        foreach(Day day in shavzak.Days){
            foreach(Shift shift in day.Shifts){
                if(shift.IsTaken){
                    removeFromDayPossibilities(shift.Person, day);
                }
            }
        }
        return false;
    }
    public void removeFromDayPossibilities(Person person, Day day){
        foreach(Shift shift in day.Shifts){
            if(shift.Possibilities.Contains(person)){
                shift.Possibilities.Remove(person);
            }
        }
    }
}