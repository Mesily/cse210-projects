using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Running running = new Running(
            new DateTime(2026, 10, 15), 30, 5.0);

        Cycling cycling = new Cycling(
            new DateTime(2026, 10, 15), 45, 20.0);

        Swimming swimming = new Swimming(
            new DateTime(2026, 10, 15), 40, 30);

        List<Activity> activities = new List<Activity>
        {
            running,
            cycling,
            swimming
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
