using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScriptures("scriptures.txt");

        Random random = new Random();

        int number = random.Next(scriptures.Count);
        Scripture scripture = scriptures[number];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }
    }

    static List<Scripture> LoadScriptures(string fileName)
    {
        List<Scripture> scriptures = new List<Scripture>();

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
   
            string referencePart = parts[0];
            string textPart = parts[1];

            string[] referenceParts = referencePart.Split(' ');

            string book = referenceParts[0];

            string[] chapterVerse = referenceParts[1].Split(':');

            int chapter = int.Parse(chapterVerse[0]);
            int verse = int.Parse(chapterVerse[1]);

            Reference reference = new Reference(book, chapter, verse);

            Scripture scripture = new Scripture(reference, textPart);

            scriptures.Add(scripture);
        }

        return scriptures;
    }

    
}