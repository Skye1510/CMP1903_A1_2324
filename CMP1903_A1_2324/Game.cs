﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace CMP1903_A1_2324 {
    internal class Game {
    //Methods
        public List<int> RollDie(int numOfDice) { //New method that returns a list of integers
            List<int> dieResults = new List<int>(); //Create a new list of integers
            Die die; //Create a die variable

            //Rolling the die x times
            for (int i = 0; i < numOfDice; i++) {
                die = new Die(); //Create a new die object
                die.DieValue = die.Roll(); //Roll the die, assign the result to the DieValue property
                dieResults.Add(die.DieValue); //Add the die value to the list
            }
      
            return dieResults; //Return the list
        }

        public int ValidateInput(string initialInput, int minValue, int maxValue)
        {
            int finalInput;
            try
            {
                finalInput = Convert.ToInt32(initialInput);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }

            if (finalInput < minValue ||  finalInput > maxValue)
            {
                Console.WriteLine("Value outside of valid range.");
                return -1;
            }

            return finalInput;
        }

        public void Menu()
        {
            int intUserInput;
            bool done = false;
            Statistics stats = new Statistics();
            stats.GetCurrentScores();
            while (!done)
            {
                intUserInput = -1;
                Console.WriteLine("What would you like to do?\n1. Play Sevens Out\n2. Play Three Or More\n3. View game rules\n4. View statistics\n5. Perform tests\n6. Quit");
                while (intUserInput == -1)
                {
                    string userInput = Console.ReadLine();
                    intUserInput = ValidateInput(userInput, 1, 6);
                }

                if (intUserInput == 1)
                {
                    SevensOut so = new SevensOut();
                    int results = so.PlayGame();
                    stats.stats[0]++;
                    if(results > stats.stats[1])
                    {
                        stats.stats[1] = results;
                    }
                }
                else if (intUserInput == 2)
                {
                    ThreeOrMore tom = new ThreeOrMore();
                    int results = tom.PlayGame();
                    stats.stats[2]++;
                    if(results > stats.stats[3])
                    {
                        stats.stats[3] = results;
                    }
                }
                else if (intUserInput == 3)
                {
                    Console.WriteLine(File.ReadAllText("gameRules.txt"));
                }
                else if (intUserInput == 4)
                {
                    stats.ShowScores();
                }
                else if (intUserInput == 5)
                {
                    Testing testing = new Testing();
                    testing.SelectTest();
                }
                else
                {
                    Console.WriteLine("Thank you so much for-a playing my game. Saving scores and closing program.");
                    stats.UpdateScores();
                    Thread.Sleep(2000);
                    done = true;
                }
            }
        }
    }
}
