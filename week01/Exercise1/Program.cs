using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Ask the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display the result in the required format
        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }
}
