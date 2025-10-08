using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            Console.WriteLine($"You did '{Name}'! +{Points} points.");
            return Points;
        }

        public override bool IsComplete()
        {
            return false; // eternal goals never complete
        }

        public override string GetStatus()
        {
            return "[∞]";
        }

        public override string GetStringRepresentation()
        {
            return $"Eternal:{Name},{Description},{Points}";
        }

        public static EternalGoal CreateFromString(string data)
        {
            var parts = data.Split(',');
            return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
        }
    }
}
