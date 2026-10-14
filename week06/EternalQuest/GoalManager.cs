using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private readonly List<Goal> _goals = new();

    public int TotalScore { get; private set; } = 0;

    public bool HasLoadedGoals { get; private set; } = false;

    public IReadOnlyList<Goal> Goals => _goals;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
        HasLoadedGoals = true;
    }

    public bool RecordGoalEvent(
        int index,
        out int earned,
        out bool bonusJustEarned)
    {
        earned = 0;
        bonusJustEarned = false;

        if (index < 0 || index >= _goals.Count)
        {
            return false;
        }

        Goal goal = _goals[index];

        bool bonusWasAwarded =
            goal is ChecklistGoal checklistBefore &&
            checklistBefore.BonusAwarded;

        earned = goal.RecordEvent();
        TotalScore += earned;

        bonusJustEarned =
            goal is ChecklistGoal checklistAfter &&
            !bonusWasAwarded &&
            checklistAfter.BonusAwarded;

        return true;
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine(
                "No goals available. Create a goal or load saved goals first.");
            return;
        }

        Console.WriteLine("\nThe goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(_goals[i].GetListLine(i + 1));
        }
    }

    public void SaveGoals(string filePath)
    {
        List<string> lines = new()
        {
            TotalScore.ToString()
        };

        lines.AddRange(_goals.Select(goal => goal.ToSaveLine()));

        File.WriteAllLines(filePath, lines);
    }

    public void LoadGoals(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        if (lines.Length == 0)
        {
            throw new FormatException("The save file is empty.");
        }

        int savedScore;
        int firstGoalLine;
        if (int.TryParse(lines[0], out savedScore))
        {
            firstGoalLine = 1;
        }
        else
        {
            firstGoalLine = 0;
            savedScore = 0;
        }

        List<Goal> loadedGoals = new();

        for (int i = firstGoalLine; i < lines.Length; i++)
        {
            loadedGoals.Add(Goal.FromSaveLine(lines[i]));
        }

        if (firstGoalLine == 0)
        {
            savedScore = CalculateScore(loadedGoals);
        }

        _goals.Clear();
        _goals.AddRange(loadedGoals);

        TotalScore = savedScore;
        HasLoadedGoals = true;
    }

    private static int CalculateScore(List<Goal> goals)
    {
        int score = 0;

        foreach (Goal goal in goals)
        {
            if (goal is SimpleGoal simple)
            {
                if (simple.IsComplete)
                {
                    score += simple.Points;
                }
            }
            else if (goal is EternalGoal eternal)
            {
                score += eternal.TimesRecorded * eternal.Points;
            }
            else if (goal is ChecklistGoal checklist)
            {
                score += checklist.CompletedCount * checklist.Points;

                if (checklist.BonusAwarded)
                {
                    score += checklist.BonusPoints;
                }
            }
        }

        return score;
    }
}
