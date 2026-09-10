using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(1, 101);

        int guess = -1;
        int count = 0;
        
        while (guess != magicNum)
        {
            Console.WriteLine("What is your guess? ");
            string userInput2 = Console.ReadLine();
            guess = int.Parse(userInput2);
            count += 1;

            if (magicNum > guess)
            {
                Console.WriteLine("Guess Higher");
            }
            else if (magicNum < guess)
            {
                Console.WriteLine("Guess Lower");
            }
            else
            {
                Console.WriteLine("You guessed it.");
            }
           
            }
        Console.WriteLine($"You made {count} guesses.");
    }
}