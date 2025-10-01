using System;
using System.Threading;

namespace MindfulnessProgram
{
    class BreathingActivity : Activity
    {
        public BreathingActivity() 
            : base("Breathing", "This activity will help you relax by guiding your breathing.") { }

        protected override void RunActivity()
        {
            DateTime end = DateTime.Now.AddSeconds(30);
            while (DateTime.Now < end)
            {
                Console.Write("Breathe in... ");
                PauseCountdown(4);
                Console.WriteLine();

                Console.Write("Breathe out... ");
                PauseCountdown(6);
                Console.WriteLine();
            }
        }
    }
}

