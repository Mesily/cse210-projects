using System;

class Program
{
    static void Main(string[] args)
    {
       List<int> numbers = new List<int>();

        int number = 1;
        double sum = 0;
        int min = int.MaxValue;
        int max = int.MinValue;
        int count = 0;
        double average = 0;
        Console.WriteLine("Enter a list of numbers, type 0 when finished ");
        while (number != 0)
        {
            Console.WriteLine("Enter a number ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);

            if (number != 0)
            {
                numbers.Add(number);
                sum += number;
                count++;

           average = sum / count;
                if (number < min)
                {
                    min = number;

                }

                if (number > max)
                {
                    max = number;
                }
            }
        }
        foreach (int values in numbers)
        {
            Console.WriteLine("Entered numbers are: ");
             Console.WriteLine(string.Join(", ", numbers));        }
        Console.WriteLine($"The Count is: {count}");
        Console.WriteLine($"The Sum is: {sum}");
        Console.WriteLine($"The Average number is: {average}");
        Console.WriteLine($"The Largest number is: {max}");
    }
}