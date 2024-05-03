using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Psychosis.TaverneShop; // Importing TaverneShop static class into the namespace

namespace Psychosis
{
    // Class representing non-player characters (NPCs)
    public class NPC
    {
        // NPC properties
        public string name { get; set; }
        public string description { get; set; }
        public int[] location { get; set; }
        public List<Quest> quests = new List<Quest>();
        public string behavior { get; set; } = "Idle";
        public bool IsHungry { get; set; }
        public bool IsThirsty { get; set; }
        public bool IsTired { get; set; }

        // Constructor to initialize NPC properties
        public NPC(string name, string description, int[] location, List<Quest> quests)
        {
            this.name = name;
            this.description = description;
            this.location = location;
            this.quests = quests;
            IsHungry = false;
            IsThirsty = false;
            IsTired = false;
            this.behavior = GetRandomBehavior(); // Assigning a random behavior when NPC is created
        }

        // Nested class for NPC behaviors
        public class Behavior
        {
            public static string Idle = "Idle";
            public static string Socializing = "Socializing";
            public static string PublicWork = "Public Work";
        }

        // Method to get a random behavior for the NPC
        public string GetRandomBehavior()
        {
            string[] behaviors = { "Friendly", "Neutral", "Aggressive" }; // Array of possible behaviors
            Random rnd = new Random(); // Random number generator
            return behaviors[rnd.Next(behaviors.Length)]; // Returning a random behavior from the array
        }

        // Method to update NPC behavior based on time and weather
        public void UpdateBehavior(double time, string weather)
        {
            string newBehavior = "Idle"; // Default behavior

            // Ensure valid time parameter
            if (!(time is double) || time < 0 || time > 24)
            {
                throw new ArgumentException("Invalid value for time parameter. Time must be a number between 0 and 24.");
            }
            else if (IsHungry)
            {
                newBehavior = "Eating";
            }
            else if (IsThirsty)
            {
                newBehavior = "Drinking";
            }
            else if (IsTired)
            {
                newBehavior = "Sleeping";
            }
            else
            {
                newBehavior = "Waiting";
            }

            // Weather-based behavior modification
            if (weather == "Stormy")
            {
                newBehavior = "Seeking Shelter";
            }

            behavior = newBehavior; // Update behavior
        }

        // Method to interact with the NPC
        public void Interact()
        {
            // Switch statement to handle different NPC behaviors
            switch (behavior)
            {
                case "Friendly":
                    Console.WriteLine($"{name} greets you warmly.");
                    break;
                case "Neutral":
                    Console.WriteLine($"{name} acknowledges your presence.");
                    break;
                case "Aggressive":
                    Console.WriteLine($"{name} eyes you warily.");
                    break;
                default:
                    Console.WriteLine($"{name} has an invalid behavior.");
                    break;
            }

        }

        // Method to indicate NPC ownership of a property
        public void OwnProperty(Property property)
        {
            Console.WriteLine($"{name} now owns {property.Type} at {property.Location}.");
        }

        // Method to customize a property owned by the NPC
        public void CustomizeProperty(Property property, string customization)
        {
            property.AddCustomization(customization);
            Console.WriteLine($"{name} has customized {property.Type} at {property.Location}.");
        }
    }

    // Class representing properties owned by NPCs
    public class Property
    {
        public string Type { get; }
        public string Location { get; }
        private List<string> customizations = new List<string>();

        // Constructor to initialize property type and location
        public Property(string type, string location)
        {
            Type = type;
            Location = location;
        }

        // Method to add customization to the property
        public void AddCustomization(string customization)
        {
            customizations.Add(customization);
        }
    }
}
