using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut : Game
    {
        int playerOneScore = 0;
        int playerTwoScore = 0;
        int turn = 1;
        int rounds = 1;

        public List<int> PlayGame()
        {
            bool done = false;
            while(!done)
            {
                if(turn == 1)
                {
                    Console.WriteLine("Round " + rounds + "! Fight!");
                    Console.WriteLine("Player 1's turn. Press any key to roll dice.");
                    Console.ReadKey();
                    List<int> list = RollDie(2);
                    Console.WriteLine("\nRolled a " + list[0] + " and a " + list[1]);
                    if (list[0] + list[1] == 7)
                    {
                        done = true;
                    }
                    else if (list[0] == list[1])
                    {
                        playerOneScore += 2 * (list[0] + list[1]);
                    }
                    else
                    {
                        playerOneScore += list[0] + list[1];
                    }
                    turn = 2;
                }
                else
                {
                    Console.WriteLine("Player 2's turn. Press any key to roll dice.");
                    Console.ReadKey();
                    List<int> list = RollDie(2);
                    Console.WriteLine("\nRolled a " + list[0] + " and a " + list[1]);
                    if (list[0] + list[1] == 7)
                    {
                        done = true;
                    }
                    else if (list[0] == list[1])
                    {
                        playerTwoScore += 2 * (list[0] + list[1]);
                    }
                    else
                    {
                        playerTwoScore += list[0] + list[1];
                    }
                    turn = 1;
                    rounds++;
                }
                Console.WriteLine("Player One's score: " + playerOneScore + "\nPlayer Two's score: " + playerTwoScore);
            }
            if(playerOneScore > playerTwoScore)
            {
                Console.WriteLine("Player One wins!");
            }
            else if(playerOneScore < playerTwoScore)
            {
                Console.WriteLine("Player Two wins!");
            }
            else
            {
                Console.WriteLine("Tie!");
            }

            List<int> ints = new List<int>();
            ints.Add(playerOneScore);
            ints.Add(playerTwoScore);
            ints.Add(rounds);
            return ints;
        }
    }
}
