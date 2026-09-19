using System;

public class PromptGenerator
{
    public List<string> _prompts;

     public PromptGenerator()
    {
        _prompts = new List<string>();

        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What is one thing I am grateful for today?");
        _prompts.Add("What is one thing I did today but would have done differently?");
    }


    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }
}