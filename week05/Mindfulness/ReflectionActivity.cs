using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time you stood up for someone else.",
            "Think of a time you did something really difficult.",
            "Think of a time you helped someone in need."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What could you learn from this experience?"
        };

        public ReflectionActivity() 
            : base("Reflection", "This activity will help you reflect on times in your life when you showed strength or resilience.") { }

        protected override void RunActivity()
        {
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            PauseWithSpinner(3);

            foreach (var question in _questions)
            {
                Console.WriteLine(question);
                PauseCountdown(5);
                Console.WriteLine();
            }
        }
    }
}
