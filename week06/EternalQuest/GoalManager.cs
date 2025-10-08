using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private int _level;
        private List<string> _badges;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _level = 1;
            _badges = new List<string>();
        }

        public int Score { get { return _score; } }
        public int Level { get { return _level; } }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
            CheckBadge("First goal created!");
        }

        public void ListGoals()
        {
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                var g = _goals[i];
                Console.WriteLine($"{i+1}) {g.GetStatus()} {g.Name} - {g.Description}");
            }
        }

        public void RecordGoalEvent(int index)
        {
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid goal number.");
                return;
            }

            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            CheckLevelUp();
            CheckBadge("Score reached 1000!", _score >= 1000);
            CheckBadge("5 goals completed!", CountCompletedGoals() >= 5);
        }

        private void CheckLevelUp()
        {
            int newLevel = (_score / 1000) + 1;
            if (newLevel > _level)
            {
                _level = newLevel;
                Console.WriteLine($"🎉 You leveled up! You are now Level {_level}!");
            }
        }

        private void CheckBadge(string badgeName, bool condition = true)
        {
            if (condition && !_badges.Contains(badgeName))
            {
                _badges.Add(badgeName);
                Console.WriteLine($"🏅 Badge earned: {badgeName}");
            }
        }

        private int CountCompletedGoals()
        {
            int count = 0;
            foreach (var g in _goals)
            {
                if (g.IsComplete()) count++;
            }
            return count;
        }

        public void ShowBadges()
        {
            if (_badges.Count == 0)
                Console.WriteLine("No badges earned yet.");
            else
            {
                Console.WriteLine("Badges earned:");
                foreach (var b in _badges)
                    Console.WriteLine($"- {b}");
            }
        }

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                writer.WriteLine(_level);
                writer.WriteLine(string.Join(";", _badges));
                foreach (var g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine("Game saved.");
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            using (StreamReader reader = new StreamReader(filename))
            {
                _score = int.Parse(reader.ReadLine());
                _level = int.Parse(reader.ReadLine());
                _badges = new List<string>(reader.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries));
                _goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Simple:"))
                        _goals.Add(SimpleGoal.CreateFromString(line.Substring(7)));
                    else if (line.StartsWith("Eternal:"))
                        _goals.Add(EternalGoal.CreateFromString(line.Substring(8)));
                    else if (line.StartsWith("Checklist:"))
                        _goals.Add(ChecklistGoal.CreateFromString(line.Substring(10)));
                }
            }
            Console.WriteLine("Game loaded.");
        }

        public void SeedDemoGoals()
        {
            AddGoal(new SimpleGoal("Run Marathon", "Complete a full marathon", 1000));
            AddGoal(new EternalGoal("Read Scriptures", "Read scriptures daily", 100));
            AddGoal(new ChecklistGoal("Attend Temple", "Go to temple 5 times", 50, 5, 200));
        }

        public int GoalCount() => _goals.Count;
    }
}
