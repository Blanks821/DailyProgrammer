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
            // TOOD: Welcome message

            // TODO: Loop

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
        private Outcome outcome;
        private string message;

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
        Rock,
        Paper,
        Scissors,
        Lizard,
        Spock
    }
    public static struct GameMessages
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
    }
}
