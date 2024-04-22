using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore : Game
    {
        private int playerOneScore = 0;
        private int playerTwoScore = 0;
        private int rounds = 1;

        //function to find how many times the number that occurs the most times occurs, and what that number is
        private int CheckForMatches(List<int> numList, bool findNumber = false)
        {
            //max values
            int maxCount = 0;
            int maxElement = 0;

            //outer loop
            for(int i = 0; i < numList.Count; i++)
            {
                //reset count to 0 at the start of each loop
                int count = 0;

                //inner loop
                for(int j = 0; j < numList.Count; j++)
                {
                    //if the numbers are the same, increment count
                    if (numList[i] == numList[j])
                    {
                        count++;
                    }
                }

                //if the count is bigger than the current max count, update the max values
                if(count > maxCount)
                {
                    maxCount = count;
                    maxElement = numList[i];
                }
            }

            //return appropriate value depending on what we were finding
            if(findNumber)
            {
                return maxElement;
            }
            else
            {
                return maxCount;
            }
        }

        //check what to add to the players score
        private int CheckScore(int numOfMatches)
        {
            if(numOfMatches == 3)
            {
                return 3;
            }
            else if(numOfMatches == 4)
            {
                return 6;
            }
            else if(numOfMatches == 5)
            {
                return 12;
            }
            else
            {
                return 0;
            }
        }

        public int PlayGame()
        {
            bool done = false; //controls the loop
            bool isPlayerTwo = false; //which players turn is it?
            while(!done)
            {
                int scoreToAdd; //variable used to hold the score that needs to be added to the correct players score
                if (!isPlayerTwo) //if its player ones turn
                {
                    Console.WriteLine("Round " + rounds + "! Fight!"); //print out which round it is
                }

                Console.WriteLine("Player " + (Convert.ToInt32(isPlayerTwo) + 1) + "'s turn. Press any key to roll dice."); //state which players turn it is + provide instruction
                Console.ReadKey(); //wait for the player to press a key
                List<int> list = RollDie(5); //get a list of 5 random numbers from the RollDie() function

                //show what was rolled
                Console.WriteLine("Rolled a: " + list[0] + ", " + list[1] + ", " + list[2] + ", " + list[3] + ", " + list[4] + ".");

                //see how many matches the player got
                int matches = CheckForMatches(list);
                
                //if they got a 2 of a kind
                if(matches == 2)
                {
                    //present options to user, and validate their input
                    int intUserInput = -1;
                    Console.WriteLine("Got 2-of-a-kind! Select an option: \n1. Re-roll all 5 dice\n2. Re-roll the remaining 3?");
                    while (intUserInput == -1)
                    {
                        string userInput = Console.ReadLine();
                        intUserInput = ValidateInput(userInput, 1, 2);
                    }

                    //if they chose to re-roll all dice
                    if (intUserInput == 1)
                    {
                        //overwrite list with a list of 5 new values
                        list = RollDie(5);
                        //tell them what they rolled
                        Console.WriteLine("Rolled a: " + list[0] + ", " + list[1] + ", " + list[2] + ", " + list[3] + ", " + list[4] + ".");
                        //see what to add to the score
                        scoreToAdd = CheckScore(CheckForMatches(list));
                    }
                    //if they chose to only re-roll the remaining dice
                    else
                    {
                        //get the value of the most common item so we can keep it
                        int keptValue = CheckForMatches(list, true);
                        //set list to be a new list containing two of the kept value
                        list = new List<int>
                        {
                            keptValue, keptValue
                        };
                        //create 3 new random numbers and add to the end of the list
                        list.AddRange(RollDie(3));
                        //tell player what they got
                        Console.WriteLine("Rolled a: " + list[0] + ", " + list[1] + ", " + list[2] + ", " + list[3] + ", " + list[4] + ".");
                        //see what to add to score
                        scoreToAdd = CheckScore(CheckForMatches(list));
                    }
                }
                //if the player got only one's or a 3/4/5 of a kind
                else
                {
                    //add the correct score
                    scoreToAdd = CheckScore(matches);
                }

                //add score to correct players score total
                if (!isPlayerTwo)
                {
                    playerOneScore += scoreToAdd;
                }
                else
                {
                    playerTwoScore += scoreToAdd;
                }

                //flip whos turn it is
                isPlayerTwo = !isPlayerTwo;

                //increment rounds
                rounds++;

                //check for game end condition
                if(playerOneScore >= 20 ||  playerTwoScore >= 20)
                {
                    done = true;
                }

                Console.WriteLine("Player One's score: " + playerOneScore + "\nPlayer Two's score: " + playerTwoScore); //let the players know the score
            }

            //report winner
            if (playerOneScore > playerTwoScore)
            {
                Console.WriteLine("Player One wins!");
                return playerOneScore;
            }
            else if(playerTwoScore > playerOneScore)
            {
                Console.WriteLine("Player Two wins!");
                return playerTwoScore;
            }
            else
            {
                Console.WriteLine("Tie!");
                return playerOneScore;
            }
        }
    }
}
