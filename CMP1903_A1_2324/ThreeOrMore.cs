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
        int playerOneScore = 0;
        int playerTwoScore = 0;
        int rounds = 1;

        public int checkForMatches(List<int> numList, bool findNumber = false)
        {
            List<int> numbersChecked = new List<int>();
            int maxCount = 0;
            int value = 0;

            for (int i = 0; i < numList.Count; i++) 
            { 
                if (numbersChecked.Contains(numList[i]))
                {
                    continue;
                }

                numbersChecked.Add(numList[i]);
                int count = 0;
                for(int j = 0; j < numList.Count; j++) 
                {
                    if(i == j)
                    {
                        continue;
                    }

                    if (numList[i] == numList[j])
                    {
                        count++;
                    }
                }

                if(count > maxCount)
                {
                    maxCount = count;

                    if(findNumber)
                    {
                        value = numList[i];
                    }
                }
            }

            if(findNumber)
            {
                return value;
            }

            return maxCount;
        }

        public List<int> PlayGame()
        {
            bool done = false;
            bool isPlayerTwo = false;
            while(!done)
            {
                int scoreToAdd = 0; //variable used to hold the score that needs to be added to the correct players score
                if (!isPlayerTwo) //if its player ones turn
                {
                    Console.WriteLine("Round " + rounds + "! Fight!"); //print out which round it is
                }

                Console.WriteLine("Player " + (Convert.ToInt32(isPlayerTwo) + 1) + "'s turn. Press any key to roll dice."); //state which players turn it is + provide instruction
                Console.ReadKey(); //wait for the player to press a key
                List<int> list = RollDie(5); //get a list of 5 random numbers from the RollDie() function

                //creating a string to show the players result
                Console.WriteLine("Rolled a: " + list[0] + ", " + list[1] + ", " + list[2] + ", " + list[3] + ", " + list[4] + ".");

                int matches = checkForMatches(list);
                
                if(matches == 2)
                {
                    //reroll all or remaining
                    //readline
                    //validate input
                    //if all
                        //new list is 5 dice
                        //check for matches
                        //check score
                    //else
                        //call check for matches with 2nd parameter true
                        //new list with returned value as first 2 values
                        //roll another 3 dice and append
                        //check for matches again
                        //check score

                    Console.WriteLine(""); 
                }
                else
                {
                    //take all this and whack it into a function because its needed above :3
                    if (matches == 3)
                    {
                        scoreToAdd = 3;
                    }
                    else if (matches == 4)
                    {
                        scoreToAdd = 6;
                    }
                    else
                    {
                        scoreToAdd = 12;
                    }
                }  
            }
        }
    }
}
