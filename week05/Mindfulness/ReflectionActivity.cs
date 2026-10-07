using System;
using System.Threading;

class ReflectionActivity : Activity
{
    private string[] _prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone.",
        "Think of something you learned recently."
    };

    private string[] _questions =
    {
        "Why was this experience meaningful to you?",
        "How did you feel when this happened?",
        "What did you learn from this experience?",
        "How can you apply what you learned in the future?",
        "What made this experience difficult?",
        "Who helped you during this experience?"
    };

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Length)];

        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.WriteLine("When you are ready, press Enter to begin.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = _questions[random.Next(_questions.Length)];

            Console.WriteLine();
            Console.WriteLine(question);
            Console.Write("> ");

            Console.ReadLine();
        }

        DisplayEndingMessage();
    }
}