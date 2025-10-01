using System;
using System.IO;
using System.Threading;

namespace MindfulnessProgram
{
    abstract class Activity
    {
        private string _name;
        private string _description;
        private int _durationSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void StartAndRun()
        {
            Console.Clear();
            ShowStartingMessage();
            _durationSeconds = PromptForDuration();
            Console.WriteLine();
            Console.WriteLine("Get ready to begin...");
            PauseWithSpinner(3);

            RunActivity();

            ShowEndingMessage();
            SaveLog();
            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the main menu...");
            Console.ReadLine();
        }

        protected abstract void RunActivity();

        private void ShowStartingMessage()
        {
            Console.WriteLine($"--- {_name} Activity ---\n");
            Console.WriteLine(_description + "\n");
        }

        private void ShowEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Good job!");
            PauseWithSpinner(2);
            Console.WriteLine($"You have completed the {_name} activity for {_durationSeconds} seconds.");
            PauseWithSpinner(2);
        }

        private int PromptForDuration()
        {
            Console.Write("How many seconds would you like to do this activity? ");
            return int.Parse(Console.ReadLine());
        }

        protected void PauseWithSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                foreach (char c in "|/-\\")
                {
                    Console.Write(c);
                    Thread.Sleep(250);
                    Console.Write("\b \b");
                }
            }
        }

        protected void PauseCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        private void SaveLog()
        {
            File.AppendAllText("activity_log.txt", $"{DateTime.Now}: {_name} for {_durationSeconds} seconds\n");
        }
    }
}
