
public class GameEngine
{
    public GameState GameState { get; set; }
    public Game CurrentGame { get; set; }
    public Map GameMap { get; set; }

    public GameEngine(GameState gameState, Game game, Map map)
    {
        GameState = gameState;
        CurrentGame = game;
        GameMap = map;
    }

    public void UpdateGameMap(Map newMap)
    {
        GameMap = newMap;
    }

    public class Map
    {
    }
    public class Game
    {
        public Player Player { get; }
        public GameState GameState { get; }

        public Game(Player player, GameState gameState)
        {
            Player = player;
            GameState = gameState;
        }

        public void Start()
        {
            Console.WriteLine("Game started!");
        }

        public void End()
        {
            Console.WriteLine("Game ended!");
        }

        public void PlayGame()
        {
            InitializeGame();
            Start();
            GameState.UpdateGameState();
            GameState.ProcessInput("start");
            End();
        }

        internal static void ProcessInput(string v)
        {
            static void ProcessInput()
            {
                void ProcessInput(string input)
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Input cannot be empty.");
                    }
                    else
                    {
                        // Process the input here
                        Console.WriteLine("Processed input: " + input);
                    }
                }
            }
        }
        private void InitializeGame()
        {
            Console.WriteLine("Initializing game...");
        }
        public void LoadAndPlayGame(string gameJson)
        {
            LoadGame(gameJson);
            PlayGame();
        }

        public class Player
        {
            public int Level { get; internal set; }

            private string v1;
            private int v2;

            public Player(string v1, int v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }
        }
    }
}