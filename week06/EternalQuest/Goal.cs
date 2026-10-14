using System;
using System.Text;

public abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    protected Goal(string name, string description, int points, bool isComplete = false)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = isComplete;
    }

    public abstract int RecordEvent();
    public abstract string ToSaveLine();

    public virtual string GetListLine(int number)
    {
        string mark = IsComplete ? "x" : " ";
        return $"{number}. [{mark}] {Name} ({Description})";
    }

    public static Goal FromSaveLine(string line)
    {
        string[] parts = line.Split('|');

        string type = parts[0];
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);

        return type switch
        {
            "SimpleGoal" =>
                new SimpleGoal(
                    name,
                    description,
                    points,
                    bool.Parse(parts[4])),

            "EternalGoal" =>
                new EternalGoal(
                    name,
                    description,
                    points,
                    int.Parse(parts[4])),

            "ChecklistGoal" =>
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    int.Parse(parts[4]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6]),
                    bool.Parse(parts[7])),

            _ => throw new FormatException(
                $"Unknown goal type: {type}")
        };
    }
}
