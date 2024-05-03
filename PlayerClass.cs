using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Psychosis.Player; // Importing Player enum into the namespace

namespace Psychosis
{
    // Class to define player classes with specific attribute bonuses
    public class PlayerClass
    {
        // Enum defining available player classes
        public enum currentClass
        {
            Adventurer,
            Builder,
            Rogue,
            Warrior,
            Engineer,
            Assassin
        }

        // Class for the Adventurer player class
        public class Adventurer
        {
            public int Defense = +2; // Bonus defense points for Adventurer
        }

        // Class for the Builder player class
        public class Builder
        {
            public int MaximumHealth = +5; // Bonus health points for Builder
            public int Speed = +1; // Bonus speed points for Builder
        }

        // Class for the Rogue player class
        public class Rogue
        {
            public int Attack = +1; // Bonus attack points for Rogue
            public int Speed = +1; // Bonus speed points for Rogue
        }

        // Class for the Warrior player class
        public class Warrior
        {
            public int MaximumHealth = +10; // Bonus health points for Warrior
            public int Attack = +2; // Bonus attack points for Warrior
            public int Defense = +3; // Bonus defense points for Warrior
            public int Speed = +2; // Bonus speed points for Warrior
        }

        // Class for the Engineer player class
        public class Engineer
        {
            public int MaximumHealth = +10; // Bonus health points for Engineer
            public int Defense = +2; // Bonus defense points for Engineer
            public int Speed = +3; // Bonus speed points for Engineer
        }

        // Class for the Assassin player class
        public class Assassin
        {
            public int MaximumHealth = +5; // Bonus health points for Assassin
            public int Attack = +3; // Bonus attack points for Assassin
            public int Speed = +3; // Bonus speed points for Assassin
        }
    }
}
