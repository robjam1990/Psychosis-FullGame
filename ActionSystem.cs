using System;
using System.Collections.Generic;

namespace Actions
{
    public enum Action { Move, Use, Equip, None }

    public abstract class Interaction
    {
        public ActionType Type { get; protected set; }
        public string Trigger { get; protected set; }
        public string SuccessMessage { get; protected set; }
        public string Details { get; protected set; }

        protected Interaction(ActionType type, string trigger, string successMessage, string details)
        {
            Type = type;
            Trigger = trigger;
            SuccessMessage = successMessage;
            Details = details;
        }

        public abstract void PerformAction();
    }

    public class MoveAction : Interaction
    {
        private Location targetLocation;
        private Movement movement;

        public MoveAction(Location targetLocation, Movement movement) : base(ActionType.Move, "changed", $"Move to {targetLocation}.", $"Target location: {targetLocation}")
        {
            this.targetLocation = targetLocation;
            this.movement = movement;
        }

        public override void PerformAction()
        {
            // Move the character to the target location
            if (movement.Move(targetLocation.Name))
            {
                Console.WriteLine($"Moved to {targetLocation}");
            }
            else
            {
                Console.WriteLine("Unable to move to target location.");
            }
        }
    }

    public class ActionSystem
    {
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();

        public void AddCharacter(string name, Character character)
        {
            characters[name] = character;
        }

        public void AddAction(string characterName, Interaction action)
        {
            if (characters.ContainsKey(characterName))
            {
                characters[characterName].AddAction(action);
            }
            else
            {
                throw new KeyNotFoundException("Character not found");
            }
        }

        public void ProcessActions()
        {
            foreach (var character in characters.Values)
            {
                character.ProcessActions();
            }
        }
    }
}
