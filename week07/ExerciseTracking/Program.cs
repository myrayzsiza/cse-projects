using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>()
        {
            new Running("03 Nov 2022", 30, 4.8),   // 4.8 km in 30 min
            new Cycling("03 Nov 2022", 45, 20.0),  // 20 kph for 45 min
            new Swimming("03 Nov 2022", 25, 40)    // 40 laps (50m) in 25 min
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
