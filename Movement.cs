using System;
using System.Collections.Generic;

// Define the ActionType enum outside of the Movement class
public enum ActionType { Move, Use, Equip, None }

// Define the abstract Action class outside of the Movement class
public abstract class Action
{
    // Properties common to all actions
    public ActionType Type { get; protected set; }
    public string Trigger { get; protected set; }
    public string SuccessMessage { get; protected set; }
    public string Details { get; protected set; }

    // Abstract method to perform the action (to be implemented by subclasses)
    public abstract void PerformAction();
}

// MoveAction class within the Movement namespace
public class MoveAction : Action
{
    private Location targetLocation;
    private Movement movement;

    // Constructor
    public MoveAction(Location targetLocation, Movement movement) : base(ActionType.Move, "changed", $"Move to {targetLocation}.", $"Target location: {targetLocation}")
    {
        this.targetLocation = targetLocation;
        this.movement = movement;
    }

    // Implementation of PerformAction method for MoveAction
    public override void PerformAction()
    {
        // Move the character to the target location
        if (movement.Move(targetLocation))
        {
            Console.WriteLine($"Moved to {targetLocation}");
        }
        else
        {
            Console.WriteLine("Unable to move to target location.");
        }
    }
}

// Movement class
public class Movement
{
    private string player_location;
    private Dictionary<string, Dictionary<string, string>> locations_graph;

    // Constructor
    public Movement(string player_location, Dictionary<string, Dictionary<string, string>> locations_graph)
    {
        this.player_location = player_location;
        this.locations_graph = locations_graph;
    }

    // Move method
    public bool Move(string direction)
    {
        string normalized_direction = direction.ToLower();
        if (!locations_graph.ContainsKey(player_location))
        {
            return false;
        }

        if (locations_graph[player_location].ContainsKey(normalized_direction))
        {
            player_location = locations_graph[player_location][normalized_direction];
            return true;
        }
        else
        {
            return false;
        }
    }

    // GetCurrentLocation method
    public string GetCurrentLocation()
    {
        return player_location;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example graph representing connections between locations
        Dictionary<string, Dictionary<string, string>> locations_graph = new Dictionary<string, Dictionary<string, string>>
        {
            {"town_square", new Dictionary<string, string> {{"north", "market"}, {"east", "inn"}}},
            {"market", new Dictionary<string, string> {{"south", "town_square"}, {"east", "blacksmith"}}},
            {"inn", new Dictionary<string, string> {{"west", "town_square"}}},
            {"blacksmith", new Dictionary<string, string> {{"west", "market"}}}
        };

        // Initialize Movement object with player's initial location and the locations graph
        Movement movement = new Movement("town_square", locations_graph);

        // Test movement
        Console.WriteLine(movement.Move("north"));  // Should print: "Moved to market"
        Console.WriteLine(movement.Move("south"));  // Should print: "Moved to town_square"
        Console.WriteLine(movement.Move("west"));   // Should print: "Unable to move to target location."
        Console.WriteLine(movement.Move("up"));     // Should print: "Unable to move to target location."

        // Get current location
        Console.WriteLine("Current location: " + movement.GetCurrentLocation());  // Should print: "Current location: town_square"
    }
}
