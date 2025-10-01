using System;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mindfulness Program";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness Program!\n");
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1) Breathing Activity");
                Console.WriteLine("2) Reflection Activity");
                Console.WriteLine("3) Listing Activity");
                Console.WriteLine("4) Exit");
                Console.Write("Enter your choice (1-4): ");

                string choice = Console.ReadLine();
                Activity activity = null;

                switch (choice)
                {
                    case "1": activity = new BreathingActivity(); break;
                    case "2": activity = new ReflectionActivity(); break;
                    case "3": activity = new ListingActivity(); break;
                    case "4": Console.WriteLine("Goodbye! Stay mindful."); return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                }

                activity.StartAndRun();
            }
        }
    }
}

