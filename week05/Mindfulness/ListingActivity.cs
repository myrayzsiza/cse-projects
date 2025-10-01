using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "List as many things as you can that you are grateful for.",
            "List as many people as you can who have helped you.",
            "List as many skills as you can that you’ve learned."
        };

        public ListingActivity() 
            : base("Listing", "This activity will help you think of positive aspects of your life.") { }

        protected override void RunActivity()
        {
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("You have 15 seconds. Start listing!");
            DateTime end = DateTime.Now.AddSeconds(15);

            List<string> responses = new List<string>();
            while (DateTime.Now < end)
            {
                if (Console.KeyAvailable)
                {
                    string response = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(response))
                        responses.Add(response);
                }
            }

            Console.WriteLine($"\nYou listed {responses.Count} items!");
        }
    }
}
