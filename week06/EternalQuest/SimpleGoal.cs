public class SimpleGoal : Goal
{
    public SimpleGoal(
        string name,
        string description,
        int points,
        bool isComplete = false)
        : base(name, description, points, isComplete)
    {
    }
   public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        IsComplete = true;
        return Points;
    }

    public override string ToSaveLine()
{
    return $"SimpleGoal|{Name}|{Description}|{Points}|{IsComplete}";
}
}
