using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowBreathingAnimation(5);

            Console.WriteLine();
            Console.WriteLine("Breathe out...");
            ShowBreathingAnimation(5);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private void ShowBreathingAnimation(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write("\b \b");

            Thread.Sleep(500);
        }
    }
}