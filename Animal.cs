using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychosis
{
    public class Animal
    {
        public string Name { get; set; } = string.Empty; // Name of the animal
        public int Limbs { get; set; } // Number of limbs the animal has
        public int Hunger { get; set; } // Hunger level of the animal
        public int Strength { get; set; } // Strength of the animal
        public string Gender { get; set; } = string.Empty; 
        public bool IsHungry { get; set; } // Whether the animal is hungry or not
        public bool Combat { get; set; } // Whether the animal is in combat or not
        public bool Success { get; set; } // Whether the animal succeeded in a task
        public int Speed { get; set; } // Speed of the animal
        public string MovementType { get; set; } = string.Empty;
        public int Energy { get; set; } // Energy level of the animal

        public Animal(string name, string species, int age, int limbs)
        {
            Limbs = limbs;
            Hunger = 10;
            Strength = 1;
            Speed = 1;
            Gender = new Random().NextDouble() < 0.5 ? "male" : "female";
            IsHungry = true;
        }

        public void Move()
        {
            Console.WriteLine("The animal moves.");
        }

        public void Eat()
        {
            Console.WriteLine("The animal eats.");
        }

        public void Sleep()
        {
            Console.WriteLine("The animal sleeps.");
        }

        public void Attack()
        {
            Console.WriteLine("The animal attacks.");
        }

        public void Defend()
        {
            Console.WriteLine("The animal defends.");
        }

        public void Hunt()
        {
            Console.WriteLine("The animal hunts for food.");
        }

        public void Rest()
        {
            Console.WriteLine("The animal rests.");
        }

        public void Breed()
        {
            Console.WriteLine("The animal breeds.");
        }

        public void Die()
        {
            Console.WriteLine("The animal dies.");
        }

        public void Update()
        {
            Console.WriteLine("The animal updates.");
        }

        public void Interact()
        {
            Console.WriteLine("The animal interacts.");
        }

        public void DisplayStats()
        {
            Console.WriteLine("Limbs: " + Limbs);
            Console.WriteLine("Hunger: " + Hunger);
            Console.WriteLine("Strength: " + Strength);
            Console.WriteLine("Speed: " + Speed);
        }
    }

}
