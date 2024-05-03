using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// File: Main.cs

public class Main : MonoBehaviour
{
    // The main script file for your text-based game in Unity
    // Define story elements
    public static Dictionary<string, Dictionary<string, string>> story = new Dictionary<string, Dictionary<string, string>>
    {
        {
            "Prologue", new Dictionary<string, string>
            {
                { "message", "In an attempt to preserve Human life in the Universe, The Psychosis Project was activated and the Human race was scattered into the stars as remote 'Colonies'. Each Colony has been launched into a separate remote Galaxy in which they will construct their very own Stars and Planets. The Star and Planet have been constructed for quite some time now. The terraforming is well underway, and the planet has a breathable atmosphere outside of the Thear. Authorized personnel have been taking their stations as today is the first day that Non-essential personnel are being awoken." }
            }
        }
    };

    // Start is called before the first frame update
    // Method to start the game
    private static void Start()
    {
        Debug.Log("Prologue: " + story["Prologue"]["message"]);
        Debug.Log("Welcome to Psychosis!");
        Console.WriteLine("Welcome to Psychosis!");
        Console.WriteLine("You are standing in a mysterious forest. The path forks ahead of you.");

        while (true)
        {
            Console.Write("Enter your choice (left/right) or type 'quit' to exit: ");
            string? input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "left":
                    Console.WriteLine("You chose the left path. You encounter a wise owl.");
                    break;
                case "right":
                    Console.WriteLine("You chose the right path. You find a treasure chest.");
                    break;
                case "quit":
                    Console.WriteLine("Thank you for playing!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Main: ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Main game loop logic here
        // This might involve waiting for player input, processing player actions, updating the game state, etc.
        string input = Console.ReadLine();
        string output = Console.WriteLine("Main: " + output);
    }
}
