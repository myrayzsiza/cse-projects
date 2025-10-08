using System;

namespace EternalQuest
{
    class Program
    {
        static GoalManager manager = new GoalManager();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine() ?? "";
                switch (choice)
                {
                    case "1":
                        CreateGoalMenu();
                        break;
                    case "2":
                        RecordEventMenu();
                        break;
                    case "3":
                        manager.ListGoals();
                        Pause();
                        break;
                    case "4":
                        Console.WriteLine($"Score: {manager.Score}  |  Level: {manager.Level}");
                        manager.ShowBadges();
                        Pause();
                        break;
                    case "5":
                        Console.Write("Enter filename to save: ");
                        manager.Save(Console.ReadLine() ?? "save.txt");
                        Pause();
                        break;
                    case "6":
                        Console.Write("Enter filename to load: ");
                        manager.Load(Console.ReadLine() ?? "save.txt");
                        Pause();
                        break;
                    case "7":
                        manager.SeedDemoGoals();
                        Pause();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }

            Console.WriteLine("Thanks for playing Eternal Quest!");
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine("1) Create a new goal");
            Console.WriteLine("2) Record an event (complete/advance a goal)");
            Console.WriteLine("3) List goals");
            Console.WriteLine("4) Show score & badges");
            Console.WriteLine("5) Save game");
            Console.WriteLine("6) Load game");
            Console.WriteLine("7) Add demo goals");
            Console.WriteLine("0) Exit");
            Console.Write("Choice: ");
        }

        static void Pause()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        static void CreateGoalMenu()
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1) Simple Goal");
            Console.WriteLine("2) Eternal Goal");
            Console.WriteLine("3) Checklist Goal");
            string choice = Console.ReadLine() ?? "";
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Description: ");
            string desc = Console.ReadLine() ?? "";
            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal(name, desc, points));
                    break;
                case "2":
                    manager.AddGoal(new EternalGoal(name, desc, points));
                    break;
                case "3":
                    Console.Write("Target count: ");
                    int target = int.Parse(Console.ReadLine() ?? "1");
                    Console.Write("Bonus points: ");
                    int bonus = int.Parse(Console.ReadLine() ?? "0");
                    manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    break;
            }
        }

        static void RecordEventMenu()
        {
            manager.ListGoals();
            Console.Write("Enter goal number to record: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                manager.RecordGoalEvent(num - 1);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Pause();
        }
    }
}
