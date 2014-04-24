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


        private static WinState Rules(Hand inputOne, Hand inputTwo)
        {
            WinState oneBeatsTwo = WinState.Tie; 

            switch (inputOne)
            {
                case Hand.Rock:
                    break;
                case Hand.Paper:
                    break;
                case Hand.Scissors:
                    break;
                case Hand.Lizzard:
                    break;
                case Hand.Spock:
                    break;
                default:
                    oneBeatsTwo = WinState.Tie;
                    break;
            }

            return oneBeatsTwo;
        }
    }

    public enum WinState
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
        Lizzard,
        Spock
    }
}
