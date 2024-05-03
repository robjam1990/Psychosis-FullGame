namespace Nexus
{
    Nexus Biome = new Biome("89% Grassland, 11% Desert");

    SimulateDay();
{
    // Create a new Town object

    // Example of how NPCs behave based on the time of day
    Console.WriteLine(SimulateNPCBehavior(Nexus, 11));
        Console.ReadLine(string Behavior);
}

public class Location
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Location(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}

public static class SimulateNPCBehavior
{
    private static Random = new Random();

    public static string SimulateNPCBehavior(Town town, int time)
    {
        foreach (var npc in town.NPCs)
        {
            // Simulate NPC movement to a random location within the town
            int newX = random.Next(0, town.MaxSize);
            int newY = random.Next(0, town.MaxSize);
            int newZ = random.Next(0, town.MaxSize);
            Location newLocation = new Location(newX, newY, newZ);
            npc.Location = newLocation;

            Console.WriteLine($"{time}: {npc.Name} moved to ({newX}, {newY}, {newZ})");

        }
    }

    internal class Schedule
    {
        public static void NPCbehavior(int time)
        {
            try
            {
                Console.WriteLine(string Behavior);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in simulating NPC behavior: {e.Message}");
                behavior = "Error: Unable to simulate behavior";
            }
            try
            {
                Schedule schedule = town.Taverne.NPCs.Schedule;
                SimulateNPCBehavior behaviors = town.Taverne.NPCs.Behaviors;

                if (time >= schedule.WakeUp && time < schedule.PrivateWorkStart)
                {
                    behavior = behaviors.Idle;
                }
                else if (time >= schedule.PrivateWorkStart && time < schedule.PublicWorkStart)
                {
                    behavior = behaviors.PrivateWork;
                }
                else if (time >= schedule.PublicWorkStart && time < schedule.LunchStart)
                {
                    behavior = behaviors.PublicWork;
                }
                else if (time >= schedule.LunchStart && time < schedule.WorkEnd)
                {
                    behavior = behaviors.Socializing;
                }
                else if (time >= schedule.WorkEnd && time < schedule.DinnerStart)
                {
                    behavior = behaviors.Idle;
                }
                else if (time >= schedule.DinnerStart && time < schedule.Bedtime)
                {
                    behavior = behaviors.Socializing;
                }
                else
                {
                    behavior = "Waiting";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in simulating NPC behavior: {e.Message}");
                behavior = "Error: Unable to simulate behavior";
            }
            return behavior;
        }
    }
    string jsonData = "[{\"Name\": \"Tropical Rainforest\", \"Temperature\": 25, \"Rainfall\": 2000}, {\"Name\": \"Desert\", \"Temperature\": 35, \"Rainfall\": 100}]";

    List<Biome> biomes = JsonSerializer.Deserialize<List<Biome>>(jsonData);

foreach (var biome in biomes)
{
    Console.WriteLine($"Name: {biome.Name}, Temperature: {biome.Temperature}, Rainfall: {biome.Rainfall}");
}
}
}