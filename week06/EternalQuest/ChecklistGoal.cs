public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int BonusPoints { get; private set; }
    public int CompletedCount { get; private set; }
    public bool BonusAwarded { get; private set; }

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonusPoints,
        int completedCount = 0,
        bool bonusAwarded = false)
        : base(name, description, points,
            targetCount > 0 && completedCount >= targetCount)
    {
        if (targetCount < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(targetCount),
                "Target must be at least 1.");
        }

        if (completedCount < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(completedCount));
        }

        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CompletedCount = completedCount;
        BonusAwarded = bonusAwarded || completedCount >= targetCount;
        IsComplete = completedCount >= targetCount;
    }

    public override int RecordEvent()
    {
        if (CompletedCount >= TargetCount)
        {
            return 0;
        }

        CompletedCount++;

        int earned = Points;

        if (CompletedCount >= TargetCount)
        {
            IsComplete = true;

            if (!BonusAwarded)
            {
                earned += BonusPoints;
                BonusAwarded = true;
            }
        }

        return earned;
    }

    public override string GetListLine(int number)
    {
        string mark = IsComplete ? "x" : " ";

        return $"{number}. [{mark}] {Name} ({Description}) " +
               $"-- Currently completed: {CompletedCount}/{TargetCount}";
    }

    public override string ToSaveLine()
    {
    return $"ChecklistGoal|{Name}|{Description}|{Points}|" +
           $"{TargetCount}|{BonusPoints}|{CompletedCount}|{BonusAwarded}";
    }
}
