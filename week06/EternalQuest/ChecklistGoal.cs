using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _completedCount;
        private int _targetCount;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonus) 
            : base(name, description, points)
        {
            _completedCount = 0;
            _targetCount = targetCount;
            _bonus = bonus;
        }

        public override int RecordEvent()
        {
            if (_completedCount >= _targetCount)
            {
                Console.WriteLine("Checklist goal already completed.");
                return 0;
            }

            _completedCount++;
            int totalPoints = Points;

            if (_completedCount == _targetCount)
            {
                totalPoints += _bonus;
                Console.WriteLine($"You completed '{Name}'! +{Points} points +{_bonus} bonus points!");
            }
            else
            {
                Console.WriteLine($"You made progress on '{Name}'! +{Points} points ({_completedCount}/{_targetCount})");
            }

            return totalPoints;
        }

        public override bool IsComplete()
        {
            return _completedCount >= _targetCount;
        }

        public override string GetStatus()
        {
            return $"[{_completedCount}/{_targetCount}]";
        }

        public override string GetStringRepresentation()
        {
            return $"Checklist:{Name},{Description},{Points},{_completedCount},{_targetCount},{_bonus}";
        }

        public static ChecklistGoal CreateFromString(string data)
        {
            var parts = data.Split(',');
            var goal = new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[4]), int.Parse(parts[5]));
            goal._completedCount = int.Parse(parts[3]);
            return goal;
        }
    }
}
