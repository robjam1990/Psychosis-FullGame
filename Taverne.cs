using System;
using System.Collections.Generic;





public class Taverne
{

}

public class InteractiveElement
{
    public string name;
    public string description;

    public InteractiveElement(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
}

public class Location
{
    public string name;
    public string image;
    public string description;
    public List<InteractiveElement> interactiveElements;
    public List<NPC> npc;

    public Location(string name, string image, string description, List<InteractiveElement> interactiveElements, List<NPC> npc)
    {
        this.name = name;
        this.image = image;
        this.description = description;
        this.interactiveElements = interactiveElements;
        this.npc = npc;
    }



    public void PracticeCombat()
    {
        Console.WriteLine("You spend some time practicing your combat skills in the training area, honing your techniques for future battles.");
        // Code to simulate combat practice
        Console.WriteLine("Exercise: Choose an Exercise");
        Console.WriteLine("Time: Choose a Duration Goal");
        Console.WriteLine("Companion: Choose a Sparring Companion");
        Console.WriteLine("Trainer: Choose your trainer");
    }
}
