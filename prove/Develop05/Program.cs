using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
    }
}
using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public abstract class Activity
    {
        protected string name;
        protected string description;
        protected int duration;

        public Activity(string name, string description, int duration)
        {
            this.name = name;
            this.description = description;
            this.duration = duration;
        }

        public virtual void Start()
        {
            Console.WriteLine($"Starting {name} activity...");
            Console.WriteLine(description);
            Console.WriteLine("Prepare to begin...");
            Pause(5);
        }

        public virtual void End()
        {
            Console.WriteLine("You have completed the activity!");
            Console.WriteLine($"Activity duration: {duration} seconds");
            Pause(5);
        }

        protected void Pause(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }

    public class BreathingActivity : Activity
    {
        public BreathingActivity(int duration) : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration)
        {
        }

        public override void Start()
        {
            base.Start();
            for (int i = 0; i < duration; i++)
            {
                Console.WriteLine("Breathe in...");
                Pause(2);
                Console.WriteLine("Breathe out...");
                Pause(2);
            }
        }
    }

    public class ReflectionActivity : Activity
    {
        private List<string> prompts;
        private List<string> questions;

        public ReflectionActivity(int duration) : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration)
        {
            prompts = new List<string>()
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };
            questions = new List<string>()
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
        }

        public override void Start()
        {
            base.Start();
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine(prompt);
            foreach (string question in questions)
            {
                Console.WriteLine(question);
                Pause(5);
            }
        }
    }

    public class ListingActivity : Activity
    {
        private List<string> prompts;

        public ListingActivity(int duration) : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration)
        {
            prompts = new List<string>()
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        public override void Start()
        {
            base.Start();
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("Start listing...");
            Pause(5);
            int count = 0;
            while (true)
            {
                Console.Write("Enter an item (or 'done' to finish): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "done")
                {
                    break;
                }
                count++;
            }
            Console.WriteLine($"You listed {count} items.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            int choice = int.Parse(Console.ReadLine());
            int duration = int.Parse(Console.ReadLine());
            Activity activity;
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity(duration);
                    break;
                case 2:
                    activity = new
