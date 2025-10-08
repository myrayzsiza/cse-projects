using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points)
        {
            _completed = false;
        }

        public override int RecordEvent()
        {
            if (_completed)
            {
                Console.WriteLine("Goal already completed.");
                return 0;
            }
            _completed = true;
            Console.WriteLine($"You completed '{Name}'! +{Points} points.");
            return Points;
        }

        public override bool IsComplete()
        {
            return _completed;
        }

        public override string GetStatus()
        {
            return _completed ? "[X]" : "[ ]";
        }

        public override string GetStringRepresentation()
        {
            return $"Simple:{Name},{Description},{Points},{_completed}";
        }

        public static SimpleGoal CreateFromString(string data)
        {
            var parts = data.Split(',');
            var goal = new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]));
            goal._completed = bool.Parse(parts[3]);
            return goal;
        }
    }
}
