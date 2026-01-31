using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main()
        {
            // Constants
            const decimal Tax_Rate = 0.055m;

            //Counters
            int totalOperations = 0;
            Dictionary<string, int> operationCounts = new Dictionary<string, int>()
            {
                { "Add", 0 },
                { "Subtract", 0 },
                { "Multiply", 0 },
                { "Divide", 0 },
                { "Average", 0 },
                { "Tax", 0 }

            };
            double lastResult = 0; // For math operations
            decimal lastTaxResult = 0; // For money/tax operations
            bool validLastResult = false;

            bool continueRunning = true;

            do
            {
                Console.WriteLine("\nSelect operation:");
                Console.WriteLine("+ : Add");
                Console.WriteLine("- : Subtract");
                Console.WriteLine("* : Multiply");
                Console.WriteLine("/ : Divide");
                Console.WriteLine("avg : Average");
                Console.WriteLine("tax : Apply Tax");
                Console.WriteLine("exit : Quit");

                Console.Write("Select Preferred Operation: ");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "avg":
                        double number1, number2;
                        bool validInput = false;

                        do
                        {
                            Console.Write("Enter the first number: ");
                            string input1 = Console.ReadLine();

                            Console.Write("Enter the second number: ");
                            string input2 = Console.ReadLine();

                            validInput = double.TryParse(input1, out number1) && double.TryParse(input2, out number2);

                            if (!validInput)
                                Console.WriteLine("Invalid input. Please enter valid numbers.");
                        } while (!validInput);

                        switch (choice)
                        {
                            case "+":
                                lastResult = number1 + number2;
                                Console.WriteLine($"Result: {lastResult:F3}");
                                operationCounts["Add"]++;
                                break;
                            case "-":
                                lastResult = number1 - number2;
                                Console.WriteLine($"Result: {lastResult:F3}");
                                operationCounts["Subtract"]++;
                                break;
                            case "*":
                                lastResult = number1 * number2;
                                Console.WriteLine($"Result: {lastResult:F3}");
                                operationCounts["Mutiply"]++;
                                break;
                            case "/":
                                if (number2 == 0)
                                {
                                    Console.WriteLine("You cannot divide by zero!");
                                    validLastResult = false;
                                    continue;
                                }
                                lastResult = number1 / number2;
                                Console.WriteLine($"Result: {lastResult:F3}");
                                operationCounts["Divide"]++;
                                break;
                            case "avg":
                                lastResult = (number1 + number2) / 2;
                                Console.WriteLine($"Average: {lastResult:F3}");
                                operationCounts["Average"]++;
                                break;
                        }
                        validLastResult = true;
                        totalOperations++;
                        break;

                    case "tax":
                        decimal amount;
                        do
                        {
                            Console.Write("Enter the amount: ");
                            string input = Console.ReadLine();
                            validInput = decimal.TryParse(input, out amount);
                            if (!validInput)
                                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                        } while (!validInput);

                        const decimal taxRate = 0.055m;
                        decimal tax = amount * Tax_Rate;
                        decimal total = amount + tax;
                        Console.WriteLine($"Tax: {tax:C2}, Total: {total:C2}");
                        break;

                    case "exit":
                        continueRunning = false;
                        break;

                    default:
                        Console.WriteLine("That was an invalid choice, try again.");
                        validLastResult = false;
                        break;
                }
            } while (continueRunning);

            Console.WriteLine("Thank you for using the calculator!");
        }
    }
}

