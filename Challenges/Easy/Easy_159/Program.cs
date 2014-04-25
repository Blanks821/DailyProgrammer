using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy_159
{
    class Program
    {
        static void Main(string[] args)
        {
            MainLoop();
        }

        private static void MainLoop()
        {
            Hand playerOne, playerTwo;
            WinState outcome;
            bool done = false;

            Console.WriteLine("Welcome to Rock Paper Scissors Lizard Spock!");

            // Game Loop
            while (!done)
            {
                Console.WriteLine("Please make a selection:");
                Console.WriteLine("\t1)Rock\n\t2)Paper\n\t3)Scissors\n\t4)Lizard\n\t5)Spock\nPress Q to Quit...");
                char input = Convert.ToChar(Console.Read());

                playerOne = Hand.Invalid;

                switch (input)
                {
                    case 'q': 
                    case 'Q':
                        done = true;
                        break;
                    case '1':
                        playerOne = Hand.Rock;
                        break;
                    case '2':
                        playerOne = Hand.Paper;
                        break;
                    case '3':
                        playerOne = Hand.Scissors;
                        break;
                    case '4':
                        playerOne = Hand.Lizard;
                        break;
                    case '5':
                        playerOne = Hand.Spock;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        playerOne = Hand.Invalid;
                        continue;
                }

                if (playerOne == Hand.Invalid) // probably overkill but just in case
                {
                    Console.WriteLine("Invalid selection");
                    continue;
                }

                Random rand = new Random();
                playerTwo = (Hand)rand.Next(1, 5);

                GameStats.AddGame(outcome = Rules(playerOne, playerTwo));
                Console.WriteLine("{0}!\n{1}", outcome.Message, outcome.Outcome == Outcome.Win ? GameMessages.win : GameMessages.lose);
            }
            // TODO: Exit stats display
        }

        private static WinState Rules(Hand playerOne, Hand playerTwo)
        {
            WinState oneBeatsTwo = new WinState();
            if (playerOne == playerTwo)
            {
                oneBeatsTwo.Outcome = Outcome.Tie;
                oneBeatsTwo.Message = GameMessages.tie;
            }
            else
            {
                switch (playerOne)
                {
                    case Hand.Rock:
                        switch (playerTwo)
                        {
                            case Hand.Paper:
                                oneBeatsTwo.Outcome = Outcome.Loss;
                                oneBeatsTwo.Message = GameMessages.paperVRock;
                                break;
                            case Hand.Scissors:
                                oneBeatsTwo.Outcome = Outcome.Win;
                                oneBeatsTwo.Message = GameMessages.rockVScissors;
                                break;
                            case Hand.Lizard:
                                oneBeatsTwo.Outcome = Outcome.Win;
                                oneBeatsTwo.Message = GameMessages.rockVLizard;
                                break;
                            case Hand.Spock:
                                oneBeatsTwo.Outcome = Outcome.Loss;
                                oneBeatsTwo.Message = GameMessages.spockVRock;
                                break;
                        }
                        break;
                    case Hand.Paper:
                        switch (playerTwo)
                        {
                            case Hand.Rock:
                                oneBeatsTwo.Outcome = Outcome.Win;
                                oneBeatsTwo.Message = GameMessages.paperVRock;
                                break;
                            case Hand.Scissors:
                                oneBeatsTwo.Outcome = Outcome.Loss;
                                oneBeatsTwo.Message = GameMessages.scissorsVPaper;
                                break;
                            case Hand.Lizard:
                                oneBeatsTwo.Outcome = Outcome.Loss;
                                oneBeatsTwo.Message = GameMessages.lizardVPaper;
                                break;
                            case Hand.Spock:
                                oneBeatsTwo.Outcome = Outcome.Win;
                                oneBeatsTwo.Message = GameMessages.paperVSpock;
                                break;
                        }
                        break;
                    case Hand.Scissors:
                        switch (playerTwo)
                        {
                            case Hand.Rock:
                                oneBeatsTwo.Outcome = Outcome.Loss;
                                oneBeatsTwo.Message = GameMessages.rockVScissors;
                                break;
                            case Hand.Paper:
                                oneBeatsTwo.Outcome = Outcome.Win;
                                oneBeatsTwo.Message = GameMessages.scissorsVPaper;
                                break;
                            case Hand.Lizard:
                                oneBeatsTwo.Outcome = Outcome.Win;
                                oneBeatsTwo.Message = GameMessages.scissorsVLizard;
                                break;
                            case Hand.Spock:
                                oneBeatsTwo.Outcome = Outcome.Loss;
                                oneBeatsTwo.Message = GameMessages.spockVScissors;
                                break;
                        }
                        break;
                    case Hand.Lizard:
                        switch (playerTwo)
                        {
                            case Hand.Rock:
                                oneBeatsTwo.Outcome = Outcome.Loss;
                                oneBeatsTwo.Message = GameMessages.rockVLizard;
                                break;
                            case Hand.Paper:
                                oneBeatsTwo.Outcome = Outcome.Win;
                                oneBeatsTwo.Message = GameMessages.lizardVPaper;
                                break;
                            case Hand.Scissors:
                                oneBeatsTwo.Outcome = Outcome.Loss;
                                oneBeatsTwo.Message = GameMessages.scissorsVLizard;
                                break;
                            case Hand.Spock:
                                oneBeatsTwo.Outcome = Outcome.Win;
                                oneBeatsTwo.Message = GameMessages.lizardVSpock;
                                break;
                        }
                        break;
                    case Hand.Spock:
                        switch (playerTwo)
                        {
                            case Hand.Rock:
                                oneBeatsTwo.Outcome = Outcome.Win;
                                oneBeatsTwo.Message = GameMessages.spockVRock;
                                break;
                            case Hand.Paper:
                                oneBeatsTwo.Outcome = Outcome.Loss;
                                oneBeatsTwo.Message = GameMessages.paperVSpock;
                                break;
                            case Hand.Scissors:
                                oneBeatsTwo.Outcome = Outcome.Win;
                                oneBeatsTwo.Message = GameMessages.spockVScissors;
                                break;
                            case Hand.Lizard:
                                oneBeatsTwo.Outcome = Outcome.Loss;
                                oneBeatsTwo.Message = GameMessages.lizardVSpock;
                                break;
                        }
                        break;
                }
            }
            return oneBeatsTwo;
        }
    }

    public struct WinState
    {
        public Outcome Outcome { get; set; }
        public string Message { get; set; }
    }
    public enum Outcome
    {
        Tie = -1,
        Loss = 0,
        Win = 1                
    }
    public enum Hand
    {
        Invalid = 0,
        Rock,
        Paper,
        Scissors,
        Lizard,
        Spock
    }
    public struct GameMessages
    {
        public static readonly string tie = "It's a tie";
        public static readonly string paperVRock = "Paper covers rock";
        public static readonly string paperVSpock = "Paper disproves Spock";
        public static readonly string rockVScissors = "Rock crushes scissors";
        public static readonly string rockVLizard = "Rock crushes lizard";
        public static readonly string scissorsVPaper = "Scissors cut paper";
        public static readonly string scissorsVLizard = "Scissors decapitate lizard";
        public static readonly string lizardVPaper = "Lizard eats paper";
        public static readonly string lizardVSpock = "Lizard poisons Spock";
        public static readonly string spockVRock = "Spock vaporizes rock";
        public static readonly string spockVScissors = "Spock smashes scissors";
        public static readonly string win = "You win!";
        public static readonly string lose = "Sorry, you lose.";
    }
    public struct GameStats
    {
        private static int humanWins;
        private static int computerWins;
        private static int ties;
        private static int totalGames;
        private static bool initalized = false;

        public static int HumanWins { get { return humanWins; } }
        public static int ComputerWins { get { return computerWins; } }
        public static int Ties { get { return ties; } }
        public static int TotalGames { get { return totalGames; } }

        public static void Start()
        {
            if (!initalized)
            {
                humanWins = 0;
                computerWins = 0;
                ties = 0;
                totalGames = 0;
            }
            initalized = true;
        }

        public static void AddGame(WinState outcome)
        {
            totalGames++;
            switch (outcome.Outcome)
            {
                case Outcome.Win:
                    humanWins++;
                    break;
                case Outcome.Tie:
                    ties++;
                    break;
                case Outcome.Loss:
                    computerWins++;
                    break;
            }
        }        
    }
}
