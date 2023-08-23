using System;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Plan Your Heist!");
            //Create a way to store a single team member. A team member will have a name, a skill Level and a courage factor. The skill Level will be a positive integer and the courage factor will be a decimal between 0.0 and 2.0.
            // Prompt the user to enter a team member's name and save that name.
            Console.WriteLine("---------------------");
            Console.WriteLine("Let's get started.");
            Console.WriteLine("---------------------");
            Console.WriteLine("What is your teammates name?");
            string Name = Console.ReadLine();
            Console.WriteLine($"What is {Name}'s skill level?");

            bool Correct = false;
            int Skill = 0;
            double Courage = 0;

            while (!Correct)
            {
                try
                {
                    Skill = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Skill level is a positive number.");
                    Console.WriteLine($"Please reenter {Name}'s skill level.");
                    if (Skill != 0)
                    {
                        Correct = true;
                    }
                }
            }

            while (!Correct)
            {
                try
                {

                    Console.WriteLine("What is your teammates Courage Level on a scale of 0 - 2.0?");
                    double response = double.Parse(Console.ReadLine());
                    while (response < 0 || response > 2)
                    {
                        Console.WriteLine("Courage level is a positive number between 0 - 2.0");
                        Console.WriteLine($"Please reenter {Name}'s courage level.");
                        response = double.Parse(Console.ReadLine());
                    }
                    Courage = response;
                    Correct = true;
                }
                catch
                {
                    Console.WriteLine("Courage level is a positive number between 0 - 2.0");
                    Console.WriteLine($"Please reenter {Name}'s courage level.");
                    if (Courage != 0)
                    {
                        Correct = true;
                    }
                }
            }

            var robber = new Robber(Name, Skill, Courage);


            Console.WriteLine($"Name:  {robber.Name}");
            Console.WriteLine("");
            Console.WriteLine($"Skill Level:  {robber.Skill}");
            Console.WriteLine("");
            Console.WriteLine($"Courage:  {robber.Courage}");
            Console.WriteLine("");
            Console.WriteLine("");


            // Prompt the user to enter a team member's skill level and save that skill level with the name.
            // Prompt the user to enter a team member's courage factor and save that courage factor with the name.
            // Display the team member's information.
        }
    }
}
