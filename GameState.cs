using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Psychosis.Player;

namespace Psychosis
{
    public class GameState
    {
        // Method to display the main menu
        public static void ShowMenu()
        {
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Save Game");
            Console.WriteLine("3. Load Game");
            Console.WriteLine("4. Delete Game");
            Console.WriteLine("0. Quit");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    NewGame();
                    break;
                case "2":
                    SaveGame();
                    break;
                case "3":
                    LoadGame();
                    break;
                case "4":
                    DeleteGame();
                    break;
                case "0":
                    Environment.Exit(04);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                    break;
            }
        }

        // Method to create a new game
        public static void NewGame()
        {
            Console.WriteLine("Enter your name, Traveller:");
            string name = Console.ReadLine();
            currentPlayer = new Player();
            currentPlayer.Name = name;
            currentPlayer.id = currentPlayer.GetHashCode();
            Console.WriteLine("New game created. Welcome, " + name + "!");
        }

        // Method to save the current game state
        public static void SaveGame()
        {
            string path = "saves/" + currentPlayer.Name + currentPlayer.id.ToString() + ".json"; 
            string jsonString = JsonSerializer.Serialize(currentPlayer);
            File.WriteAllText(path, jsonString);
            Console.WriteLine("Game saved.");
        }

        // Method to load a saved game
        public static void LoadGame()
        {
            List<Player> Players = new List<Player>();
            int idCount = 0;
            foreach (string file in Directory.EnumerateFiles("saves", "*.json"))
            {
                string jsonString = File.ReadAllText(file);
                Player player = JsonSerializer.Deserialize<Player>(jsonString);
                Players.Add(player);
                if (player.id > idCount)
                {
                    idCount = player.id;
                }
            }
            if (Players.Count > 0)
            {
                Console.WriteLine("Choose a player to load:");
                foreach (Player player in Players)
                {
                    Console.WriteLine(player.id + ": " + player.Name);
                }
                int id = int.Parse(Console.ReadLine());
                currentPlayer = Players.Find(p => p.id == id);
                Console.WriteLine("Game loaded.");
            }
            else
            {
                Console.WriteLine("No saved games found.");
            }
        }

        // Method to delete a saved game
        public static void DeleteGame()
        {
            List<Player> Players = new List<Player>();
            foreach (string file in Directory.EnumerateFiles("saves", "*.json"))
            {
                string jsonString = File.ReadAllText(file);
                Player player = JsonSerializer.Deserialize<Player>(jsonString);
                Players.Add(player);
            }
            if (Players.Count > 0)
            {
                Console.WriteLine("Choose a player to delete:");
                foreach (Player player in Players)
                {
                    Console.WriteLine(player.id + ": " + player.Name);
                }
                int id = int.Parse(Console.ReadLine());
                Player playerToDelete = Players.Find(p => p.id == id);
                string path = "saves/" + playerToDelete.id.ToString() + ".json"; // Corrected file extension
                File.Delete(path);
                Console.WriteLine("Game deleted.");
            }
            else
            {
                Console.WriteLine("No saved games found.");
            }
        }
    }
}
