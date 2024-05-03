/*
    This class represents the Player entity in the world of Psychosis.
    It encapsulates attributes such as name, health, energy, attack, defense, etc.
*/

using System;
using static Psychosis.PlayerClass;

namespace Psychosis
{
    [Serializable]
    class Player
    {
        Random random; // Random number generator for various game mechanics.

        // Enum defining the available player classes.
        public enum PlayerClass
        {
            Adventurer,
            Builder,
            Rogue,
            Warrior,
            Engineer,
            Assassin
        }

        // Current player class, defaults to Adventurer.
        public PlayerClass currentClass = PlayerClass.Adventurer;

        // Player attributes.
        public string Name { get; set; } // Name of the player.
        public int id { get; set; } // Unique identifier for the player.
        public int coins { get; set; } = 0; // Player's currency.
        public List<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>(); // Player's inventory.
        public int MaximumHealth { get; set; } = 10; // Player's health points.
        public int CurrentHealth { get; set; } = 10; // Player's current health points.
        public int Energy { get; set; } = 50; // Player's energy points.
        public int Attack { get; set; } = 1; // Player's attack power.
        public int Defense { get; set; } = 1; // Player's defense power.
        public int Speed { get; set; } = 1; // Player's speed attribute.
        public int Damage { get; set; } = 1; // Base damage inflicted by the player.
        public int Level { get; set; } = 1; // Player's current level.
        public int Experience { get; set; } = 0; // Player's experience points.

        public static Player currentPlayer { get; set; }

        public class InventoryItem
        {
            public string Name { get; set; } = "";
            public int Quantity { get; set; } = 1;
            public string Description { get; set; } = "";
            public int Mass { get; set; } = 0;
            public int Value { get; set; } = 0;
            public int Durability { get; set; } = 100;

            public InventoryItem(string name, int quantity = 1, string description = "")
            {
                Name = name;
                Quantity = quantity;
                Description = description;
            }
        }
        // Method to handle player taking damage.
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage; // Reduce player's health by the specified damage amount.
        }

        // Method to heal player.
        public void Heal(int heal)
        {
            CurrentHealth += heal; // Increase player's health by the specified heal amount.
        }

        // Method to handle player gaining experience points.
        public void GainExperience(int experience)
        {
            Experience += experience; // Increment player's experience points.
            while (Experience >= (100*Level)) // Check if player's experience reaches the level-up threshold.
            {
                Console.WriteLine("You have leveled up!"); // Display level up message.
                LevelUp(); // If so, trigger level up.
            }
        }
        public int GetLevelUpThreshold()
        {
            return 100 * Level;
        }
        public bool CanLevelUp()
        {
            if (Experience >= GetLevelUpThreshold())
            {
                return true;
            }
            else return false;
        }

        // Method to handle player leveling up.
        public void LevelUp()
        {
            while (CanLevelUp())
            {
                Level++; // Increment player's level.
                Experience -= GetLevelUpThreshold(); // Reset player's experience points.
                // Increment player's attributes upon leveling up.
                Attack++;
                Defense++;
                Speed++;
                MaximumHealth += 5;
            }
            Console.ForegroundColor = ConsoleColor.Green; // Change console text color to green.
            Console.WriteLine("You are now level " + Level + "!"); // Display player's new level.
            Console.ReadKey(); // Wait for player input.
            Console.ResetColor(); // Reset console text color.
            Console.Clear(); // Clear the console screen.
        }

        // Method to handle player resting, replenishing energy.
        public void Rest()
        {
            Energy += 100; // Replenish player's energy points.
        }

        // Method to display player's current statistics.
        public void CheckStats()
        {
            // Display player's attributes.
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Level: " + Level);
            Psychosis.ProgressBar(Experience, GetLevelUpThreshold(), 20, ConsoleColor.Yellow);
            Console.WriteLine("Experience: " + Experience);
            Console.WriteLine("Health: " + CurrentHealth);
            Console.WriteLine("Energy: " + Energy);
            Console.WriteLine("Attack: " + Attack);
            Console.WriteLine("Defense: " + Defense);
            Console.WriteLine("Speed: " + Speed);
        }

        // Method to display player's inventory (coins).
        public void CheckInventory()
        {
            Console.WriteLine("You have " + coins + " coins."); // Display player's coins.
        }
    }
}
