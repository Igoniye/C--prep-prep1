using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop06 World!");
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string name;
        protected int points;

        public Goal(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public virtual void RecordEvent()
        {
            Console.WriteLine($"You earned {points} points for completing {name}!");
        }

        public virtual bool IsComplete()
        {
            return false;
        }

        public virtual string GetStatus()
        {
            return "";
        }
    }

    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points)
        {
        }

        public override bool IsComplete()
        {
            return true;
        }

        public override string GetStatus()
        {
            return "[X]";
        }
    }

    public class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points)
        {
        }

        public override string GetStatus()
        {
            return "[ ]";
        }
    }

    public class ChecklistGoal : Goal
    {
        private int targetCount;
        private int currentCount;
        private int bonusPoints;

        public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
        {
            this.targetCount = targetCount;
            this.currentCount = 0;
            this.bonusPoints = bonusPoints;
        }

        public override void RecordEvent()
        {
            currentCount++;
            Console.WriteLine($"You earned {points} points for completing {name}!");
            if (currentCount == targetCount)
            {
                Console.WriteLine($"You earned a bonus of {bonusPoints} points for completing {name} {targetCount} times!");
            }
        }

        public override bool IsComplete()
        {
            return currentCount >= targetCount;
        }

        public override string GetStatus()
        {
            return $"Completed {currentCount}/{targetCount} times";
        }
    }

    public class Program
    {
        private static List<Goal> goals = new List<Goal>();
        private static int score = 0;

        static void Main(string[] args)
        {
            LoadGoals();
            while (true)
            {
                Console.WriteLine("Eternal Quest Program");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. Record event");
                Console.WriteLine("3. View goals");
                Console.WriteLine("4. View score");
                Console.WriteLine("5. Save and exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateNewGoal();
                        break;
                    case 2:
                        RecordEvent();
                        break;
                    case 3:
                        ViewGoals();
                        break;
                    case 4:
                        ViewScore();
                        break;
                    case 5:
                        SaveGoals();
                        return;
                }
            }
        }

        private static void CreateNewGoal()
        {
            Console.WriteLine("Enter goal name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter goal points:");
            int points = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter goal type (1 for simple, 2 for eternal, 3 for checklist):");
            int type = int.Parse(Console.ReadLine());
            switch (type)
            {
                case 1:
                    goals.Add(new SimpleGoal(name, points));
                    break;
                case 2:
                    goals.Add(new EternalGoal(name, points));
                    break;
                case 3:
                    Console.WriteLine("Enter target count:");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter bonus points:");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                    break;
            }
        }

        private static void RecordEvent()
        {
            Console.WriteLine("Enter goal name:");
            string name = Console.ReadLine();
            foreach (Goal goal in goals)
            {
                if (goal.name == name)
                {
                    goal.RecordEvent();
                    score += goal.points;
                    if (goal is ChecklistGoal)
                    {
                        ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                        if (checklistGoal.IsComplete())
                        {
                            score += checklistGoal.bonusPoints;
                        }
                    }
                    return;
                }
            }
            Console.WriteLine("Goal not found.");
        }

        private static void ViewGoals()
        {
            foreach (Goal goal in goals)
            {
                Console.WriteLine($"{goal.name} - {goal.GetStatus()}");
            }
        }

        private static void ViewScore()
        {
            Console.WriteLine($"Your current score is {score} points.");
        }

        private static void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                string[] lines = File.ReadAllLines("goals.txt
