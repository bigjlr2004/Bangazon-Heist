﻿using System;
using System.Collections.Generic;

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
            Console.WriteLine("First things first.... How difficult is the bank gonna be to rob?");
            string BankResult = Console.ReadLine();

            int intGood;
            int BankDifficulty = 0;
            bool BankResultTryParse = int.TryParse(BankResult, out intGood);
            if (BankResultTryParse)
            {
                BankDifficulty = intGood;
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("What is your teammates name?");
            string Name = Console.ReadLine();
            Dictionary<string, Robber> robbers = new Dictionary<string, Robber>();



            while (Name != "")
            {
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

                robbers.Add(Name, robber);

                Console.WriteLine("Next teammates name? Leave blank and press enter to abort.");
                Name = Console.ReadLine();
            }

            Console.WriteLine($"There are {robbers.Count} members on this heist.");
            Console.WriteLine("");
            Console.WriteLine("How many Times would you like to run this bank scenario?");
            int intStr;
            int Successes = 0;
            int Failures = 0;
            string AttemptResult = Console.ReadLine();
            bool AttemptResultTryParse = int.TryParse(AttemptResult, out intStr);
            if (AttemptResultTryParse)
            {
                for (int i = 0; i < intStr; i++)
                {
                    int luckNumber = new Random().Next(-10, 10);
                    int TeamSkillLevel = 0;
                    BankDifficulty = intGood + luckNumber;
                    foreach (KeyValuePair<string, Robber> robber in robbers)
                    {
                        TeamSkillLevel += robber.Value.Skill;


                    }

                    Console.WriteLine($"-----------Heist Members Skill Level: {TeamSkillLevel} ------------");
                    Console.WriteLine();
                    Console.WriteLine($"-----------Bank Difficulty Level: {BankDifficulty} ------------");
                    Console.WriteLine();
                    Console.WriteLine($"-----------Bank Luck Level: {luckNumber} ------------");
                    if (TeamSkillLevel > BankDifficulty)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"-----------Bank Heist Was Successful ------------");
                        Successes += 1;
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("************ Heist Unsuccessful *************");
                        Failures += 1;
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine($"-----------Thanks for playing along.------------");
            Console.WriteLine("");
            Console.WriteLine($"-----------Bank Heist Results.------------");
            Console.WriteLine("");
            Console.WriteLine($"Successful Attempts {Successes}");
            Console.WriteLine("");
            Console.WriteLine($"Failure Attempts {Failures}");


        }
    }
}
