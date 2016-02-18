namespace RandomNumbersGeneratorConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RandomNumbersGenerator
    {
        private static void Main(string[] args)
        {
            Console.Write("How many numbers do you need?");
            string command = Console.ReadLine();

            while (command != "END")
            {
                int numbersCount = int.Parse(command);
                Console.Write("Ok! Got that. Please tell me the lower and upper boundary from which to choose from.");
                string userInput = Console.ReadLine();

                int[] boundaries =
                    userInput.Trim()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(n => Convert.ToInt32(n))
                        .ToArray();

                int lowerBoundary = boundaries[0];
                int upperBoundary = boundaries[1];

                Random result = new Random();
                HashSet<int> randomNumbersToPrint = new HashSet<int>();

                if (numbersCount > upperBoundary)
                {
                    break;
                }

                for (int i = 0; i <= numbersCount; i++)
                {
                    // This while loop makes sure that will get wanted quantity of randomnumbers
                    while (randomNumbersToPrint.Count != numbersCount)
                    {
                        int randomNumbers = result.Next(lowerBoundary, upperBoundary);
                        randomNumbersToPrint.Add(randomNumbers);
                    }
                }

                Console.WriteLine(string.Join("--", randomNumbersToPrint));

                Console.Write("Need more numbers? Y?N: ");
                string answer = Console.ReadLine();
                if (answer.ToLower().Equals("y"))
                {
                    Console.Write("How many numbers do you need?");
                }
                else
                {
                    break;
                }

                command = Console.ReadLine();
            }
        }
    }
}