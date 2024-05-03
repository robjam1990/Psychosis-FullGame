/*
In the world of Psychosis, where adventure awaits in the vast expanses of Thear, your journey begins amidst the intricate tapestry of the Main Hall of Nexus Tavern, nestled within the bustling town of Nexus, Bractalia. Here, amidst the clinking of tankards and murmurs of patrons, your tale unfurls with boundless possibilities.
As you venture forth, prepare to navigate a fully explorable solar system, where round planets beckon exploration and discovery. Engage in tactical combat, where each move is pivotal, utilizing a limb removal system that adds depth and strategy to every encounter.
But it's not just combat that shapes your journey; immerse yourself in an ecosystem simulation where animal communication hints at the secrets of the wild. Beyond mere survival, aspire to greatness as you raise a nation to power, navigating the complexities of multi-faction warfare while managing logistics, agriculture, commerce, and succession.
Within the social fabric of Thear, navigate a bounty system that tests your mettle and reputation. Forge alliances, create hierarchies, or challenge rivals as you navigate a spectrum of loyalty, fear, respect, and morality, all under the jurisdiction of a dynamic justice system tied to territorial borders.
Time flows seamlessly, marked by day/night cycles and shifting seasons, as you engage in the construction, repair, and destruction of structures, shaping entire villages according to your will. Decide the fate of prisoners, wield influence over named locations and objects, and commandeer the aid of others to build armies or delegate tasks.
Supply and demand drive a barter system fueled by an expansive array of renewable and non-renewable resources, while an in-depth crafting system, intertwined with metallurgy, allows for the creation of powerful artifacts and tools essential for survival.
Survival itself is a challenge, with oxygen, temperature, disease, hunger, energy, sanity, hygiene, and waste all factors to consider. Grow and evolve your character through a comprehensive system of advancement and learning, utilizing futuristic customization options and genetic manipulation to craft unique personas suited to your playstyle.
In Psychosis, every choice matters, every action shapes your destiny.Embark on an odyssey through Thear, where the boundaries of reality blur, and the possibilities are as infinite as the cosmos itself.
Psychosis
A text-based game set in the world of Thear.
Copyright 2017-2024 robjam1990
@license MIT
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using static Psychosis.Player;

namespace Psychosis
{
    // Enums
    public enum Stance
    {
        Custom,       // Represents a customizable stance that allows the player to define their own combat strategy.
        Conservative, // Represents a cautious and defensive stance, prioritizing defense over offense.
        Defensive,    // Represents a defensive stance, focusing on blocking and counterattacking.
        Aggressive,   // Represents an aggressive stance, prioritizing offense over defense.
        Offensive,    // Represents an offensive stance, focusing solely on dealing damage to the opponent.
        Evasive       // Represents an evasive stance, emphasizing dodging and avoiding enemy attacks.
    }

    class Combat
    {

        public static void Fight(bool random, string EnemyName, int EnemyHealth, int EnemyAttack, int EnemyDefense)
        {
            string n = EnemyName;
            int h = EnemyHealth;
            int a = EnemyAttack;
            int d = EnemyDefense;

            if (random)
            {
                Random rnd = new Random();
                h = rnd.Next(1, 10);
                a = rnd.Next(1, 5);
                d = rnd.Next(1, 5);
                int randomNum = rnd.Next(1, 5);
                if (randomNum == 1)
                {
                    Console.WriteLine("You attack " + n + "!");
                }
                else
                {
                    Console.WriteLine(n + " attacks you!");
                }
            }
            else
            {
                Console.WriteLine("You are attacked by " + n + "!");
            }

            while (h > 0 && Psychosis.currentPlayer.CurrentHealth > 0) // Ensure both player and enemy are alive
            {
                // Combat loop
                Console.WriteLine(a + "/" + d);
                Console.WriteLine(@"|________________|
                                    ||Stances:      ||
                                    ||(O)ffensive   ||
                                    ||(A)ggresive   ||
                                    ||(C)onservative||
                                    ||(D)efensive   ||
                                    ||(E)vasive     ||
                                    |________________|");
                Console.WriteLine("Health: " + Psychosis.currentPlayer.CurrentHealth +  n+"Health: " + h);
                string input = Console.ReadLine();
                int damageDealt = 0;
                int damageTaken = 0;

                if (input == "O")
                {
                    // Offensive stance
                    damageDealt = a + 2;
                    damageTaken = d - 2;
                }
                else if (input == "A")
                {
                    // Aggressive stance
                    damageDealt = a + 1;
                    damageTaken = d - 1;
                }
                else if (input == "C")
                {
                    // Conservative stance
                    damageDealt = a;
                    damageTaken = d;
                }
                else if (input == "D")
                {
                    // Defensive stance
                    damageDealt = a - 1;
                    damageTaken = d + 1;
                }
                else if (input == "E")
                {
                    // Evasive stance
                    damageDealt = a - 2;
                    damageTaken = d + 2;
                }
                else
                {
                    // Error handling
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Conservative stance is used by default.");
                    damageDealt = a;
                    damageTaken = d;
                }

                if (damageDealt < 0)
                {
                    damageDealt = 0;
                }
                if (damageTaken < 0)
                {
                    damageTaken = 0;
                }

                Console.WriteLine("You attack " + n + " dealing " + damageDealt + " damage!");
                if (damageTaken > 0)
                {
                    Console.WriteLine("You lose " + damageTaken);
                }
                else
                {
                    Console.WriteLine("You gain " + Math.Abs(damageTaken));
                }

                int damageReceived = h - damageDealt + damageTaken;
                h = (damageReceived < 0) ? 0 : damageReceived;

                Console.WriteLine(n + " has " + h + " Health left.");
                Console.WriteLine("You have " + h + " Health remaining.");
            }
            if (h <= 0)
            {
                Console.WriteLine("You have defeated " + n + "!");
                Console.WriteLine("You gain 10 experience!");
                Psychosis.currentPlayer.Experience += 10;
                Console.WriteLine("You have gained 50 coins!");
                Psychosis.currentPlayer.coins += 50;
                Console.ReadKey();
                if (Psychosis.currentPlayer.CanLevelUp())
                {
                    Psychosis.currentPlayer.LevelUp();
                }
                Console.Clear();
            }
            else if (Psychosis.currentPlayer.CurrentHealth <= 0)
            {
                Console.WriteLine(n + " has defeated you!");
                Console.WriteLine("You lose 10 experience!");
                Psychosis.currentPlayer.Experience -= 10;
                Console.WriteLine("You have lost 50 coins!");
                Psychosis.currentPlayer.coins -= 50;
            }
            Console.ReadKey();
        }

        public string GetEnemy(Random Random)
        {
            switch (Random.Next(1, 6))
            {
                case 1:
                    return "Thief";

                case 2:
                    return "Bandit";

                case 3:
                    return "Brigand";

                case 4:
                    return "Highwayman";

                case 5:
                    return "Wild Animal";

            }
            return "Bandit Leader";
        }
    }
}
