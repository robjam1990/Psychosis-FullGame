namespace Actions
{
    // Define the abstract base class for actions
    public abstract class Actions
    {
        private string? location;

        // Properties common to all actions
        public string? GetLocation()
        {
            return location;
        }

        // Properties common to all actions
        private void SetLocation(string? value)
        {
            location = value;
        }

        public string? Description { get; private set; }
        public string? Properties { get; private set; }
        public ActionType Type { get; }

        // Method to perform the action (to be implemented by subclasses)
        public abstract void PerformAction();
    }
        // Enum for different action types
        public enum ActionType
        {
            Move,
            Interact,
            Attack,
            Defend,
            UseItem,
            Dialogue
            // Add more action types as needed
        }
    // Constructor
    protected Interaction(InteractionType type, string trigger, string successMessage, string details)
        {
            Type = type;
            Trigger = trigger;
            SuccessMessage = successMessage;
            Details = details;
        }

    public class InteractionType
    {
    }

    // Properties of an action
    public string Location { get; private set; }
        public string Description { get; private set; }
        public string Properties { get; private set; }
        public ActionType Type { get; }

        // Method to perform the action (to be implemented by subclasses)
        public abstract void PerformAction();
    }

    // Concrete class for MoveAction
    public class MoveAction : Interaction
    {
        private Location targetLocation;

        public MoveAction(Location targetLocation) : base(ActionType.Move, "changed", "Move to target location.", "Target location: " + targetLocation)
        {
            this.targetLocation = targetLocation;
        }

        // Implementation of PerformAction method for MoveAction
        public override void PerformAction()
        {
            // Move the character to the target location
            // Implementation logic here
        }
    }

    // Concrete class for HealAction
    public class HealAction : Interaction
    {
        public HealAction() : base(ActionType.Heal, "unchanged", "Heal the character.")
        {
            // Constructor implementation
        }

        // Implementation of PerformAction method for HealAction
        public override void PerformAction()
        {
            // Implementation logic for healing action
            Console.WriteLine("Healing action performed.");
        }
    }

    // Implement similar classes for other action types

    // ActionSystem class to manage actions for characters
    public class ActionSystem
    {
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();

        // Method to add a character to the action system
        public void AddCharacter(string name, Character character)
        {
            characters[name] = character;
        }

        // Method to add an action for a character
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

        // Method to process actions for all characters
        public void ProcessActions()
        {
            foreach (var character in characters.Values)
            {
                character.ProcessActions();
            }
        }
    }
}
