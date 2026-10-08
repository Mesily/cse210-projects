using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "What are some of your personal accomplishments?",
        "What did you feel truly happy for?",

    };

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list several things.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();

        // Select a prompt randomly and remove it so it cannot be repeated.
        int promptIndex = random.Next(_prompts.Count);
        string prompt = _prompts[promptIndex];
        _prompts.RemoveAt(promptIndex);

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items.");

        DisplayEndingMessage();
    }
}