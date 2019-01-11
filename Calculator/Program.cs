using System;

namespace Calculator
{

    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error

            // Use a switch statement to do the math
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry
                default:
                    break;
            }
            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing
            }
            return;
        }
    }

   /* class Program
    {
            static void Main(string[] args)
        {
            double num1 = 0;
            double num2 = 0;
            Console.WriteLine("Консольный калькулятор на C#\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Введите первое число и после ввода нажмите Enter");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе число и после ввода нажмите Enter");
            num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Выбирите операцию:");
            Console.WriteLine("\ta - Сложение");
            Console.WriteLine("\ts - Вычитание");
            Console.WriteLine("\tm - Умножение");
            Console.WriteLine("\td - Деление");
            Console.Write("Ваша операция? ");
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine($"Результат: {num1} + {num2} = " + (num1 + num2));
                    break;
                case "s":
                    Console.WriteLine($"Результат: {num1} - {num2} = " + (num1 - num2));
                    break;
                case "m":
                    Console.WriteLine($"Результат: {num1} * {num2} = " + (num1 * num2));
                    break;
                case "d":
                    while (num2 == 0)
                    {
                        Console.WriteLine("Делить на 0 нельзя. Введите другой делитель: ");
                        num2 = Convert.ToDouble(Console.ReadLine());
                    }
                    Console.WriteLine($"Результат: {num1} / {num2} = " + (num1 / num2));
                    break;
            }
            Console.Write("Нажмите на любую клавишу для того, чтобы закрыть консольный калькулятор...");
            Console.ReadKey();
        }
    }*/
}
