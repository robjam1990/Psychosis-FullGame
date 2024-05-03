using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Psychosis.Combat;

namespace Psychosis
{
    public class Encounters
    {
        Random rnd = new Random();
        //Generic

        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You are attacked by a thief!");
            Console.WriteLine("You do not get a chance to run away!");
            Fight(false, "Thief", 7, 1, 1);

        }
        public static void BanditEncounter()
        {
            Console.Clear();
            Console.WriteLine("You are attacked by a bandit!");
            Console.WriteLine("What will you do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run");
            string input = Console.ReadLine();
            if (input == "2")
            {
                Console.WriteLine("You do not get a chance to run away!");
                Fight(false, "Bandit", 10, 2, 2);
            }
            else
            {
                Fight(false, "Bandit", 10, 2, 2);
            }
        }
        public static void BrigandEncounter()
        {
            Console.Clear();
            Console.WriteLine("You are attacked by a brigand!");
            Console.WriteLine("What will you do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run");
            string input = Console.ReadLine();
            if (input == "2")
            {
                Console.WriteLine("You do not get a chance to run away!");
                Fight(false, "Brigand", 15, 3, 3);
            }
            else
            {
                Fight(false, "Brigand", 15, 3, 3);
            }
        }
        public static void HighwaymanEncounter()
        {
            Console.Clear();
            Console.WriteLine("You are attacked by a highwayman!");
            Console.WriteLine("What will you do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run");
            string input = Console.ReadLine();
            if (input == "2")
            {
                Console.WriteLine("You do not get a chance to run away!");
                Fight(false, "Highwayman", 20, 4, 4);
            }
            else
            {
                Fight(false, "Highwayman", 20, 4, 4);
            }
        }
        public static void AnimalEncounter()
        {
            Console.Clear();
            Console.WriteLine("You are attacked by a wild animal!");
            Console.WriteLine("What will you do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run");
            string input = Console.ReadLine();
            if (input == "2")
            {
                Console.WriteLine("You do not get a chance to run away!");
                Fight(false, "Wild Animal", 5, 1, 1);
            }
            else
            {
                Fight(false, "Wild Animal", 5, 1, 1);
            }
        }
        public static void BossEncounter()
        {
            Console.Clear();
            Console.WriteLine("You are attacked by a bandit leader!");
            Console.WriteLine("What will you do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run");
            string input = Console.ReadLine();
            if (input == "2")
            {
                Console.WriteLine("You do not get a chance to run away!");
                Fight(false, "Bandit Leader", 25, 5, 5);
            }
            else
            {
                Fight(false, "Bandit Leader", 25, 5, 5);
            }
        }

        //tools
        public static void RandomEncounter()
        {
            Random rnd = new Random();
            int randomNum = rnd.Next(1, 6);
            if (randomNum == 1)
            {
                FirstEncounter();
            }
            else if (randomNum == 2)
            {
                BanditEncounter();
            }
            else if (randomNum == 3)
            {
                BrigandEncounter();
            }
            else if (randomNum == 4)
            {
                HighwaymanEncounter();
            }
            else if (randomNum == 5)
            {
                AnimalEncounter();
            }
            else
            {
                BossEncounter();
            }
        }

    }
}
