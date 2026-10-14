public class EternalGoal : Goal
{
    public int TimesRecorded { get; private set; }

    public EternalGoal(
        string name,
        string description,
        int points,
        int timesRecorded = 0)
        : base(name, description, points, false)
    {
        TimesRecorded = timesRecorded;
    }

    public override int RecordEvent()
    {
        TimesRecorded++;
        return Points;
    }

    public override string GetListLine(int number)
    {
        return $"{number}. [ ] {Name} ({Description})";
    }

    public override string ToSaveLine()
    {
    return $"EternalGoal|{Name}|{Description}|{Points}|{TimesRecorded}";
    }
}
