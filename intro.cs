using System;
using System.Collections.Generic;

public class Thear
{
    // Function to log messages
    public static void LogMessage(string message)
    {
        // Implement your logging mechanism here (e.g., writing to a log file)
        // Example: File.AppendAllText("game.log", DateTime.Now.ToString() + ": " + message + Environment.NewLine);
        \.\Psychosis.Log(message);
    }

    // Function to log exceptions
    public static void LogException(Exception ex)
    {
        // Implement your logging mechanism here (e.g., writing to a log file)
        // Example: File.AppendAllText("error.log", DateTime.Now.ToString() + ": " + ex.ToString() + Environment.NewLine);
    }
    // Function to display next dialogue based on user choice
    public static void ShowNextDialog(string dialogKey)
    {
        var dialog = dialogues[dialogKey];
        if (dialog != null)
        {
            Console.WriteLine(dialog["speaker"] + ": " + dialog["message"]); // Display dialogue
            new Choice { Option = "[Enter Name]", NextDialog = "NameInput" };
            if (choices != null && choices.Count > 0)
            {
                for (int i = 0; i < choices.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") " + choices[i]["option"]); // Display choices
                }
                // No need to call HandleUserChoice here, as this function is called in response to player's input
            }
        }
    }
    // Function to handle dialogue choices based on player input
    public static void HandleDialogueChoice(string dialogKey, int choiceIndex)
    {
        // Validate input and transition to the next dialogue
        HandleUserChoice(dialogKey, choiceIndex);
        // Additional logic based on player's choices can be implemented here
    }
    // Function to handle user choice and transition to the next dialogue
    public static void HandleUserChoice(string dialogKey, int choiceIndex)
    {
        var dialog = dialogues[dialogKey];
        if (dialog != null && dialog["choices"] != null)
        {
            var choices = dialog["choices"] as List<Dictionary<string, string>>;
            if (choices != null && choices.Count > 0)
            {
                var choice = choices[choiceIndex - 1]; // Adjust for 0-based index
                if (choice != null)
                {
                    Console.WriteLine("Player: " + choice["option"]); // Display player's choice
                    var nextDialog = choice["nextDialog"];
                    if (nextDialog != null)
                    {
                        ShowNextDialog(nextDialog); // Display next dialogue
                    }
                    else
                    {
                        Console.WriteLine("End of conversation."); // No next dialogue
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice."); // Invalid user input
                }
            }
            else
            {
                Console.WriteLine("No choices available."); // No choices in the current dialogue
            }
        }
        else
        {
            Console.WriteLine("No choices available."); // No choices in the current dialogue
        }
    }
}

public class Dialog
{
    public string Speaker { get; set; }
    public string Message { get; set; }
    public List<Choice> Choices { get; set; }
}

public class Choice
{
    public string Option { get; set; }
    public string NextDialog { get; set; }
}

public class DialogData
{
    public Dictionary<string, Dialog> Dialogs { get; set; }

    public DialogData()
    {
        Dialogs = new Dictionary<string, Dialog>();
    }
}

Dialog openingDialog = new Dialog
{
    Speaker = "maia",
    Message = "As you begin to open your eyes, you hear a soft reassuring voice.\n\n'Hey there, hope you had a good sleep.'\n\nYour eyes begin to focus on the origin of the voice as the voice continues to speak.\n\n'Before we continue further, can you please tell me your name?'",
    Choices = new List<Choice>
    {
        new Choice { Option = "Who are you?", NextDialog = "maiaIntro" },
        new Choice { Option = "What is this place?", NextDialog = "PlaceIntro" },
        new Choice { Option = "Where am I?", NextDialog = "LocationIntro" },
        new Choice { Option = "How long have I been asleep for?", NextDialog = "SleepIntro" },
        new Choice { Option = "I do not remember my name.", NextDialog = "NameIntro" },
        new Choice { Option = "[Enter Name]", NextDialog = "NameInput" }
    },

    Dialog maiaIntroDialog = new Dialog
    {
        Speaker = "maia",
        Message = "My name is maia, and I will be getting you ready for your journey. I just want to make sure the information that we have on you here is correct. How does it look?",
        NextDialog = "CharacterCreation"
    };

    Dialog placeIntroDialog = new Dialog
    {
        Speaker = "maia",
        Message = "Welcome to Nexus, a town on the planet Thear in a remote Galaxy where each Colony constructs their own Stars and Planets. The terraforming is well underway, and the planet has a breathable atmosphere outside of Nexus.",
        NextDialog = "Opening"
    };

    Dialog locationIntroDialog = new Dialog
    {
        Speaker = "maia",
        Message = "You are in the Taverne, a hub in a remote Galaxy where each Colony constructs their own Stars and Planets. The terraforming is well underway, and the planet has a breathable atmosphere outside of Nexus.",
        NextDialog = "Opening"
    };
    Dialog sleepIntroDialog = new Dialog
    {
        Speaker = "maia",
        Message = "You have been asleep for a considerable amount of time. An adventurer found you outside of Nexus.",
        NextDialog = "Opening"
    };

    Dialog nameIntroDialog = new Dialog
    {
        Speaker = "maia",
        Message = "That's alright. Let's proceed with character creation, and you can choose a name for your character.",
        NextDialog = "CharacterCreation"
    };

    Dialog nameInputDialog = new Dialog
    {
        Speaker = "maia",
        Message = "What shall we call you?",
        NextDialog = "NameConfirmation"
    };

    Dialog nameConfirmationDialog = new Dialog
    {
        Speaker = "maia",
        Message = "Excellent! The Barkeep will provide you with some Food and Drink.",
        NextDialog = "BarkeepIntro"
    };
    Dialog barkeepIntroDialog = new Dialog
    {
        Speaker = "Barkeep",
        Message = "Hey there, champ! Let's get you set up.",
        NextDialog = "PlayerInput"
    };

    Dialog playerInputDialog = new Dialog
    {
        Speaker = "maia",
        Message = "You may move around and interact with objects in the room.",
        NextDialog = "MapIntroduction"
    };

    Dialog mapIntroductionDialog = new Dialog
    {
        Speaker = "maia",
        Message = "Feel free to wander around and talk to people.",
        NextDialog = Thear.story
    };

    Dialog characterCreationDialog = new Dialog
    {
        Log = 99,
        NextDialog = "Create.cs"
    };

    data.Dialogs.Add("BarkeepIntro", barkeepIntroDialog);
    data.Dialogs.Add("PlayerInput", playerInputDialog);
    data.Dialogs.Add("MapIntroduction", mapIntroductionDialog);
    data.Dialogs.Add("CharacterCreation", characterCreationDialog);


    data.Dialogs.Add("SleepIntro", sleepIntroDialog);
    data.Dialogs.Add("NameIntro", nameIntroDialog);
    data.Dialogs.Add("NameInput", nameInputDialog);
    data.Dialogs.Add("NameConfirmation", nameConfirmationDialog);
    data.Dialogs.Add("maiaIntro", maiaIntroDialog);
    data.Dialogs.Add("PlaceIntro", placeIntroDialog);
    data.Dialogs.Add("LocationIntro", locationIntroDialog);
    data.Dialogs.Add("opening", openingDialog);
    // Call the function to start the game
    StartGame();
}
// Usage:
DialogData data = new DialogData();

// Call the function to show the next dialog
Thear.ShowNextDialog("opening");