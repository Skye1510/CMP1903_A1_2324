using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 
{
    internal class Testing : Game
    {
        private void TestSevens()
        {
            SevensOut sevensOut = new SevensOut();
            sevensOut.PlayGame(true);
        }

        public void SelectTest()
        {
            bool done = false;
            while(!done)
            {
                int userInput = -1;
                Console.WriteLine("Which game would you like to test?\n1. Sevens Out\n2. Three or More\n3. Exit");
                while(userInput == -1) 
                {
                    string strUserInput = Console.ReadLine();
                    userInput = ValidateInput(strUserInput, 1, 2);
                }
                if(userInput == 1)
                {
                    TestSevens();
                }
                else
                {
                    done = true;
                }
            }
        }
    }
}
