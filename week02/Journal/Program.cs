using System;

class Program
{
    static void Main(string[] args)
     {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(prompt);
                // Console.Write("> ");
                string response = Console.ReadLine();

                Entry choiceEntry = new Entry();

                choiceEntry._date = DateTime.Now.ToShortDateString();
                choiceEntry._promptText = prompt;
                choiceEntry._entryText = response;

                theJournal.AddEntry(choiceEntry);
            }
            else if (choice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename: ");
                string file = Console.ReadLine();

                theJournal.SaveToFile(file);
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename: ");
                string file = Console.ReadLine();

                theJournal.LoadFromFile(file);
            }
        }
    }
}