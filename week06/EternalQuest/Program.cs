using System;
using System.IO;

internal class Program
{
    private const string DefaultSaveFile = "goals.txt";

    private static readonly GoalManager Manager = new();

    private static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine($"You have {Manager.TotalScore} points.");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    Manager.ListGoals();
                    break;

                case "3":
                    RecordGoalEvent();
                    break;

                case "4":
                    SaveGoals();
                    break;

                case "5":
                    LoadGoals();
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine(
                        "Invalid choice. Please select a number from 1 to 6.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    private static void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int type = ReadInt(
            "Which type of goal would you like to create? ", 1, 3);

        string name = ReadRequiredText(
            "What is the name of your goal? ");

        string description = ReadRequiredText(
            "What is a short description of it? ");

        int points = ReadInt(
            "How many points is this goal worth? ", 1, int.MaxValue);

        Goal goal;

        switch (type)
        {
            case 1:
                goal = new SimpleGoal(name, description, points);
                break;

            case 2:
                goal = new EternalGoal(name, description, points);
                break;

            case 3:
                int target = ReadInt(
                    "How many times must you complete it to earn the bonus? ",
                    1, int.MaxValue);

                int bonus = ReadInt(
                    "How many bonus points will you earn? ",
                    0, int.MaxValue);

                goal = new ChecklistGoal(
                    name, description, points, target, bonus);
                break;

            default:
                return;
        }

        Manager.AddGoal(goal);

        Console.WriteLine("Goal created successfully.");
        Console.WriteLine("Remember to save your goals to keep them.");
    }

    private static void RecordGoalEvent()
    {
        if (Manager.Goals.Count == 0)
        {
            Console.WriteLine(
                "No goals are available. Create a goal or load saved goals first.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("The goals are:");

        for (int i = 0; i < Manager.Goals.Count; i++)
        {
            Console.WriteLine(Manager.Goals[i].GetListLine(i + 1));
        }

        int choice = ReadInt(
            "Which goal did you accomplish? ",
            1, Manager.Goals.Count);

        Goal selectedGoal = Manager.Goals[choice - 1];

        bool wasComplete = selectedGoal.IsComplete;

        bool success = Manager.RecordGoalEvent(
            choice - 1,
            out int earned,
            out bool bonusJustEarned);

        if (!success)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        if (selectedGoal is SimpleGoal && wasComplete)
        {
            Console.WriteLine(
                "This simple goal has already been completed.");
            return;
        }

        if (selectedGoal is ChecklistGoal checklist &&
            checklist.CompletedCount >= checklist.TargetCount &&
            wasComplete)
        {
            Console.WriteLine(
                "This checklist goal has already reached its target.");
            return;
        }

        Console.WriteLine($"Congratulations! You have earned {earned} points!");

        if (bonusJustEarned &&
            selectedGoal is ChecklistGoal completedChecklist)
        {
            Console.WriteLine(
                $"You also earned a bonus of {completedChecklist.BonusPoints} points!");
        }

        Console.WriteLine(
            $"You now have {Manager.TotalScore} points.");
    }

    private static void SaveGoals()
    {
        string filePath = ReadFilePath(
            "Enter the file name to save to (press Enter for goals.txt): ");

        try
        {
            Manager.SaveGoals(filePath);

            Console.WriteLine(
                $"Goals saved successfully to {Path.GetFullPath(filePath)}");
        }
        catch (Exception ex) when (
            ex is IOException ||
            ex is UnauthorizedAccessException ||
            ex is ArgumentException)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    private static void LoadGoals()
    {
        string filePath = ReadFilePath(
            "Enter the file name to load (press Enter for goals.txt): ");

        try
        {
            Manager.LoadGoals(filePath);

            Console.WriteLine(
                $"Goals loaded successfully. You have {Manager.TotalScore} points.");

           
            Manager.ListGoals();
        }
        catch (Exception ex) when (
            ex is IOException ||
            ex is UnauthorizedAccessException ||
            ex is FormatException ||
            ex is ArgumentException ||
            ex is IndexOutOfRangeException)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    private static string ReadFilePath(string prompt)
    {
        Console.Write(prompt);

        string? filePath = Console.ReadLine()?.Trim();

        return string.IsNullOrWhiteSpace(filePath)
            ? DefaultSaveFile
            : filePath;
    }

    private static string ReadRequiredText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            string? value = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            Console.WriteLine("This field cannot be empty.");
        }
    }

    private static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value) &&
                value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine(
                $"Please enter a whole number between {min} and {max}.");
        }
    }
}
