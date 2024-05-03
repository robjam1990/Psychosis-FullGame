using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;

internal class Biome(string name) : IEquatable<Biome?>
{
    public string Name { get; } = name;
    private List<Organism> organisms = new List<Organism>();
    private object JsonSerializer;

    public Biome(string name, List<Organism> organisms, object jsonSerializer) : this(name)
    {
        this.organisms = organisms ?? throw new ArgumentNullException(nameof(organisms));
        JsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
    }

    private List<Dictionary<string, object>> LoadOrganismsFromJson(string filePath)
    {
        List<Dictionary<string, object>> organisms = new List<Dictionary<string, object>>();

        // Load organisms from JSON file
        try
        {
            string jsonData = File.ReadAllText(filePath);
            JObject jsonObject = JObject.Parse(jsonData);

            foreach (var organismType in jsonObject)
            {
                switch (organismType.Key)
                {
                    case "Insect":
                        // Process insect data
                        foreach (var organism in organismType.Value)
                        {
                            Dictionary<string, object> insectData = new Dictionary<string, object>();
                            // Populate insect data dictionary
                            // Example: insectData["Name"] = organism["Name"].ToString();
                            organisms.Add(insectData);
                        }
                        break;
                    case "Animal":
                        // Process animal data
                        foreach (var organism in organismType.Value)
                        {
                            Dictionary<string, object> animalData = new Dictionary<string, object>();
                            // Populate animal data dictionary
                            // Example: animalData["Name"] = organism["Name"].ToString();
                            organisms.Add(animalData);
                        }
                        break;
                    case "Plant":
                        // Process plant data
                        foreach (var organism in organismType.Value)
                        {
                            Dictionary<string, object> plantData = new Dictionary<string, object>();
                            // Populate plant data dictionary
                            // Example: plantData["Name"] = organism["Name"].ToString();
                            organisms.Add(plantData);
                        }
                        break;
                    default:
                        // Handle unknown organism type
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle JSON file loading error
            Console.WriteLine("Error loading organisms from JSON: " + ex.Message);
        }

        return organisms;
    }


    public void AddOrganismsFromJson(string filePath)
    {
        List<Dictionary<string, object>> organismsData = LoadOrganismsFromJson(filePath);
        foreach (var organismData in organismsData)
        {
            try
            {
                Organism organism;
                if (organismData.ContainsKey("limbs"))
                {
                    organism = new Animal((string)organismData["species"], (int)organismData["age"], (int)organismData["limbs"], (string)organismData["habitat"]);
                }
                else
                {
                    organism = new Plant((string)organismData["species"], (int)organismData["age"], (string)organismData["habitat"]);
                }
                AddOrganism(organism);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding organism: {ex.Message}");
            }
        }
    }

    public void AddOrganism(Organism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateDay()
    {
        Console.WriteLine($"Simulating a day in the {Name} Biome:");
        foreach (var organism in organisms)
        {
            try
            {
                if (organism.IsAlive)
                {
                    organism.Move();
                    organism.Eat();
                    organism.Reproduce();
                    if (organism is Animal animal)
                    {
                        var prey = FindPrey(animal);
                        if (prey != null)
                        {
                            Console.WriteLine($"{animal.Species} is hunting {prey.Species}.");
                            prey.Die();
                            prey.LoseLimb();
                        }
                        AnimalCommunication(animal);
                    }
                }
                else
                {
                    Console.WriteLine($"{organism.Species} is dead and cannot perform any actions.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error simulating organism: {ex.Message}");
            }
        }
    }

    private Organism? FindPrey(Animal predator)
    {
        var preyCandidates = organisms.FindAll(org => org is Animal && org != predator);
        if (preyCandidates.Count > 0)
        {
            Random rand = new Random();
            return preyCandidates[rand.Next(preyCandidates.Count)];
        }
        return null;
    }

    private void AnimalCommunication(Animal organism)
    {
        Console.WriteLine($"{organism.Species} is communicating with other {organism.Species}.");
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Biome);
    }

    public bool Equals(Biome? other)
    {
        return other is not null &&
               Name == other.Name &&
               EqualityComparer<List<Organism>>.Default.Equals(organisms, other.organisms) &&
               EqualityComparer<object>.Default.Equals(JsonSerializer, other.JsonSerializer);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, organisms, JsonSerializer);
    }

    public static bool operator ==(Biome? left, Biome? right)
    {
        return EqualityComparer<Biome>.Default.Equals(left, right);
    }

    public static bool operator !=(Biome? left, Biome? right)
    {
        return !(left == right);
    }
}

abstract class Organism
{
    public string Species { get; }
    public int Age { get; }
    public bool IsAlive { get; protected set; }

    public Organism(string species, int age)
    {
        Species = species;
        Age = age;
        IsAlive = true;
    }

    public abstract void Move();
    public abstract void Eat();
    public abstract void Reproduce();

    internal void LoseLimb()
    {
        throw new NotImplementedException();
    }

    internal abstract void Die();
}

internal class Plant : Organism
{
    public string Habitat { get; }

    public Plant(string species, int age, string habitat) : base(species, age)
    {
        Habitat = habitat;
    }

    public override void Move()
    {
        Console.WriteLine($"{Species} can't move, it's a plant in the {Habitat} habitat.");
    }

    public override void Eat()
    {
        Console.WriteLine($"{Species} is absorbing nutrients from the soil in the {Habitat} habitat.");
    }

    public override void Reproduce()
    {
        Console.WriteLine($"{Species} is spreading seeds in the {Habitat} habitat.");
    }

    internal override void Die()
    {
        throw new NotImplementedException();
    }
}

internal class Animal : Organism
{
    public int Limbs { get; set; }
    public string Habitat { get; }

    public Animal(string species, int age, int limbs, string habitat) : base(species, age)
    {
        Limbs = limbs;
        Habitat = habitat;
    }

    public override void Move()
    {
        Console.WriteLine($"{Species} is moving in the {Habitat} habitat.");
    }

    public override void Eat()
    {
        Console.WriteLine($"{Species} is hunting for food.");
    }

    public override void Reproduce()
    {
        Console.WriteLine($"{Species} is mating.");
    }

    public new void LoseLimb()
    {
        if (Limbs > 0)
        {
            Limbs--;
            Console.WriteLine($"{Species} lost a limb! Remaining limbs: {Limbs}");
        }
        else
        {
            Die();
        }
    }
    internal override void Die()
    {
        throw new NotImplementedException();
    }
}
