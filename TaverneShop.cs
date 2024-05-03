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

namespace Psychosis
{
    // Class representing the TaverneShop where players can buy items and manage quests
    public class TaverneShop
    {
        // Method to display the options available in the TaverneShop
        public static void Taverne()
        {
            Console.WriteLine("Welcome to the Taverne!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Buy a drink");
            Console.WriteLine("2. Buy a meal");
            Console.WriteLine("3. Leave");
            string input = Console.ReadLine();

            if (input == "1")
            {
                BuyDrink();
            }
            else if (input == "2")
            {
                BuyMeal();
            }
            else if (input == "3")
            {
                Console.WriteLine("You leave the Taverne.");
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a valid choice.");
            }
        }

        // Method to handle buying a drink from the TaverneShop
        private static void BuyDrink()
        {
            if (Psychosis.currentPlayer.coins < 5)
            {
                Console.WriteLine("You don't have enough coins.");
                return;
            }

            Console.WriteLine("You buy a drink.");
            Console.WriteLine("You feel refreshed.");
            Console.WriteLine("You gain 1 Health.");
            Console.WriteLine("You gain 5 energy.");
            Console.WriteLine("You lose 5 coins.");
            Console.WriteLine("You have " + Psychosis.currentPlayer.coins + " coins left.");

            Psychosis.currentPlayer.CurrentHealth += 1;
            Psychosis.currentPlayer.Energy += 5;
            Psychosis.currentPlayer.coins -= 5;
        }

        // Method to handle buying a meal from the TaverneShop
        private static void BuyMeal()
        {
            if (Psychosis.currentPlayer.coins < 10)
            {
                Console.WriteLine("You don't have enough coins.");
                return;
            }

            Console.WriteLine("You buy a meal.");
            Console.WriteLine("You feel full.");
            Console.WriteLine("You gain 5 Health.");
            Console.WriteLine("You gain 10 energy.");
            Console.WriteLine("You lose 10 coins.");
            Console.WriteLine("You have " + Psychosis.currentPlayer.coins + " coins left.");

            Psychosis.currentPlayer.CurrentHealth += 5;
            Psychosis.currentPlayer.Energy += 10;
            Psychosis.currentPlayer.coins -= 10;
        }

        // Nested class to manage quests
        public class QuestManager
        {
            public List<Quest> activeQuests = new List<Quest>();
            public List<Quest> completedQuests = new List<Quest>();

            // Method to start a new quest
            public void StartQuest(Quest quest)
            {
                activeQuests.Add(quest);
                Console.WriteLine($"Quest \"{quest.name}\" started.");
            }

            // Method to complete a quest
            public void CompleteQuest(Quest quest)
            {
                if (activeQuests.Contains(quest))
                {
                    activeQuests.Remove(quest);
                    completedQuests.Add(quest);
                    Console.WriteLine($"Quest \"{quest.name}\" completed.");
                    // Grant rewards and handle quest completion logic
                }
                else
                {
                    Console.WriteLine($"Quest \"{quest.name}\" not found.");
                }
            }
        }

        // Class representing a quest
        public class Quest
        {
            public string name;
            public string description;
            public string reward;

            public Quest(string name, string description, string reward)
            {
                this.name = name;
                this.description = description;
                this.reward = reward;
            }
        }

        // Method to read notices from the notice board
        public void ReadNoticeBoard()
        {
            Console.WriteLine("You approach the notice board and scan the various notices pinned to it, looking for...");
            Console.WriteLine("Decree: Messages directly from the jurisdictional commanding Royal Family");
            Console.WriteLine("Notice: Messages from the establishment");
            Console.WriteLine("Bounty: Messages from NPCs");
            Console.WriteLine("Request: Messages from Humans");
            Console.WriteLine("Write: Write a message");
        }
    }
}
