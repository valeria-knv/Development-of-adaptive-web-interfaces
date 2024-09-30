using System;
using System.IO;


class MenuItems
{
    enum MenuOption
    {
        Invalid = 0,
        DisplayWords = 1,
        Addition = 2,
        Exit = 3
    }

    public static bool exit;

    static void Main(string[] args)
    {
        exit = false;

        while (!exit)
        {
            Console.WriteLine("Menu:\n\n1. Output the specified number of words from the text.\n2. Perform a mathematical operation (addition).\n3. Exit.\n");
            Console.Write("Select the menu item: ");

            if (int.TryParse(Console.ReadLine(), out int choiceInt) && Enum.IsDefined(typeof(MenuOption), choiceInt))
            {
                MenuOption choice = (MenuOption)choiceInt;

                switch (choice)
                {
                    case MenuOption.DisplayWords:
                        DisplayWords();
                        break;
                    case MenuOption.Addition:
                        Addition();
                        break;
                    case MenuOption.Exit:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong choice. Try again.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wrong choice. Try again.\n");
            }
        }
    }


    static void DisplayWords()
    {
        const string filePath = "Lorem ipsum.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.\n");
            Pause();
            return;
        }

        string[] words = ReadFileWords(filePath);

        if (words.Length == 0)
        {
            Console.WriteLine("The file is empty or contains incorrect data.\n");
            Pause();
            return;
        }

        Console.Write("\nEnter the number of words to display: ");

        if (int.TryParse(Console.ReadLine(), out int wordCount) && wordCount > 0)
        {
            wordCount = Math.Min(wordCount, words.Length) - 1;

            Console.WriteLine(string.Join(" ", words.Take(wordCount)));
        }
        else
        {
            Console.WriteLine("\nInvalid input. Enter the correct number.");
        }

        Pause();
    }

    static string[] ReadFileWords(string path)
    {
        try
        {
            string text = File.ReadAllText(path);
            return text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exeption: {ex.Message}\n");
            return Array.Empty<string>();
        }
    }

    static void Addition ()
    {
        double number1 = GetNumberFromUser("\nEnter the first number: ");
        double number2 = GetNumberFromUser("Enter the second number: ");

        double result = number1 + number2;
        Console.WriteLine($"Addition result: {number1} + {number2} = {result}");

        Pause();
    }

    static double GetNumberFromUser(string prompt)
    {
        double number;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("\nInvalid input. Enter the correct number.");
            }
        }
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue.\n");
        Console.ReadKey(intercept: true);
    }
}
