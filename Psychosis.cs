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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Media;
using static Psychosis.GameState;
using static Psychosis.Player;

namespace Psychosis
{
    [Serializable]
    class Psychosis
    {
        // Static variable to keep track of the player ID counter
        static int playerIdCounter = 1;

        // Current player instance
        public static Player currentPlayer = new Player();

        // Method to generate a unique player ID
        static int GeneratePlayerId()
        {
            // For simplicity, using a counter incremented each time a new player is created
            return playerIdCounter++;
        }

        // Main game loop
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            GameState.ShowMenu();
            // Start the game with a new player
            Intro.NewStart(GeneratePlayerId());

            // Create a directory for saving game data if it doesn't exist
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }

            // Initialize the current player with a unique ID
            currentPlayer = new Player();
            int playerId = GeneratePlayerId();
            currentPlayer.id = playerId;

            // Main game loop
            while (mainLoop)
            {
                // Display options
                Console.WriteLine(@"What will you do?
                                    1. Continue on the road
                                    2. Visit the Taverne
                                    3. Visit the Marketplace
                                    4. Rest
                                    5. Check Inventory
                                    6. Check Stats
                                    9. Menu
                                    0. Quit");
                string input = Console.ReadLine();

                // Handle user input
                if (input == "1")
                {
                    Console.WriteLine("You continue on the road.");
                    Encounters.RandomEncounter();
                }
                else if (input == "2")
                {
                    TaverneShop.Taverne();
                }
                else if (input == "3")
                {
                    Marketplace.Market();
                }
                else if (input == "4")
                {
                    currentPlayer.Rest();
                }
                else if (input == "5")
                {
                    Console.WriteLine("Coins: " + currentPlayer.coins);
                    Console.WriteLine("Health: " + currentPlayer.CurrentHealth);
                    Console.WriteLine("Energy: " + currentPlayer.Energy);
                }
                else if (input == "6")
                {
                    currentPlayer.CheckStats();
                }
                else if (input == "9")
                {
                    ShowMenu();
                }
                else if (input == "0")
                {
                    // Save the game and exit
                    SaveGame();
                    mainLoop = false;
                    Environment.Exit(03);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                }
            }

            // Save the game before exiting
            SaveGame();
        }

        // Method to display a progress bar
        public static void ProgressBar(int current, int total, int barLength = 20, ConsoleColor yellow = default)
        {
            Console.Write("[");
            int progress = (int)(((double)current / total) * barLength);
            for (int i = 0; i < barLength; i++)
            {
                if (i < progress)
                    Console.Write("=");
                else
                    Console.Write(" ");
            }
            Console.Write("]");
            Console.WriteLine(" " + current + "/" + total);
        }
    }
}
