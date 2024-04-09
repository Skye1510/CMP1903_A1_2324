using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut : Game
    {
        int playerOneScore = 0;
        int playerTwoScore = 0;
        int rounds = 1;

        public List<int> PlayGame()
        {
            bool done = false; //controls game loop
            bool isPlayerTwo = false; //bool used to state which players turn it is
            while(!done) //while not done
            {

                int scoreToAdd = 0; //variable used to hold the score that needs to be added to the correct players score
                if (!isPlayerTwo) //if its player ones turn
                {
                    Console.WriteLine("Round " + rounds + "! Fight!"); //print out which round it is
                }

                Console.WriteLine("Player " + (Convert.ToInt32(isPlayerTwo) + 1) + "'s turn. Press any key to roll dice."); //state which players turn it is + provide instruction
                Console.ReadKey(); //wait for the player to press a key
                List<int> list = RollDie(2); //get a list of 2 random numbers from the RollDie() function
                Console.WriteLine("\nRolled a " + list[0] + " and a " + list[1]); //state what the player rolled

                if (list[0] + list[1] == 7) //if the sum of both rolls is a 7
                {
                    done = true; //end the game
                    continue; //skip the rest of the code
                }
                else if (list[0] == list[1]) //if both rolls are the same number
                {
                    scoreToAdd = 2 * (list[0] + list[1]); //add them together, double the result then assign the value to scoreToAdd
                }
                else //otherwise
                {
                    scoreToAdd = list[0] + list[1]; //just add them together then assign to scoreToAdd
                }

                if(!isPlayerTwo) //if its player ones turn
                {
                    playerOneScore += scoreToAdd; //increase player ones score by scoreToAdd
                }
                else // othereise its player twos turn
                {
                    playerTwoScore += scoreToAdd; //so increase player twos score by scoreToAdd
                    rounds++; //increment number of rounds
                }

                isPlayerTwo = !isPlayerTwo;//flip which players turn it is

                Console.WriteLine("Player One's score: " + playerOneScore + "\nPlayer Two's score: " + playerTwoScore); //let the players know the score
            }

            //once the game is over, report the winner
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

            //return stats back to the game object
            List<int> ints = new List<int>();
            ints.Add(playerOneScore);
            ints.Add(playerTwoScore);
            ints.Add(rounds);
            return ints;
        }
    }
}
